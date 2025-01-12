using System.Net.Sockets;
using System.Net;
using System.Windows.Controls;
using PacketDotNet;
using SharpPcap;

namespace Client_Holu_Win.src.Presentation.Pages.MainGame
{
    public partial class GamesPage : Page
    {
        private Frame _mainFrame;
        private ICaptureDevice _device;
        private const int ProxyPort = 6112;
        private const string ServerIp = "127.0.0.1";
        private const int ServerPort = 2567;
        public GamesPage(Frame mainFrame)
        {
            InitializeComponent();
            
            _mainFrame = mainFrame;

            StartProxy();
        }

        // Iniciar el proxy de captura de paquetes
        public void StartProxy()
        {
            _device = CaptureDeviceList.Instance[0];
            _device.OnPacketArrival += new PacketArrivalEventHandler(OnPacketArrival); 
            _device.Open(DeviceModes.Promiscuous); 
            _device.StartCapture(); 
        }

        private void OnPacketArrival(object sender, PacketCapture e)
        {
            var packet = Packet.ParsePacket(e.GetPacket().LinkLayerType, e.GetPacket().Data);

            if (packet is EthernetPacket ethPacket)
            {
                var ipPacket = ethPacket.PayloadPacket as IPPacket;
                
                if (ipPacket != null && ipPacket.DestinationAddress.Equals(IPAddress.Parse("127.0.0.1")) && ipPacket.PayloadPacket is UdpPacket udpPacket)
                {
                    if (udpPacket.DestinationPort == ProxyPort)
                    {
                        ForwardPacketToServer(udpPacket);

                        // Show the packet info in the TextBlock
                        ShowPacketDataInTextBlock(udpPacket);
                    }
                }
            }
        }

        // Mostrar los datos del paquete en el TextBlock
        private void ShowPacketDataInTextBlock(UdpPacket udpPacket)
        {
            // Puedes obtener y mostrar la información que desees del paquete
            string packetInfo = $"UDP Packet Data: \n" +
                                $"Source Port: {udpPacket.SourcePort} \n" +
                                $"Destination Port: {udpPacket.DestinationPort} \n" +
                                $"Length: {udpPacket.PayloadData.Length} bytes \n" +
                                $"Payload (Hex): {BitConverter.ToString(udpPacket.PayloadData)} \n";

            // Actualizar el TextBlock con la información del paquete
            PacketInfoTextBlock.Dispatcher.Invoke(() =>
            {
                PacketInfoTextBlock.Text = packetInfo;
            });
        }

        private void ForwardPacketToServer(UdpPacket udpPacket)
        {
            try
            {
                using (var client = new UdpClient())
                {
                    client.Connect(ServerIp, ServerPort);
                    byte[] packetData = udpPacket.PayloadData;

                    client.Send(packetData, packetData.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al reenviar el paquete al servidor: " + ex.Message);
            }
        }

        public void StopProxy()
        {
            if (_device != null && _device.Started)
            {
                _device.StopCapture();
                _device.Close();
            }
        }
    }
}

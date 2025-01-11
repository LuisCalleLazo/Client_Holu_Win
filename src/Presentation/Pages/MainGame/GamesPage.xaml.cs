using System.Text;
using System.Windows.Controls;
using PacketDotNet;
using SharpPcap;

namespace Client_Holu_Win.src.Presentation.Pages.MainGame
{
    public partial class GamesPage : Page
    {
        private Frame _mainFrame;
        private ICaptureDevice _device;
        public GamesPage(Frame mainFrame)
        {
            InitializeComponent();
            
            _mainFrame = mainFrame;

            // Suscribirse al evento Navigating del Frame
            //_mainFrame.Navigating += MainFrame_Navigating;


            StartPacketCapture();
        }

        private void MainFrame_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            if (_device != null)
            {
                _device.StopCapture();
                _device.Close();
                UpdateOutput("Captura detenida.");
            }
        }

        private void StartPacketCapture()
        {
            var devices = CaptureDeviceList.Instance;

            if (devices.Count < 1)
            {
                UpdateOutput("No se encontraron dispositivos.");
                return;
            }

            // Listar todos los dispositivos disponibles
            //foreach (var dev in devices)
            //{
            //    UpdateOutput($"Dispositivo encontrado: {dev.Description}");
            //}

            _device = devices.FirstOrDefault(d => d.Description.Contains("Wi-Fi") || d.Description.Contains("Ethernet"));

            if (_device == null)
            {
                UpdateOutput("No se encontró un dispositivo adecuado para captura.");
                return;
            }

            _device.OnPacketArrival += new PacketArrivalEventHandler(Device_OnPacketArrival);

            _device.Open(DeviceModes.Promiscuous, 1000);
            _device.Filter = "tcp port 6112";

            UpdateOutput("Escuchando en " + _device.Description);

            // Iniciar la captura
            _device.StartCapture();
        }

        private void Device_OnPacketArrival(object sender, PacketCapture e)
        {
            var packet = PacketDotNet.Packet.ParsePacket(e.GetPacket().LinkLayerType, e.GetPacket().Data);
            var tcpPacket = packet.Extract<TcpPacket>();

            if (tcpPacket != null && tcpPacket.PayloadData.Length > 0)
            {
                var rawData = tcpPacket.PayloadData;
                string hexData = BitConverter.ToString(rawData).Replace("-", " ");
                string decodedData = DecodeRawData(rawData);

                // Actualizar la interfaz gráfica
                this.Dispatcher.Invoke(() =>
                {
                    UpdateOutput($"Datos crudos (bytes): {hexData}");
                    UpdateOutput($"Datos decodificados: {decodedData}");
                });
            }
        }

        private string DecodeRawData(byte[] rawData)
        {
            StringBuilder result = new StringBuilder();
            foreach (var encoding in new[] { "utf-8" })
            {
                try
                {
                    string data = System.Text.Encoding.GetEncoding(encoding).GetString(rawData);
                    result.AppendLine($"Datos ({encoding}): {data}");
                }
                catch (Exception ex)
                {
                    result.AppendLine($"Error al decodificar con {encoding}: {ex.Message}");
                }
            }
            return result.ToString();
        }

        private void UpdateOutput(string message)
        {
            txtOutput.AppendText(Environment.NewLine + message + Environment.NewLine);
        }
    }
}

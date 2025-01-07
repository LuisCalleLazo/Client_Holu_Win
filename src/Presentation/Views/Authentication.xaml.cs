using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Client_Holu_Win.src.Presentation.Views
{
    public partial class Authentication : Window
    {
        private TcpListener listener;
        private List<TcpClient> connectedClients = new List<TcpClient>();
        public Authentication()
        {
            InitializeComponent();
            StartProxy();
        }

        private async void StartProxy()
        {
            listener = new TcpListener(IPAddress.Any, 6112);
            listener.Start();
            await Task.Run(() => AcceptClients());
        }

        private void AcceptClients()
        {
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                lock (connectedClients)
                {
                    connectedClients.Add(client);
                }
                Dispatcher.Invoke(() => UpdateConnectedClientsList());
                ProcessClient(client);
            }
        }

        private async void ProcessClient(TcpClient client)
        {
            TcpClient remoteServer = new TcpClient("127.0.0.1", 6112);
            using (client)
            using (remoteServer)
            {
                NetworkStream clientStream = client.GetStream();
                NetworkStream serverStream = remoteServer.GetStream();

                Task clientToServer = RelayTraffic(clientStream, serverStream);
                Task serverToClient = RelayTraffic(serverStream, clientStream);

                await Task.WhenAll(clientToServer, serverToClient);
            }
        }

        private async Task RelayTraffic(NetworkStream input, NetworkStream output)
        {
            byte[] buffer = new byte[1024];
            int bytesRead;
            while ((bytesRead = await input.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                await output.WriteAsync(buffer, 0, bytesRead);
            }
        }

        private void UpdateConnectedClientsList()
        {
            ConnectedClientsListBox.Items.Clear();
            foreach (var client in connectedClients)
            {
                ConnectedClientsListBox.Items.Add(client.Client.RemoteEndPoint.ToString());
            }
        }
    }
}

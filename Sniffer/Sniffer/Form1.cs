using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PacketDotNet;
using PcapDotNet.Core;
using PcapDotNet.Packets;

namespace Sniffer
{
    public partial class Form1 : Form
    {
        string itemNumber = "", time = "", source = "", sourcePort = "", destination = "", destinationPort = "", protocol = "", packageSize = "";
        Boolean running = false;
        private void Button1_Click(object sender, EventArgs e)
        {
            GetAdapter();
            StartListening();
        }

        int selectedDevice;
        IList<LivePacketDevice> allDevices = LivePacketDevice.AllLocalMachine;

        public Form1()
        {
            InitializeComponent();
            SetAdapters();
        }

        private void GetAdapter()
        {
            selectedDevice = adapterSelect.SelectedIndex;
        }

        private void SetAdapters()
        {
            IList<LivePacketDevice> allDevices = LivePacketDevice.AllLocalMachine;
            for (int i = 0; i != allDevices.Count(); i++)
            {
                LivePacketDevice device = allDevices[i];
                adapterSelect.Items.Add(device.Description);
            }
        }

        public async void StartListening()
        {
            string output = "";
            int total = 0;
            using (PacketCommunicator communicator =
                allDevices[selectedDevice].Open(65536,                      // portion of the packet to capture
                                                                            // 65536 guarantees that the whole packet will be captured on all the link layers
                                    PacketDeviceOpenAttributes.Promiscuous, // promiscuous mode
                                    10000))                                  // read timeout
            {

                // start the capture

                PcapDotNet.Packets.Packet packet;
                do
                {
                    PacketCommunicatorReceiveResult result = communicator.ReceivePacket(out packet);
                    switch (result)
                    {
                        case PacketCommunicatorReceiveResult.Timeout:
                            // Timeout elapsed
                            total += 1;
                            continue;
                        case PacketCommunicatorReceiveResult.Ok:
                            AddText(packet);
                            total += 1;
                            break;
                        default:
                            throw new InvalidOperationException("The result " + result + " should never be reached here");
                    }
                } while (total < 100);
            }
        }

        public void AddText(PcapDotNet.Packets.Packet packet)
        {
            packetOutBox.Items.Add(packet.ToString());
        }
    }
}

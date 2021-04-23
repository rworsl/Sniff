using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PcapDotNet.Core;
using SharpPcap;

namespace Sniffer
{
    public partial class Form1 : Form
    {
        string itemNumber = "", time = "", source = "", sourcePort = "", destination = "", destinationPort = "", protocol = "", packageSize = "";

        private void Button1_Click(object sender, EventArgs e)
        {
            GetAdapter();
        }

        PacketDevice selectedDevice;

        public Form1()
        {
            InitializeComponent();
            SetAdapters();
        }

        private void GetAdapter()
        {
            selectedDevice = (PacketDevice)adapterSelect.SelectedItem;
            packetOutBox.Items.Add(selectedDevice.ToString());
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
    }
}

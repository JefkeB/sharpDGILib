using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace sharpDGI
{
    public partial class Main_Form : Form
    {
        ListBoxStreamWriter _writer = null;

        //
        //
        //
        public Main_Form()
        {
            InitializeComponent();

            _writer = new ListBoxStreamWriter(log_listBox);
            Console.SetOut(_writer);

            Console.WriteLine("started");
        }

        //
        //
        //
        private void Connect_button_Click(object sender, EventArgs e)
        {
            sharpDGILib dgi = new sharpDGILib();

            dgi.Discover();

            Int32 deviceCount = dgi.DeviceCount;
            Console.WriteLine("devices : {0}", deviceCount);
            if (deviceCount == 0)
                return;

            Console.WriteLine("name : {0}", dgi.DeviceName);
            Console.WriteLine("serial : {0}", dgi.Serial);

            dgi.selectedDevice = dgi.Serial;

            if (!dgi.isDgiMode)
            {
                Console.WriteLine("Must change mode !!");
                dgi.setDgiModeActive();

                // wat for re-enumeration
                Thread.Sleep(2500);
                dgi.Discover();

                Console.WriteLine("Mode changed?");
            }

            if (!dgi.isDgiMode)
            {
                Console.WriteLine("Failed to change mode !");
                return;
            }


            if (dgi.Connect() == false)
            {
                Console.WriteLine("Failed to connect !");
                return;
            }

            Console.WriteLine("sw ver : {0}", dgi.FirmwareVersion());

            dgi.Disconnect();

            Console.WriteLine("Disconnect");
        }
    }
}

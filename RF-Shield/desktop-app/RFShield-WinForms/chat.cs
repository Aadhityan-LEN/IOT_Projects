using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WInLogin
{
    public partial class CHAT : Form
    {

        SerialPort serialPort;
        public CHAT()
        {

            
            InitializeComponent();

            //port  assigning 
            serialPort = new SerialPort("COM7", 115200);
            serialPort.Open();


            //Receiver side code
            //InitializeComponent();

            //add textbox indent
            richTextBox1.SelectionIndent = 10;

            //serialPort = new SerialPort("COM8", 115200);
            serialPort.DataReceived += SerialPort_DataReceived;
            //serialPort.Open();

            //R_end

            //window start position
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(400, 200); // Set custom position
        }



        // Receiver logic
        //private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        //{
        //    try
        //    {
        //        string data = serialPort.ReadLine();

        //        this.Invoke(new MethodInvoker(delegate
        //        {
        //            richTextBox1.AppendText(data + Environment.NewLine);
        //        }));
        //    }
        //    catch { }
        //}
        // Receiver logic End


        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = serialPort.ReadLine();

                // Remove all leading question marks
                data = data.TrimStart('?');

                // Put each word on a new line
                data = data.Replace(" ",Environment.NewLine);

                this.Invoke(new MethodInvoker(delegate
                {
                    richTextBox1.AppendText("" + data + Environment.NewLine);
                }));

                // Put each word on a new line
                data = data.Replace(" ", Environment.NewLine);
            }
            catch
            {
            }
        }



        private void Login_button_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                string text = guna2TextBox1.Text;
                serialPort.WriteLine(text);
                // clear the text
                guna2TextBox1.Text = "";
            }
        }




        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();  // Close entire application

        }

        private void resizebutton_Click(object sender, EventArgs e)
        {
            
        }

        private void minbutton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }



        // create variables for dynamic move window form
        //use diff variable name 
        private const int WM_NCLBUTTONDOWN1 = 0xA1;
        private const int HT_CAPTION1 = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            /*rezize dynamically*/
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN1, HT_CAPTION1, 0);
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            LOGIN loginPage = new LOGIN();
            loginPage.Show();

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
    }
}

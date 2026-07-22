using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


//music
//using System.IO;



namespace WInLogin
{
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(400, 200); // Set custom position
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            //System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            //int radius = 15; // Adjust the value to change the roundness of the corners

            // Create a rounded rectangle path using the form's size and radius
            //path.AddArc(0, 0, radius, radius, 180, 90); // Top-left corner
            //path.AddArc(this.Width - radius, 0, radius, radius, 270, 90); // Top-right corner
            //path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90); // Bottom-right corner
            //path.AddArc(0, this.Height - radius, radius, radius, 90, 90); // Bottom-left corner

            // Create a region with the rounded rectangle path and apply it to the form
            //this.Region = new Region(path);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }


        // create variables for dynamic move window form ;;;;;;;;;;;;;;
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        // ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            //authentication
            if (tbusername.Text == "a" && tbpassword.Text == "1")
            {
                //MessageBox.Show("login Successully");
                //CHAT chatPage = new CHAT();
                //chatPage.Show();
                //this.Hide();

                // progress adding timer
                timer1.Start();

                // reset progress bar
                guna2ProgressBar1.Value = 0;

                //messagebox for access granted
                //MessageBox.Show("Access Granted");

            }
            else
            {
                deniedmgBox msg = new deniedmgBox();
                msg.ShowDialog(this);

                //messagebox for access denied
                //MessageBox.Show("Access Denied");
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            /*rezize dynamically*/
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void tbusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void minbutton_Click(object sender, EventArgs e)
        {

        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        // minimize the code restore
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                // do nothing — let Windows handle it
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                this.Show();
            }
        }



        private void minimize_btn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //progress bar timer code
        private void timer1_Tick(object sender, EventArgs e)
        {
            //progressBar1.Increment(1);
            guna2ProgressBar1.Increment(2);

            if (guna2ProgressBar1.Value >= 100)
            {
                // stop timer
                timer1.Stop();

                CHAT chatPage = new CHAT();
                chatPage.Show();
                this.Hide();

                // show message
                //MessageBox.Show("Access Granted");

               
            }

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace Visualisierung
{
    public partial class Form1 : Form
    {
        SerialPort serial = new SerialPort();
        Parameter param = new Parameter();
        Monitor mon = new Monitor();

        string version = "2.2.3";
        string versDatum = "09.03.2014";

        bool checkSendMessage = false;
        string serialPortname = null;
        bool flagButton1 = false;
        bool flagButton2 = false;
        bool flagButton3 = false;
        bool flagButton4 = false;
        bool flagButton5 = false;
        bool flagButton6 = false;
        bool flagButton7 = false;
        bool flagButton8 = false;

        string scrollLeftMax;
        string scrollLeftMin;
        string scrollRightMax;
        string scrollRightMin;
        

        public Form1()
        {
            InitializeComponent();
            this.Text = param.ReadXmlSingleNode("Einstellungen.xml", "Grundeinstellungen", "Programmeinstellungen", "Generell", "Fenstertitel");
            grpMessage1.Text = param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button1", "Ueberschrift");
            grpMessage2.Text = param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button2", "Ueberschrift");
            grpMessage3.Text = param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button3", "Ueberschrift");
            grpMessage4.Text = param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button4", "Ueberschrift");
            grpMessage5.Text = param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button5", "Ueberschrift");
            grpMessage6.Text = param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button6", "Ueberschrift");
            grpMessage7.Text = param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button7", "Ueberschrift");
            grpMessage8.Text = param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button8", "Ueberschrift");
            grpScrollLeft.Text = param.ReadXmlSingleNode("Schieberegler.xml", "Grundeinstellungen", "Programmeinstellungen", "SchiebereglerLinks", "Ueberschrift");
            grpScrollRight.Text = param.ReadXmlSingleNode("Schieberegler.xml", "Grundeinstellungen", "Programmeinstellungen", "SchiebereglerRechts", "Ueberschrift");
            //if (grpMessage8.Text == "")
            //    grpMessage8.Visible = false;

            btnMessage1.Text = param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button1", "Bezeichnung1");
            btnMessage2.Text = param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button2", "Bezeichnung1");
            btnMessage3.Text = param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button3", "Bezeichnung1");
            btnMessage4.Text = param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button4", "Bezeichnung1");
            btnMessage5.Text = param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button5", "Bezeichnung1");
            btnMessage6.Text = param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button6", "Bezeichnung1");
            btnMessage7.Text = param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button7", "Bezeichnung1");
            btnMessage8.Text = param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button8", "Bezeichnung1");

            scrollLeftMax = param.ReadXmlSingleNode("Schieberegler.xml", "Grundeinstellungen", "Programmeinstellungen", "SchiebereglerLinks", "obereGrenze");
            scrollLeftMin = param.ReadXmlSingleNode("Schieberegler.xml", "Grundeinstellungen", "Programmeinstellungen", "SchiebereglerLinks", "untereGrenze");
            scrollRightMax = param.ReadXmlSingleNode("Schieberegler.xml", "Grundeinstellungen", "Programmeinstellungen", "SchiebereglerRechts", "obereGrenze");
            scrollRightMin = param.ReadXmlSingleNode("Schieberegler.xml", "Grundeinstellungen", "Programmeinstellungen", "SchiebereglerRechts", "untereGrenze");

            trkLeft.Maximum = int.Parse(scrollLeftMax);
            trkLeft.Minimum = int.Parse(scrollLeftMin);
            trkRight.Maximum = int.Parse(scrollRightMax);
            trkRight.Minimum = int.Parse(scrollRightMin);

            lblScrollLeftMax.Text = scrollLeftMax;
            lblScrollLeftMin.Text = scrollLeftMin;
            lblScrollRightMax.Text = scrollRightMax;
            lblScrollRightMin.Text = scrollRightMin;
        }

        private void seriellConnection()
        {
            
            if (!serial.IsOpen)
            {
                try
                {
                    serialPortname = param.ReadXmlSingleNode("Kommunikation.xml", "Grundeinstellungen", "Kommunikation", "Seriell", "Schnittstelle");
                    serial.PortName = serialPortname;
                    serial.BaudRate = int.Parse(param.ReadXmlSingleNode("Kommunikation.xml", "Grundeinstellungen", "Kommunikation", "Seriell", "BaudRate"));//9600;
                    string parity = param.ReadXmlSingleNode("Kommunikation.xml", "Grundeinstellungen", "Kommunikation", "Seriell", "Parity");
                    serial.Parity = (Parity)System.Enum.Parse(typeof(Parity), parity);// Parity.None;
                    serial.DataBits = int.Parse(param.ReadXmlSingleNode("Kommunikation.xml", "Grundeinstellungen", "Kommunikation", "Seriell", "DataBits")); ;//8;
                    string stopBits = param.ReadXmlSingleNode("Kommunikation.xml", "Grundeinstellungen", "Kommunikation", "Seriell", "StopBits");
                    serial.StopBits = (StopBits)System.Enum.Parse(typeof(StopBits), stopBits);// Parity.None;
                    //serial.StopBits = StopBits.One;   
                }
                catch
                {
                    MessageBox.Show("Fehler beim Verbinden Seriell", "Fehler Seriell", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Nachricht per Seriell verschicken
        /// </summary>
        /// <param name="message">Nachricht/Text</param>
        /// <returns>true/false</returns>
        private bool sendMessage(string message)
        {
            try
            {
                seriellConnection();
                try
                {
                    if (!serial.IsOpen)
                        serial.Open();
                }
                catch
                {
                    MessageBox.Show("Kann seriellen Port nicht öffnen!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                string hex = StringToHex(message);
                byte[] readyToSendHex = Encoding.ASCII.GetBytes(hex);
                byte[] readyToSend = Encoding.ASCII.GetBytes(message);
                //byte[] readyToSendHex = System.Text.UTF8Encoding.Default.GetBytes(txtMessage1.Text);
                //if (chkHex.Checked)
                //    serial.Write(readyToSendHex, 0, readyToSendHex.Length);
                //else
                serial.Write(readyToSend, 0, readyToSend.Length);
                System.Threading.Thread.Sleep(400);
                //byte[] empfang = new byte[1024];
                //int bytesReceived = serial.ReadLineReceive(empfang);
                string empfang = serial.ReadExisting();//ReadLine();
                ////lblSendRecieve.Text = "send: "+message + "\n\nrec.: " + empfang;
                ////lblSendRecieve.Refresh();
                string textLblMonitor = mon.lblMonitor.Text;
                mon.lblMonitor.Text = textLblMonitor + "\n----------------------------------------------\n--> " + message + " (" + DateTime.Now + ")\n\n<-- " + empfang + " (" + DateTime.Now + ")";//\n----------------------------------------------\n" + textLblMonitor;
                string textTxtmonitor = mon.txtMonitor.Text;
                //mon.txtMonitor.Text = textTxtmonitor + "\r\n----------------------------------------------\r\n--> " + message + " (" + DateTime.Now + ")\r\n\r\n<-- " + empfang + " (" + DateTime.Now + ")";//\n----------------------------------------------\n" + textLblMonitor;
                mon.txtMonitor.AppendText("( " + DateTime.Now + " ) --> " + message + "\r\n\r\n( " + DateTime.Now + " ) <-- " + empfang + "\r\n----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------\r\n"); //("\r\n----------------------------------------------\r\n--> " + message + " (" + DateTime.Now + ")\r\n\r\n<-- " + empfang + " (" + DateTime.Now + ")");
                mon.txtMonitor.SelectionStart = mon.txtMonitor.Text.Length;
                mon.txtMonitor.ScrollToCaret();
                //mon.lblMonitor.auto
                mon.lblMonitor.Refresh();
                
                ////System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
                ////lblSendRecieve.Text = message + "\n\n" + enc.GetString(empfang).Trim('\0');
                //lblSendRecieve.Text = enc.GetString(empfang).Trim('\0');
                //serial.Close(); 
                return true;
            }
            catch
            {
                MessageBox.Show("Fehler beim Senden", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Wandelt den übergebenen String in die Hexadezimaldarstellung
        /// </summary>
        /// <param name="Hexstring">der umzuwandelnde String</param>
        /// <returns>Hexadezimaldarstellung</returns>
        private string StringToHex(string hexstring)
        {
            var sb = new StringBuilder();
            foreach (char t in hexstring)
                sb.Append("0x"+Convert.ToInt32(t).ToString("x")+" ");
            return sb.ToString();
        }

        /// <summary>
        /// Nachricht Nummer1 senden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMessage1_Click(object sender, EventArgs e)
        {
            if (!flagButton1)
            {
                checkSendMessage = sendMessage(param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button1", "Befehl1"));
                if (!checkSendMessage)
                    MessageBox.Show("Nachricht wurde nicht gesendet", "Sendefehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (checkSendMessage)
                {
                    btnMessage1.Text = param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button1", "Bezeichnung2");
                    flagButton1 = true;
                    return;
                }
            }
            if (flagButton1)
            {
                checkSendMessage = sendMessage(param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button1", "Befehl2"));
                if (!checkSendMessage)
                    MessageBox.Show("Nachricht wurde nicht gesendet", "Sendefehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (checkSendMessage)
                {
                    btnMessage1.Text = param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button1", "Bezeichnung1");
                    flagButton1 = false;
                    return;
                }
            }
        }

        /// <summary>
        /// Nachricht Nummer2 senden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMessage2_Click(object sender, EventArgs e)
        {
            if (!flagButton2)
            {
                checkSendMessage = sendMessage(param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button2", "Befehl1"));
                if (!checkSendMessage)
                    MessageBox.Show("Nachricht wurde nicht gesendet", "Sendefehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (checkSendMessage)
                {
                    btnMessage2.Text = param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button2", "Bezeichnung2");
                    flagButton2 = true;
                    return;
                }
            }
            if (flagButton2)
            {
                checkSendMessage = sendMessage(param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button2", "Befehl2"));
                if (!checkSendMessage)
                    MessageBox.Show("Nachricht wurde nicht gesendet", "Sendefehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (checkSendMessage)
                {
                    btnMessage2.Text = param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button2", "Bezeichnung1");
                    flagButton2 = false;
                    return;
                }
            }
        }

        /// <summary>
        /// Nachricht Nummer3 senden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMessage3_Click(object sender, EventArgs e)
        {
            if (!flagButton3)
            {
                checkSendMessage = sendMessage(param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button3", "Befehl1"));
                if (!checkSendMessage)
                    MessageBox.Show("Nachricht wurde nicht gesendet", "Sendefehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (checkSendMessage)
                {
                    btnMessage3.Text = param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button3", "Bezeichnung2");
                    flagButton3 = true;
                    return;
                }
            }
            if (flagButton3)
            {
                checkSendMessage = sendMessage(param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button3", "Befehl2"));
                if (!checkSendMessage)
                    MessageBox.Show("Nachricht wurde nicht gesendet", "Sendefehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (checkSendMessage)
                {
                    btnMessage3.Text = param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button3", "Bezeichnung1");
                    flagButton3 = false;
                    return;
                }
            }
        }

        /// <summary>
        /// Nachricht Nummer4 senden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMessage4_Click(object sender, EventArgs e)
        {
            if (!flagButton4)
            {
                checkSendMessage = sendMessage(param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button4", "Befehl1"));
                if (!checkSendMessage)
                    MessageBox.Show("Nachricht wurde nicht gesendet", "Sendefehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (checkSendMessage)
                {
                    btnMessage4.Text = param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button4", "Bezeichnung2");
                    flagButton4 = true;
                    return;
                }
            }
            if (flagButton4)
            {
                checkSendMessage = sendMessage(param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button4", "Befehl2"));
                if (!checkSendMessage)
                    MessageBox.Show("Nachricht wurde nicht gesendet", "Sendefehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (checkSendMessage)
                {
                    btnMessage4.Text = param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button4", "Bezeichnung1");
                    flagButton4 = false;
                    return;
                }
            }
        }

        /// <summary>
        /// Nachricht Nummer5 senden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMessage5_Click(object sender, EventArgs e)
        {
            if (!flagButton5)
            {
                checkSendMessage = sendMessage(param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button5", "Befehl1"));
                if (!checkSendMessage)
                    MessageBox.Show("Nachricht wurde nicht gesendet", "Sendefehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (checkSendMessage)
                {
                    btnMessage5.Text = param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button5", "Bezeichnung2");
                    flagButton5 = true;
                    return;
                }
            }
            if(flagButton5)
            {
                checkSendMessage = sendMessage(param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button5", "Befehl2"));
                if (!checkSendMessage)
                    MessageBox.Show("Nachricht wurde nicht gesendet", "Sendefehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (checkSendMessage)
                {
                    btnMessage5.Text = param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button5", "Bezeichnung1");
                    flagButton5 = false;
                    return;
                }
            }
        }

        /// <summary>
        /// Nachricht Nummer6 senden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMessage6_Click(object sender, EventArgs e)
        {
            if (!flagButton6)
            {
                checkSendMessage = sendMessage(param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button6", "Befehl1"));
                if (!checkSendMessage)
                    MessageBox.Show("Nachricht wurde nicht gesendet", "Sendefehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (checkSendMessage)
                {
                    btnMessage6.Text = param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button6", "Bezeichnung2");
                    flagButton6 = true;
                    return;
                }
            }
            if (flagButton6)
            {
                checkSendMessage = sendMessage(param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button6", "Befehl2"));
                if (!checkSendMessage)
                    MessageBox.Show("Nachricht wurde nicht gesendet", "Sendefehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (checkSendMessage)
                {
                    btnMessage6.Text = param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button6", "Bezeichnung1");
                    flagButton6 = false;
                    return;
                }
            }
        }

        /// <summary>
        /// Nachricht Nummer7 senden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMessage7_Click(object sender, EventArgs e)
        {
            if (!flagButton7)
            {
                checkSendMessage = sendMessage(param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button7", "Befehl1"));
                if (!checkSendMessage)
                    MessageBox.Show("Nachricht wurde nicht gesendet", "Sendefehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (checkSendMessage)
                {
                    btnMessage7.Text = param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button7", "Bezeichnung2");
                    flagButton7 = true;
                    return;
                }
            }
            if (flagButton7)
            {
                checkSendMessage = sendMessage(param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button7", "Befehl2"));
                if (!checkSendMessage)
                    MessageBox.Show("Nachricht wurde nicht gesendet", "Sendefehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (checkSendMessage)
                {
                    btnMessage7.Text = param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button7", "Bezeichnung1");
                    flagButton7 = false;
                    return;
                }
            }
        }

        /// <summary>
        /// Nachricht Nummer8 senden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMessage8_Click(object sender, EventArgs e)
        {
            if (!flagButton8)
            {
                checkSendMessage = sendMessage(param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button8", "Befehl1"));
                if (!checkSendMessage)
                    MessageBox.Show("Nachricht wurde nicht gesendet", "Sendefehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (checkSendMessage)
                {
                    btnMessage8.Text = param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button8", "Bezeichnung2");
                    flagButton8 = true;
                    return;
                }
            }
            if (flagButton8)
            {
                checkSendMessage = sendMessage(param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button8", "Befehl2"));
                if (!checkSendMessage)
                    MessageBox.Show("Nachricht wurde nicht gesendet", "Sendefehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (checkSendMessage)
                {
                    btnMessage8.Text = param.ReadXmlSingleNode("Tasten.xml", "Grundeinstellungen", "Programmeinstellungen", "Button8", "Bezeichnung1");
                    flagButton8 = false;
                    return;
                }
            }
        }

        /// <summary>
        /// Schieberegler links verstellen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trkLeft_Scroll(object sender, EventArgs e)
        {
            checkSendMessage = sendMessage(trkLeft.Value.ToString());
            if (!checkSendMessage)
                MessageBox.Show("Nachricht wurde nicht gesendet", "Sendefehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Schieberegler rechts verstellen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trkRight_Scroll(object sender, EventArgs e)
        {
            checkSendMessage = sendMessage(trkRight.Value.ToString());
            if (!checkSendMessage)
                MessageBox.Show("Nachricht wurde nicht gesendet", "Sendefehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Programm wird beendet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serial.IsOpen)
                serial.Close();
        }

        /// <summary>
        /// Monitor anzeigen lassen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void monitorÖffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Monitor mon1 = new Monitor();
            mon.lblMonitor.Text = "";
            mon.Show();

            ////try
            ////{
            ////    mon.Show();
            ////}
            ////catch
            ////{
            ////    Monitor mon = new Monitor();
            ////    mon.Show();
            ////}
        }

        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version " + version + " / Datum: " + versDatum + " / © J.Schmid", "Programmversion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



    }
}

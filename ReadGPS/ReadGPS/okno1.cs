using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;



namespace ReadGPS
{

    public partial class okno1 : Form
    {
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (serialPort1.IsOpen)
            {
                string data = serialPort1.ReadExisting();
                string[] strArr = data.Split('$');
                for (int i = 0; i < strArr.Length; i++)
                {
                    string strTemp = strArr[i];
                    string[] lineArr = strTemp.Split(',');
                    if (lineArr[0] == "GPGGA")
                    {

                        try
                        {
                            //Latitude
                            Double dLat = Convert.ToDouble(lineArr[2]);
                            dLat = dLat / 100;
                            string[] lat = dLat.ToString().Split('.');
                            string Latitude = lineArr[3].ToString() + lat[0].ToString() + "." + ((Convert.ToDouble(lat[1]) / 60)).ToString("#####");

                            //Longitude
                            Double dLon = Convert.ToDouble(lineArr[4]);
                            dLon = dLon / 100;
                            string[] lon = dLon.ToString().Split('.');
                            string Longitude = lineArr[5].ToString() + lon[0].ToString() + "." + ((Convert.ToDouble(lon[1]) / 60)).ToString("#####");

                            //Display
                            txtLat.Text = Latitude;
                            txtLong.Text = Longitude;

                            btnMapIt.Enabled = true;
                        }
                        catch
                        {
                            //Can't Read GPS values
                            txtLat.Text = "GPS Unavailable";
                            txtLong.Text = "GPS Unavailable";
                            btnMapIt.Enabled = false;
                        }
                    }
                }

            }
            else
            {
                txtLat.Text = "COM Port Closed";
                txtLong.Text = "COM Port Closed";
                btnMapIt.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                timer1.Enabled = false;
            }   
            else
            {
                timer1.Enabled = true;
            }

            if (button1.Text == "Update")
                button1.Text = "Stop Updates";
            else
                button1.Text = "Update";
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Close();
                serialPort1.PortName = "COM1";
                serialPort1.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "COM1");
            }
        }


        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Close();
                serialPort1.PortName = "COM2";
                serialPort1.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "COM2");
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Close();
                serialPort1.PortName = "COM3";
                serialPort1.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "COM3");
            }
        }


        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Close();
                serialPort1.PortName = "COM4";
                serialPort1.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "COM4");
            }
        }



        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Close();
                serialPort1.PortName = "COM5";
                serialPort1.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "COM5");
            }
        }


        private void btnMapIt_Click(object sender, EventArgs e)
        {
            oknoMapa f = new oknoMapa(Latitude, Longitude);
            f.Show();
        }



    }
}
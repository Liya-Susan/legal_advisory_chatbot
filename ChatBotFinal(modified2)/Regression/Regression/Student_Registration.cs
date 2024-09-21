using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ChatBot
{
    public partial class Student_Registration : Form
    {
        BaseConnection con = new BaseConnection();

        public static string uid = "";
        public static string sid = "";
        public static string coverpath = "";
        public static string thumbpath = "";


        public Student_Registration()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        public static Image RoundCorners(Image StartImage, int CornerRadius, Color BackgroundColor)
        {
            CornerRadius *= 2;
            Bitmap RoundedImage = new Bitmap(StartImage.Width, StartImage.Height);
            Graphics g = Graphics.FromImage(RoundedImage);
            g.Clear(BackgroundColor);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Brush brush = new TextureBrush(StartImage);
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(0, 0, CornerRadius, CornerRadius, 180, 90);
            gp.AddArc(0 + RoundedImage.Width - CornerRadius, 0, CornerRadius, CornerRadius, 270, 90);
            gp.AddArc(0 + RoundedImage.Width - CornerRadius, 0 + RoundedImage.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
            gp.AddArc(0, 0 + RoundedImage.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
            g.FillPath(brush, gp);
            return RoundedImage;
        }

        public void user()
        {
            try
            {
                string query = "select isnull(max(Userid),100)+1 from login";
                SqlDataReader dr = con.ret_dr(query);
                if (dr.Read())
                {
                    uid = dr[0].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while generating user Id........");
            }
        }

        public void studentid()
        {
            try
            {
                string query = "select isnull(max(regno),100)+1 from User_details";
                SqlDataReader dr = con.ret_dr(query);
                if (dr.Read())
                {
                    sid = dr[0].ToString();
                    admno.Text = sid;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while generating user Id........");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                

                string utype = "User";
                string query = "insert into login values(" + sid + ",'" + usert.Text + "','" + pwd.Text + "','" + utype + "')";
                if (con.exec1(query) > 0)
                {
                    string query1 = "insert into User_details values(" + admno.Text + ",'" + name.Text + "','" + textBox1.Text + "','" + mob.Text + "','" + mail.Text + "','"+usert.Text+"','"+pwd.Text+"',0)";
                    if (con.exec1(query1) > 0)
                    {
                        MessageBox.Show("User details Registered Successfully...");
                        this.Close();
                    }

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured....");

            }
        }

        private void Student_Registration_Load(object sender, EventArgs e)
        {
            studentid();
        }
    }
}

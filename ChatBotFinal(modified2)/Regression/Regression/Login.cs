﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Regression.Linear;

namespace ChatBot
{
    public partial class Login : Form
    {
        BaseConnection con=new BaseConnection();
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            //Student_Registration obj = new Student_Registration();
            //obj.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usertype = "";
            if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {
                Admin_Home obj = new Admin_Home();
                obj.Show();
            }
            else
            {
                MessageBox.Show("Invalid user.....");
                textBox1.Text = "";
                textBox2.Text = "";
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

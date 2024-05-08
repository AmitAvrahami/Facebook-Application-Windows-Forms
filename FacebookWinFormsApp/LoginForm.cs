﻿using FacebookWrapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public partial class LoginForm : Form
    {

        private sd m_AppSettings;
        private MainForm m_MainForm;
        public LoginForm()
        {
            InitializeComponent();
            FacebookWrapper.FacebookService.s_CollectionLimit = 25;
            m_AppSettings = new sd(893455099216824, new string[] { "email", "user_birthday", "user_friends" });
        }


        private void buttonLogin_clicked(object sender, EventArgs e)
        {
            if(sd.LoginResult == null)
            {
                m_AppSettings.Login();
                if (string.IsNullOrEmpty(sd.LoginResult.ErrorMessage))
                {
                    this.Hide();
                    m_MainForm = new MainForm();
                    m_MainForm.Show();                          
                }
            }

            
        }
    }
}

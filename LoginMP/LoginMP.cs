using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginMP
{
    public partial class LoginMP : Form
    {
        InputHandler iHandler;

        public LoginMP(InputHandler ih)
        {
            InitializeComponent();
            this.iHandler = ih;
        }

        private void uxLoginBtn_Click(object sender, EventArgs e)
        {
            String un = tbUserName.Text;
            String up = tbPassword.Text;
            Console.WriteLine(un + " " + up);
            iHandler(State.GOTPASSWORD, un + ":" + up);
        }

        /// <summary>
        /// THis method keepts the GUI controlls enabled/disabled, displaying the
        /// right information based on the App's satate.
        /// </summary>
        /// <param name="state"></param>
        public void DisplayState(State state)
        {
            switch (state)
            {
                case State.START:
                    lbStateMessage.Text = "Please Enter Username";
                    tbPassword.Enabled = false;
                    uxLoginBtn.Enabled = false;
                    break;
                case State.GOTUSERNAME:
                    lbStateMessage.Text = "Please Enter Password";
                    tbPassword.Enabled = true;
                    break;
                case State.GOTPASSWORD:
                    lbStateMessage.Text = "Validating Credentials...";
                    break;
                case State.DECLINED:
                    tbUserName.Text = "";
                    tbPassword.Text = "";
                    lbStateMessage.Text = "Sorry, Invalid Credentials";
                    break;
                case State.SUCCESS:
                    lbStateMessage.Text = "Congrats! You are Loggedin";
                    break;
                default:
                    lbStateMessage.Text = "Invalid State";
                    break;
            }
        }
    }
}

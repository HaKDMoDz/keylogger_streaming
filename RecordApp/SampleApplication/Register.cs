using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CAMCoF;


namespace SampleApplication
{
    public partial class Register : Form
    {
      

        public Register()
        {
            InitializeComponent();
            textBoxPassword.PasswordChar = '*';
            textBoxPasswordConfirm.PasswordChar = '*';


        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (fieldFillCheck() && passwordCheck())
            {
                userRecord();
               
               
                this.Close();
            }
            

        }

        private void userRecord()
        {
            string user = UsernameTextBox.Text;
            string pw = User.MD5password(textBoxPassword.Text);
            int age = Convert.ToInt32(AgetextBox.Text);
            string ocupation = OcupationtextBox.Text;



            User.record(user, pw, ocupation, age, gender());
            
        }

        private string gender()
        {
            if (maleRadioButton.Checked) return "male";
            else if (femaleRadioButton.Checked) return "female";
            else return "unknow";
        }

        private bool fieldFillCheck()
        {
           // Console.WriteLine((textBoxPassword.Text.Length >= 1 && AgetextBox.Text.Length >= 1 && UsernameTextBox.Text.Length >= 1 && OcupationtextBox.Text.Length >= 1 && (maleRadioButton.Checked == true || femaleRadioButton.Checked == true)));
            return (textBoxPassword.Text.Length >= 1 && AgetextBox.Text.Length >= 1 && UsernameTextBox.Text.Length >= 1 && OcupationtextBox.Text.Length >= 1 && (maleRadioButton.Checked == true || femaleRadioButton.Checked == true));
        }

        private bool passwordCheck()
        {
            //Console.WriteLine(textBoxPassword.Text.Equals(textBoxPasswordConfirm.Text));
            return   textBoxPassword.Text.Equals(textBoxPasswordConfirm.Text);
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        
    }
}

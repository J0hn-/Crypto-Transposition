using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crypto_Transposition_DedSec
{
    public partial class Transposition : Form
    {
        public Transposition()
        {
            InitializeComponent();
        }

        private void key_generate(object sender, EventArgs e)
        {
            if (!keyGen.Visible)
            {
                keyGen.Visible = true;
                cryptPicture.Visible = false;
                decryptPicture.Visible = false;
            }
        }

        private void crypt(object sender, EventArgs e)
        {
            if (!cryptPicture.Visible)
            {
                keyGen.Visible = false;
                cryptPicture.Visible = true;
                decryptPicture.Visible = false;
            } 
        }

        private void decrypt(object sender, EventArgs e)
        {
            if (!decryptPicture.Visible)
            {
                keyGen.Visible = false;
                cryptPicture.Visible = false;
                decryptPicture.Visible = true;
            }
        }

        private void checkEscape(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)27)
                Application.Exit();
        }
    }
}

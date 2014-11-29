using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crypto_Transposition_DedSec
{
    public partial class Transposition : Form
    {
        SoundPlayer snd = null;

        public Transposition()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void key_generate(object sender, EventArgs e)
        {
            Random random = new Random();
            if (!keyGen.Visible)
            {
                keyGen.Visible = true;
                cryptPicture.Visible = false;
                decryptPicture.Visible = false;
            }
            tb_key.Text = "";
            for (int i = 0; i < 10; ++i)
                tb_key.Text += (char)random.Next(65,90);
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

        private void charger(object sender, EventArgs e)
        {
            Stream str = Properties.Resources.mySoundFile;
            snd = new SoundPlayer(str);
            snd.Play();
            tb_crypt.Text = "";
            tb_decrypt.Text = "";
            tb_key.Text = "";
        }
    }
}

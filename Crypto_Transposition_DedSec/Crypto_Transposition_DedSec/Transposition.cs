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
            change_header(TypeHeader.KEYGEN);
            tb_key.Text = "";
            for (int i = 0; i < 10; ++i)
                tb_key.Text += (char)random.Next(65,90);
        }

        enum TypeHeader {CRYPT, DECRYPT, KEYGEN}

        private void change_header(TypeHeader type)
        {
            keyGen.Visible = (type == TypeHeader.KEYGEN ? true : false);
            cryptPicture.Visible = (type == TypeHeader.CRYPT ? true : false);
            decryptPicture.Visible = (type == TypeHeader.DECRYPT ? true : false);
        }

        private void crypt(object sender, EventArgs e)
        {
            if (tb_crypt.Text.Length == 0)
                MessageBox.Show("Rien à crypter !", "Noob !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (tb_key.Text.Length == 0)
                MessageBox.Show("Veuillez entrer ou générer une clef.", "Noob !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                change_header(TypeHeader.CRYPT);
                tb_decrypt.Text = Crypt.crypt(tb_crypt.Text, tb_key.Text);
            }

        }

        private void decrypt(object sender, EventArgs e)
        {
            if (tb_decrypt.Text.Length == 0)
                MessageBox.Show("Rien à décrypter !", "Noob !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (tb_key.Text.Length == 0)
                MessageBox.Show("Veuillez entrer ou générer une clef.", "Noob !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                change_header(TypeHeader.DECRYPT);
                tb_crypt.Text = Decrypt.decrypt(tb_decrypt.Text, tb_key.Text);
            }
        }

        private void charger(object sender, EventArgs e)
        {
            Stream str = Properties.Resources.mySoundFile;
            snd = new SoundPlayer(str);
            snd.PlayLooping();
            tb_crypt.Text = "";
            tb_decrypt.Text = "";
            tb_key.Text = "";
        }

        private void quit(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

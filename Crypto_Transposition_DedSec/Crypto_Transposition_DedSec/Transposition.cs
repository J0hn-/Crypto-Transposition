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
            header.Visible = !header.Visible;
        }

        private void crypt(object sender, EventArgs e)
        {

        }

        private void decrypt(object sender, EventArgs e)
        {

        }
    }
}

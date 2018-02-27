using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CertifikacijaBP2
{
    public partial class Glavna_pocetna : Form
    {
        public Glavna_pocetna()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 glavna_forma = new Form1();
            glavna_forma.ShowDialog();
        }

        private void testovibtn_Click(object sender, EventArgs e)
        {
            testovi testovi = new testovi();
            testovi.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Certifikati certifikati = new Certifikati();
            certifikati.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Rezultati rezultati = new Rezultati();
            rezultati.ShowDialog();
        }
    }
}

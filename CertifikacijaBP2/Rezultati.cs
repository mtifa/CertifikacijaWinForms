using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CertifikacijaBP2
{
    public partial class Rezultati : Form
    {
        
        static string connString = "";
        MySqlConnection conn = new MySqlConnection(connString);
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt = new DataTable();

        public Rezultati()
        {
            InitializeComponent();

            dataGridView1.ColumnCount = 7;
            dataGridView1.Columns[0].Name = "OIB";
            dataGridView1.Columns[1].Name = "Ime";
            dataGridView1.Columns[2].Name = "Prezime";
            dataGridView1.Columns[3].Name = "Datum polaganja";
            dataGridView1.Columns[4].Name = "Pokušaj";
            dataGridView1.Columns[5].Name = "Bodovi";
            dataGridView1.Columns[6].Name = "Tip polaganja";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            retrieve();
        }


        private void populate(String oib, String ime, String prezime, String datum_polaganja, String pokusaj, String bodovi, String tip_polaganja_id)
        {
            dataGridView1.Rows.Add(oib, ime, prezime, datum_polaganja, pokusaj, bodovi, tip_polaganja_id);
        }

        //otrkij iz baze
        private void retrieve()
        {
            dataGridView1.Rows.Clear();

            string sql = "SELECT polaznik.oib, polaznik.ime, polaznik.prezime, rezultat.datum_polaganja, rezultat.pokusaj, rezultat. bodovi, rezultat.tip_polaganja_id FROM polaznik JOIN rezultat ON rezultat.korisnik_polaznik_oib=polaznik.oib";
            cmd = new MySqlCommand(sql, conn);

            //otvoranje konekcije, otkrivanje, popunjavanje DataGridViewa
            try
            {
                conn.Open();

                adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
                //ponavljanje
                foreach (DataRow row in dt.Rows)
                {
                    populate(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString());

                }

                conn.Close();

                //ciscenje datatable
                dt.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string searchValue = textBox1.Text;

            try
            {
                
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[1].Value.ToString().Equals(searchValue))
                    {
                        row.Selected = true;
                        break;
                    }
                    
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}

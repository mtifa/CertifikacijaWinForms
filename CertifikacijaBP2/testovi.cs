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
    public partial class testovi : Form
    {
        static string connString = "";
        MySqlConnection conn = new MySqlConnection(connString);
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt = new DataTable();

        private int odabraniTip;

        public testovi()
        {
            InitializeComponent();

            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "Tekst";
            

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            PrikaziPitanja();

            dataGridView2.ColumnCount = 3;
            dataGridView2.Columns[0].Name = "ID";
            dataGridView2.Columns[1].Name = "Tekst";
            dataGridView2.Columns[2].Name = "Točno?";
            

            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;

            PrikaziOdgovore();
        }

        private void addpit (string tekst)
        {
            string sql = "INSERT INTO pitanje (tekst) VALUES (@tekst)";
            cmd = new MySqlCommand(sql, conn);

            //dodavanje parametara
            cmd.Parameters.AddWithValue("@tekst", tekst);

            //open conn and execute insert
            try
            {
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    clearTxts();
                    MessageBox.Show("Uspješno ste dodali novo pitanje!");
                }
                conn.Close();
                PrikaziPitanja();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        

        //brisanje iz baze
        private void delete(int id)
        {
            string sql = "DELETE FROM pitanje WHERE id=" + id + "";
            cmd = new MySqlCommand(sql, conn);

            //otvaranje konekcije, izvrsavanje brisanja, close kon
            try
            {
                conn.Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.DeleteCommand = conn.CreateCommand();
                adapter.DeleteCommand.CommandText = sql;

                if (MessageBox.Show("Jeste li sigurni da želite obrisati pitanje?", "BRISANJE!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        clearTxts();
                        MessageBox.Show("Uspješno ste izbrisali pitanje!");
                    }
                }
                conn.Close();

                PrikaziPitanja();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void clearTxts()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        public testovi(int tip)
        {
            InitializeComponent();
            odabraniTip = tip;
        }

        private void populate(String id, String tekst)
        {
            dataGridView1.Rows.Add(id, tekst);
        }

        private void PrikaziPitanja()
        {
            dataGridView1.Rows.Clear();

            string sql = "SELECT id, tekst FROM pitanje";
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
                    populate(row[0].ToString(), row[1].ToString());
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

        private void testovi_Load(object sender, EventArgs e)
        {
            //PrikaziPitanja();
        }

        private void populate2 (String id, String tekst, String tocno)
        {
            dataGridView2.Rows.Add(id, tekst, tocno);
        }

        private void PrikaziOdgovore()
        {
            dataGridView2.Rows.Clear();

            string sql = "SELECT id, tekst, tocno FROM odgovor";
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
                    populate2(row[0].ToString(), row[1].ToString(), row[2].ToString());
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

        private void addodg(string tekst, bool tocno)
        {
            string sql = "INSERT INTO odgovor (tekst, tocno) VALUES (@tekst, @tocno)";
            cmd = new MySqlCommand(sql, conn);

            //dodavanje parametara
            cmd.Parameters.AddWithValue("@tekst", tekst);
            cmd.Parameters.AddWithValue("@tocno", tocno);

            //open conn and execute insert
            try
            {
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    clearTxts();
                    MessageBox.Show("Uspješno ste dodali novo pitanje!");
                }
                conn.Close();
                PrikaziPitanja();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }



        //brisanje iz baze
        private void deleteodg(int id)
        {
            string sql = "DELETE FROM odgovor WHERE id=" + id + "";
            cmd = new MySqlCommand(sql, conn);

            //otvaranje konekcije, izvrsavanje brisanja, close kon
            try
            {
                conn.Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.DeleteCommand = conn.CreateCommand();
                adapter.DeleteCommand.CommandText = sql;

                if (MessageBox.Show("Jeste li sigurni da želite obrisati odgovor?", "BRISANJE!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        clearTxts();
                        MessageBox.Show("Uspješno ste izbrisali odgovor!");
                    }
                }
                conn.Close();

                PrikaziPitanja();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void odustanibtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dodajbtn_Click(object sender, EventArgs e)
        {
            addpit(textBox1.Text);
            
        }


        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void izbrisibtn_Click(object sender, EventArgs e)
        {
            String selected = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int id = Convert.ToInt32(selected);

            delete(id);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addpit(textBox1.Text);
        }

        private void dodajbtn2_Click(object sender, EventArgs e)
        {
            //addodg(textBox2.Text);
        }

        private void izbrisibtn2_Click(object sender, EventArgs e)
        {
            String selected = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int id = Convert.ToInt32(selected);

            deleteodg(id);
        }
    }
}

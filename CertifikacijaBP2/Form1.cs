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
    public partial class Form1 : Form
    {
        static string connString = "Server=moops.ddns.net;Port=3306;Database=mijomysql;Uid=mijo;Pwd=vpvpilj32";
        MySqlConnection conn = new MySqlConnection(connString);
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt = new DataTable();
        public Form1()
        {
            InitializeComponent();

            dataGridView3.ColumnCount = 7;
            dataGridView3.Columns[0].Name = "OIB";
            dataGridView3.Columns[1].Name = "Ime";
            dataGridView3.Columns[2].Name = "Prezime";
            dataGridView3.Columns[3].Name = "Datum rođenja";
            dataGridView3.Columns[4].Name = "Adresa";
            dataGridView3.Columns[5].Name = "Telefon";
            dataGridView3.Columns[6].Name = "E-mail";
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.MultiSelect = false;

            retrieve();
        }

        //Insert into DB
        private void add(string ime, string prezime, string datum_rodjenja, string adresa, string telefon, string email)
        {
            string sql = "INSERT INTO polaznik (ime, prezime, datum_rodjenja, adresa, telefon, email) VALUES (@ime, @prezime, @datum_rodjenja, @adresa, @telefon, @email)";
            cmd = new MySqlCommand(sql, conn);

            //dodavanje parametara
            cmd.Parameters.AddWithValue("@ime", ime);
            cmd.Parameters.AddWithValue("@prezime", prezime);
            cmd.Parameters.AddWithValue("@datum_rodjenja", datum_rodjenja);
            cmd.Parameters.AddWithValue("@adresa", adresa);
            cmd.Parameters.AddWithValue("@telefon", telefon);
            cmd.Parameters.AddWithValue("@email", email);

            //open conn and execute insert
            try
            {
                conn.Open();
                if(cmd.ExecuteNonQuery()>0)
                {
                    clearTxts();
                    MessageBox.Show("Uspješno ste dodali novog polaznika");
                }
                conn.Close();
                retrieve();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
            
        }

        //dodavanje u datagridview
        private void populate(String oib, String ime, String prezime, String datum_rodjenja, String adresa, String telefon, String email)
        {
            dataGridView3.Rows.Add(oib, ime, prezime, datum_rodjenja, adresa, telefon, email);
        }

        //otrkij iz baze
        private void retrieve()
        {
            dataGridView3.Rows.Clear();

            string sql = "SELECT * FROM polaznik";
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

        //azuriranje baze
        private void update(int oib, string ime, string prezime, string datum_rodjenja, string adresa, string telefon, string email)
        {
            string sql = "UPDATE polaznik SET ime='" + ime + "',prezime='" + prezime + "',datum_rodjenja='" + datum_rodjenja + "',adresa='" + adresa + "',telefon='" + telefon + "',email='" + email + "' WHERE oib=" + oib + "";
            cmd = new MySqlCommand(sql, conn);
            //otvaranje konekcije, azuriranje, retrieve dgview
            try {
                conn.Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.UpdateCommand = conn.CreateCommand();
                adapter.UpdateCommand.CommandText = sql;

                if(adapter.UpdateCommand.ExecuteNonQuery()>0)
                {
                    clearTxts();
                    MessageBox.Show("Uspješno ste ažurirali tablicu polaznika!");
                }
                conn.Close();
                retrieve();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
        
        //brisanje iz baze
        private void delete (int oib)
        {
            string sql = "DELETE FROM polaznik WHERE oib=" + oib + "";
            cmd = new MySqlCommand(sql, conn);

            //otvaranje konekcije, izvrsavanje brisanja, close kon
            try
            {
                conn.Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.DeleteCommand = conn.CreateCommand();
                adapter.DeleteCommand.CommandText = sql;

                if(MessageBox.Show("Jeste li sigurni da želite obrisati korisnika?", "BRISANJE!", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.OK)
                {
                    if(cmd.ExecuteNonQuery()>0)
                    {
                        clearTxts();
                        MessageBox.Show("Uspješno ste izbrisali polaznika");
                    }
                }
                conn.Close();

                retrieve();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        //brisanje txtbox
        private void clearTxts()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            //glupost
        }
        private void dataGridView3_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView3.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView3.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView3.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = dataGridView3.SelectedRows[0].Cells[4].Value.ToString();
            textBox5.Text = dataGridView3.SelectedRows[0].Cells[5].Value.ToString();
            textBox6.Text = dataGridView3.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            add(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            retrieve();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            String selected = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
            int oib = Convert.ToInt32(selected);
            update(oib, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            String selected = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
            int oib = Convert.ToInt32(selected);

            delete(oib);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
        }
    }
}

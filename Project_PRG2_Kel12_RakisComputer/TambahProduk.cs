using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Project_PRG2_Kel12_RakisComputer
{
    public partial class TambahProduk : Form
    {
        public TambahProduk()
        {
            InitializeComponent();
        }
        SqlCommand sqlCmd;
        SqlConnection sqlCon;
        static string connectionString = @"Data Source=LAPTOP-ALDVS5GI;Initial Catalog=db_Rakis_computerr;Integrated Security=True";

        public string AutogenerateID()
        {
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);
                int autoid = 0;
                string kode = null;
                con.Open();
                string sqlQuery = "SELECT TOP (1) MAX(RIGHT (Id_produk,2))+1 AS Id_produk FROM  Produk";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr["Id_produk"].ToString() == "")
                    {
                        autoid = 1;
                    }
                    else
                    {
                        autoid = Int32.Parse(dr["Id_produk"].ToString());
                    }
                }

                if (autoid < 10)
                {
                    kode = "PRD0" + autoid;
                }
                else if (autoid < 100)
                {
                    kode = "PRD" + autoid;
                }

                con.Close();

                return kode;
            }
        }

        public double split(String x)
        {
            String[] a = x.Split('.');
            //String[] b = a[1].Split('.');
            //String[] c = b[1].Split(',');
            String Total = a[0];
            double total = Double.Parse(separate(Total));

            return total;
        }

        public String separate(String a)
        {
            string[] test = a.Split(',');
            string x = "";
            foreach (string tst in test)
            {
                if (tst.Trim() != "")
                {
                    x = x + tst;
                    Console.Write(tst);
                }
            }
            return x;
        }

        private void clear()
        {
            txtNama.Clear();
            txtHarga.Clear();
            txtStock.Clear();
            txtDeskripsi.Clear();
            cmbJenisProduk.Text = "";
        }
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (txtNama.Text == "" || txtHarga.Text == "" || cmbJenisProduk.Text == "" || txtStock.Text == "" || txtDeskripsi.Text == "")
            {
                MessageBox.Show("Isi seluruh data terlebih dahulu!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
            }
            else
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);

                SqlCommand insert = new SqlCommand("sp_InsertProduk", con);
                insert.CommandType = CommandType.StoredProcedure;

                double harga = split(txtHarga.Text);

                insert.Parameters.AddWithValue("Id_produk", AutogenerateID());
                insert.Parameters.AddWithValue("nama_produk", txtNama.Text);
                insert.Parameters.AddWithValue("Id_JenisProduk", cmbJenisProduk.SelectedValue);
                insert.Parameters.AddWithValue("jumlah", txtStock.Text);
                insert.Parameters.AddWithValue("harga", harga);
                insert.Parameters.AddWithValue("deskripsi", txtDeskripsi.Text);

                try
                {
                    con.Open();
                    insert.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil disimpan", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menyimpan: " + ex.Message);
                }
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            clear();


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TambahProduk_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'db_Rakis_computerrDataSet.JenisProduk' table. You can move, or remove it, as needed.
            this.jenisProdukTableAdapter.Fill(this.db_Rakis_computerrDataSet.JenisProduk);
            // TODO: This line of code loads data into the 'db_Rakis_computerrDataSet.Produk' table. You can move, or remove it, as needed.
            this.produkTableAdapter.Fill(this.db_Rakis_computerrDataSet.Produk);
            // TODO: This line of code loads data into the 'db_Rakis_computerrDataSet.JenisProduk' table. You can move, or remove it, as needed.
            this.jenisProdukTableAdapter.Fill(this.db_Rakis_computerrDataSet.JenisProduk);

        }

        private void txtNama_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtHarga_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNama_Leave(object sender, EventArgs e)
        {
            if (txtNama.Text == "")
            {
                epCorrect.SetError(txtNama, "");
                epError.SetError(txtNama, "Kolom harus diisi!");
            }
            else
            {
                epCorrect.SetError(txtNama, "Benar");
                epError.SetError(txtNama, "");
            }
        }

        private void txtDeskripsi_Leave(object sender, EventArgs e)
        {
            if (txtDeskripsi.Text == "")
            {
                epCorrect.SetError(txtDeskripsi, "");
                epError.SetError(txtDeskripsi, "Kolom harus diisi!");
            }
            else
            {
                epCorrect.SetError(txtDeskripsi, "Benar");
                epError.SetError(txtDeskripsi, "");
            }
        }

        private void txtHarga_TextChanged(object sender, EventArgs e)
        {
            if (txtHarga.Text == "")
            {
                return;
            }
            else
            {
                txtHarga.Text = string.Format("{0:n0}", double.Parse(txtHarga.Text));
                txtHarga.SelectionStart = txtHarga.Text.Length;
            }
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }

}

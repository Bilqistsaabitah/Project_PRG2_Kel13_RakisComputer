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
    public partial class TambahPaket : Form
    {
        public TambahPaket()
        {
            InitializeComponent();
           
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

        public string autogenerateID()
        {
            { 
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);
                int autoid = 0;
                string kode = null;
                con.Open();
                string sqlQuery = "SELECT TOP (1) MAX(RIGHT (Id_Paket,2))+1 AS Id_Paket FROM Paket";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr["Id_Paket"].ToString() == "")
                    {
                        autoid = 1;
                    }
                    else
                    {
                        autoid = Int32.Parse(dr["Id_Paket"].ToString());
                    }
                }

                if (autoid < 10)
                {
                    kode = "PKT0" + autoid;
                }
                else if (autoid < 100)
                {
                    kode = "PKT" + autoid;
                }

                con.Close();

                return kode;
            }
        }

    
        private void clear()
        {
            txtDeskripsi.Clear();
            txtHarga.Clear();
            txtStock.Clear();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (txtStock.Text == "" || txtDeskripsi.Text == "" || txtHarga.Text == "" )
            {
                MessageBox.Show("Isi seluruh data terlebih dahulu!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);

            SqlCommand insert = new SqlCommand("sp_InsertPaket", con);
            insert.CommandType = CommandType.StoredProcedure;


                insert.Parameters.AddWithValue("Id_Paket",autogenerateID());
                insert.Parameters.AddWithValue("harga", txtHarga.Text);
                insert.Parameters.AddWithValue("stok", txtStock.Text);
                insert.Parameters.AddWithValue("Deskripsi", txtDeskripsi.Text);
   


                try
                {
                    con.Open();
                    insert.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil disimpan.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            this.clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtStock_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDeskripsi_TextChanged(object sender, EventArgs e)
        {

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

        private void txtHarga_Leave(object sender, EventArgs e)
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

        private void TambahPaket_Load(object sender, EventArgs e)
        {

        }
    }
}


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
    public partial class TambahDistributor : Form
    {
        public TambahDistributor()
        {
            InitializeComponent();
        }
        
        public string AutogenerateID()
        {
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);
                int autoid = 0;
                string kode = null;
                con.Open();
                string sqlQuery = "SELECT TOP (1) MAX(RIGHT (Id_Distributor,2))+1 AS Id_Distributor FROM Distributor";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr["Id_Distributor"].ToString() == "")
                    {
                        autoid = 1;
                    }
                    else
                    {
                        autoid = Int32.Parse(dr["Id_Distributor"].ToString());
                    }
                }

                if (autoid < 10)
                {
                    kode = "DST0" + autoid;
                }
                else if (autoid < 100)
                {
                    kode = "DST" + autoid;
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
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (txtNama.Text == "" || txtTelepon.Text == "" || txtEmail.Text == "" || txtAlamat.Text == "")
            {
                MessageBox.Show("Isi seluruh data terlebih dahulu!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
            }
            else
            {

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);

                SqlCommand insert = new SqlCommand("sp_InsertDistributor", con);
                insert.CommandType = CommandType.StoredProcedure;


                //double harga = split(txtHarga.Text);

                insert.Parameters.AddWithValue("Id_Distributor", AutogenerateID());
                insert.Parameters.AddWithValue("Nama", txtNama.Text);
                insert.Parameters.AddWithValue("Alamat", txtAlamat.Text);
                insert.Parameters.AddWithValue("no_hp", txtTelepon.Text);
                insert.Parameters.AddWithValue("email", txtEmail.Text);

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
            private void clear()
            {
                txtNama.Clear();
                txtAlamat.Clear();
                txtTelepon.Clear();
                txtEmail.Clear();
            
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void txtAlamat_Leave(object sender, EventArgs e)
        {
            if (txtAlamat.Text == "")
            {
                epCorrect.SetError(txtAlamat, "");
                epError.SetError(txtAlamat, "Kolom harus diisi!");
            }
            else
            {
                epCorrect.SetError(txtAlamat, "Benar");
                epError.SetError(txtAlamat, "");
            }
        }

        private void txtTelepon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {

            if (txtEmail.Text == "")
            {
                epCorrect.SetError(txtEmail, "");
                epError.SetError(txtEmail, "Kolom harus diisi!");
            }
            else
            {
                epCorrect.SetError(txtEmail, "Benar");
                epError.SetError(txtEmail, "");
            }
        }
    }
}

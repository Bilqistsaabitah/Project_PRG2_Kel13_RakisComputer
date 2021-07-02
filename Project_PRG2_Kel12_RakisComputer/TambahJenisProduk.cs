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
    public partial class TambahJenisProduk : Form
    {
        public TambahJenisProduk()
        {
            InitializeComponent();
            
            txtID.Text = autogenerateID();
        }
      
        public string autogenerateID()
        {
            { 
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);
            int autoid = 0;
            string kode = null;
            con.Open();
            string sqlQuery = "SELECT TOP (1) MAX(RIGHT (Id_JenisProduk,2))+1 AS Id_JenisProduk FROM JenisProduk";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (dr["Id_JenisProduk"].ToString() == "")
                {
                    autoid = 1;
                }
                else
                {
                    autoid = Int32.Parse(dr["Id_JenisProduk"].ToString());
                }
            }

            if (autoid < 10)
            {
                kode = "JP0" + autoid;
            }
            else if (autoid < 100)
            {
                kode = "JP" + autoid;
            }

            con.Close();

            return kode;
        }

    }

        private void clear()
        {
            txtID.Clear();
            txtDeskripsi.Clear();
           



        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
           

            if (txtID.Text == "" || txtDeskripsi.Text == "")
            {
                MessageBox.Show("Isi seluruh data terlebih dahulu!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);

                SqlCommand insert = new SqlCommand("sp_InsertJenisProduk", con);
                insert.CommandType = CommandType.StoredProcedure;


                insert.Parameters.AddWithValue("Id_JenisProduk", autogenerateID());
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

        private void txtDeskripsi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            clear();
            txtID.Enabled = true;
            txtDeskripsi.Enabled = false;
        }

        private void TambahJenisProduk_Load(object sender, EventArgs e)
        {
            txtID.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


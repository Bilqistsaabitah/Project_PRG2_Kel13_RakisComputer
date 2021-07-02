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
    public partial class TambahService : Form
    {
        public TambahService()
        {
            InitializeComponent();
        }
     
        public string autogenerateID()
        {
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);
                int autoid = 0;
                string kode = null;
                con.Open();
                string sqlQuery = "SELECT TOP (1) MAX(RIGHT (Id_Service,2))+1 AS Id_Service FROM Service";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr["Id_Service"].ToString() == "")
                    {
                        autoid = 1;
                    }
                    else
                    {
                        autoid = Int32.Parse(dr["Id_Service"].ToString());
                    }
                }

                if (autoid < 10)
                {
                    kode = "SRV0" + autoid;
                }
                else if (autoid < 100)
                {
                    kode = "SRV" + autoid;
                }

                con.Close();

                return kode;
            }
        }

        private void clear()
        {
            txtNama.Clear();
            txtDeskripsi.Clear();
            

        }
        private void btnSimpan_Click(object sender, EventArgs e)
        {
           
            

            if (txtNama.Text == "" || txtDeskripsi.Text == "" )
            {
                MessageBox.Show("Isi seluruh data terlebih dahulu!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {



                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);

                SqlCommand insert = new SqlCommand("sp_InsertService", con);
                insert.CommandType = CommandType.StoredProcedure;

                insert.Parameters.AddWithValue("Id_Service", autogenerateID());
                insert.Parameters.AddWithValue("nama", txtNama.Text);
                insert.Parameters.AddWithValue("Deskripsi", txtDeskripsi.Text);
                insert.Parameters.AddWithValue("tgl_Service", dtTglService.Value);
                
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
                    MessageBox.Show("Gagal menyimpan: " + ex.ToString());
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

        private void txtNama_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dtTglService_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dtTglService.Text == "")
            {
                epCorrect.SetError(dtTglService, "");
                epError.SetError(dtTglService, "Kolom harus diisi!");
            }
            else
            {
                epCorrect.SetError(dtTglService, "Benar");
                epError.SetError(dtTglService, "");
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
    }
}

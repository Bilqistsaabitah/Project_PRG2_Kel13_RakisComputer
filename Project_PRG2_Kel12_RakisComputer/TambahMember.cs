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
    public partial class TambahMember : Form
    {
        public TambahMember()
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
                string sqlQuery = "SELECT TOP (1) MAX(RIGHT (Id_Member,2))+1 AS Id_Member FROM Member";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr["Id_Member"].ToString() == "")
                    {
                        autoid = 1;
                    }
                    else
                    {
                        autoid = Int32.Parse(dr["Id_Member"].ToString());
                    }
                }

                if (autoid < 10)
                {
                    kode = "MBR0" + autoid;
                }
                else if (autoid < 100)
                {
                    kode = "MBR" + autoid;
                }

                con.Close();

                return kode;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtPoint_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            {
                if (txtNama.Text == "" || txtTelepon.Text == "" || txtAlamat.Text == "" || txtPoint.Text == "")
                {
                    MessageBox.Show("Isi seluruh data terlebih dahulu!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                }
                else
                {

                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);

                    SqlCommand insert = new SqlCommand("sp_InsertMember", con);
                    insert.CommandType = CommandType.StoredProcedure;

                   

                    insert.Parameters.AddWithValue("Id_Member", AutogenerateID());
                    insert.Parameters.AddWithValue("Nama_Member", txtNama.Text);
                    insert.Parameters.AddWithValue("no_telp", txtTelepon.Text);
                    insert.Parameters.AddWithValue("Alamat", txtAlamat.Text);
                    insert.Parameters.AddWithValue("poin", txtPoint.Text);

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
        }

        private void clear()
        {
            txtNama.Clear();
            txtTelepon.Clear();
            txtAlamat.Clear();
            txtPoint.Clear();
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

        private void txtTelepon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPoint_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

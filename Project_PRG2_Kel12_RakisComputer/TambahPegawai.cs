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
    public partial class TambahPegawai : Form
    {
        public TambahPegawai()
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
                string sqlQuery = "SELECT TOP (1) MAX(RIGHT (Id_Pegawai,2))+1 AS Id_Pegawai FROM Pegawai";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr["Id_Pegawai"].ToString() == "")
                    {
                        autoid = 1;
                    }
                    else
                    {
                        autoid = Int32.Parse(dr["Id_Pegawai"].ToString());
                    }
                }

                if (autoid < 10)
                {
                    kode = "USR0" + autoid;
                }
                else if (autoid < 100)
                {
                    kode = "USR" + autoid;
                }

                con.Close();

                return kode;
            }
        }

        private void clear()
        {
            txtNama.Clear();
            txtAlamat.Clear();
            txtNamaAkun.Clear();
            txtKataSandi.Clear();
            txtTelepon.Clear();
            textPassword2.Clear();
            cmbRole.SelectedItem = "";
            rbLaki.Checked = false;
            rbPerempuan.Checked = false;

        }
       

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            
            string jenis = "";

            if (txtNama.Text == "" || dtTglLahir.Text == "" || txtTelepon.Text == "" || txtAlamat.Text == "" || txtNamaAkun.Text == "" || txtKataSandi.Text == "" || txtKataSandi.Text != textPassword2.Text || (rbLaki.Checked == false && rbPerempuan.Checked == false))
            {
                MessageBox.Show("Isi seluruh data terlebih dahulu!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                if (rbLaki.Checked == true)
                {
                    jenis = "Laki-Laki";
                }
                else if (rbPerempuan.Checked == true)
                {
                    jenis = "Perempuan";
                }

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);

                SqlCommand insert = new SqlCommand("sp_InsertPegawai", con);
                insert.CommandType = CommandType.StoredProcedure;

                

                insert.Parameters.AddWithValue("Id_Pegawai", autogenerateID());
                insert.Parameters.AddWithValue("Nama", txtNama.Text);
                insert.Parameters.AddWithValue("jns_kelamin", jenis);
                insert.Parameters.AddWithValue("tgl_lahir", dtTglLahir.Value);
                insert.Parameters.AddWithValue("alamat", txtAlamat.Text);
                insert.Parameters.AddWithValue("no_hp", txtTelepon.Text);
                insert.Parameters.AddWithValue("nama_akun", txtNamaAkun.Text);
                insert.Parameters.AddWithValue("kata_sandi", txtKataSandi.Text);
                insert.Parameters.AddWithValue("role_pegawai", cmbRole.SelectedItem);


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

        private void txtTelepon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dtTglLahir_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void dtTglLahir_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dtTglLahir.Text == "")
            {
                epCorrect.SetError(dtTglLahir, "");
                epError.SetError(dtTglLahir, "Kolom harus diisi!");
            }
            else
            {
                epCorrect.SetError(dtTglLahir, "Benar");
                epError.SetError(dtTglLahir, "");
            }
        }

        private void txtTelepon_Leave(object sender, EventArgs e)
        {
            if (txtTelepon.Text == "")
            {
                epCorrect.SetError(txtTelepon, "");
                epError.SetError(txtTelepon, "Kolom harus diisi!");
            }
            else
            {
                epCorrect.SetError(txtTelepon, "Benar");
                epError.SetError(txtTelepon, "");
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

        private void txtNamaAkun_Leave(object sender, EventArgs e)
        {
            if (txtNamaAkun.Text == "")
            {
                epCorrect.SetError(txtNamaAkun, "");
                epError.SetError(txtNamaAkun, "Kolom harus diisi!");
            }
            else
            {
                epCorrect.SetError(txtNamaAkun, "Benar");
                epError.SetError(txtNamaAkun, "");
            }
        }

        private void txtKataSandi_Leave(object sender, EventArgs e)
        {
            if (txtKataSandi.Text == "")
            {
                epCorrect.SetError(txtKataSandi, "");
                epError.SetError(txtKataSandi, "Kolom harus diisi!");
            }
            else
            {
                epCorrect.SetError(txtKataSandi, "Benar");
                epError.SetError(txtKataSandi, "");
            }
        }

        private void textPassword2_Leave(object sender, EventArgs e)
        {

            if (textPassword2.Text != txtKataSandi.Text)
            {
                epCorrect.SetError(textPassword2, "");
                epError.SetError(textPassword2, "Kata sandi tidak sesuai!");
            }
            else
            {
                epCorrect.SetError(textPassword2, "Benar");
                epError.SetError(textPassword2, "");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.clear();
        }
    }
}

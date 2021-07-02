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

namespace Project_PRG2_Kel12_RakisComputer
{
    public partial class UbahPegawai : Form
    {
        public UbahPegawai()
        {
            InitializeComponent();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            clear();
            txtID.Enabled = true;
            txtNama.Enabled = false;
            txtAlamat.Enabled = false;
            txtTelepon.Enabled = false;
            cmbNamaAkun.Enabled = false;
            txtKataSandi.Enabled = false;
            dtTglLahir.Enabled = false;
            rbLaki.Enabled = false;
            rbPerempuan.Enabled = false;

            btnBatal.Enabled = false;
            btnUbah.Enabled = false;
            btnHapus.Enabled = false;
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Masukkan ID terlebih dahulu!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            try
            {
                if (!string.IsNullOrEmpty(txtID.Text.Trim()))
                {
                    using (SqlConnection sqlConn = new SqlConnection("integrated security = true; data source =.; initial catalog = db_Rakis_computerr"))
                    {
                        using (SqlCommand sqlCmd = new SqlCommand("sp_CariPegawai", sqlConn))
                        {
                            sqlConn.Open();
                            sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                            sqlCmd.Parameters.AddWithValue("Id_Pegawai", txtID.Text.Trim());

                            SqlDataReader reader = sqlCmd.ExecuteReader();
                            if (reader.HasRows)
                            {
                                reader.Read();
                                txtNama.SelectedText = Convert.ToString(reader["Nama"]);
                                txtAlamat.SelectedText = Convert.ToString(reader["alamat"]);
                                txtTelepon.SelectedText = Convert.ToString(reader["no_hp"]);
                                cmbNamaAkun.SelectedItem = Convert.ToString(reader["nama_akun"]);
                                txtKataSandi.SelectedText = Convert.ToString(reader["kata_sandi"]);
                                dtTglLahir.Text = Convert.ToString(reader["tgl_lahir"]);
                                string jenis = Convert.ToString(reader["jns_kelamin"]);
                                if (jenis == "Perempuan")
                                {
                                    rbPerempuan.Checked = true;
                                }
                                else
                                {
                                    rbLaki.Checked = true;
                                }

                                txtID.Enabled = false;
                                txtNama.Enabled = true;
                                txtAlamat.Enabled = true;
                                txtTelepon.Enabled = true;
                                cmbNamaAkun.Enabled = true;
                                // txtKataSandi.Enabled = true;
                                dtTglLahir.Enabled = true;
                                rbLaki.Enabled = true;
                                rbPerempuan.Enabled = true;

                                btnBatal.Enabled = true;
                                btnUbah.Enabled = true;
                                btnHapus.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show("Data dengan ID tersebut tidak ditemukan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            sqlConn.Close();
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            string jenis = "";

            if (txtID.Text == "" || txtNama.Text == "" || dtTglLahir.Text == "" || txtTelepon.Text == "" || txtAlamat.Text == "" || cmbNamaAkun.SelectedIndex == -1 || txtKataSandi.Text == "")
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

                string connectionstring = "integrated security = true; data source =.; initial catalog = db_Rakis_computerr";
                SqlConnection connection = new SqlConnection(connectionstring);

                SqlCommand update = new SqlCommand("sp_UpdatePegawai", connection);
                update.CommandType = CommandType.StoredProcedure;

                update.Parameters.AddWithValue("Id_Pegawai", txtID.Text);
                update.Parameters.AddWithValue("Nama", txtNama.Text);
                update.Parameters.AddWithValue("jns_kelamin", jenis);
                update.Parameters.AddWithValue("tgl_lahir", dtTglLahir.Value.ToString("yyyy-MM-dd"));
                update.Parameters.AddWithValue("alamat", txtAlamat.Text);
                update.Parameters.AddWithValue("no_hp", txtTelepon.Text);
                update.Parameters.AddWithValue("nama_akun", cmbNamaAkun.SelectedItem);
                update.Parameters.AddWithValue("kata_sandi", txtKataSandi.Text);
                update.Parameters.AddWithValue("role_pegawai", cmbNamaAkun.SelectedItem);

                try
                {
                    connection.Open();
                    update.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil disimpan", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                    txtID.Enabled = true;
                    txtNama.Enabled = false;
                    txtAlamat.Enabled = false;
                    txtTelepon.Enabled = false;
                    cmbNamaAkun.Enabled = false;
                    txtKataSandi.Enabled = false;
                    dtTglLahir.Enabled = false;
                    rbLaki.Enabled = false;
                    rbPerempuan.Enabled = false;

                    btnBatal.Enabled = false;
                    btnUbah.Enabled = false;
                    btnHapus.Enabled = false;

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data tidak dapat disimpan: " + ex.Message);
                }

            }
        }
    

        private void btnHapus_Click(object sender, EventArgs e)
        {
            string msg = "Apakah anda yakin ingin menghapus data ini?";
            string title = "Peringatan";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(msg, title, buttons, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string connectionstring = "integrated security = true; data source =.; initial catalog = db_Rakis_computerr";
                SqlConnection connection = new SqlConnection(connectionstring);

                try
                {
                    connection.Open();
                    SqlCommand update = new SqlCommand("sp_DeletePegawai", connection);
                    update.CommandType = CommandType.StoredProcedure;

                    update.Parameters.AddWithValue("Id_Pegawai", txtID.Text);
                    update.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil dihapus", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data tidak dapat dihapus: " + ex.Message);
                }
                clear();
                txtID.Enabled = true;
                txtNama.Enabled = false;
                txtAlamat.Enabled = false;
                txtTelepon.Enabled = false;
                cmbNamaAkun.Enabled = false;
                txtKataSandi.Enabled = false;
                dtTglLahir.Enabled = false;
                rbLaki.Enabled = false;
                rbPerempuan.Enabled = false;

                btnBatal.Enabled = false;
                btnUbah.Enabled = false;
                btnHapus.Enabled = false;

                this.Close();
            }
            else
            {

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

        private void dtTglLahir_Leave(object sender, EventArgs e)
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

        private void txtTelepon_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNama_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void clear()
        {
            txtID.Clear();
            txtNama.Clear();
            txtAlamat.Clear();
            cmbNamaAkun.SelectedIndex = -1;
            txtKataSandi.Clear();
            txtTelepon.Clear();
            rbLaki.Checked = false;
            rbPerempuan.Checked = false;

        }
    }
}

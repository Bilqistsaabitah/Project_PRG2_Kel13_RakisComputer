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
    public partial class UbahDistributor : Form
    {
        public UbahDistributor()
        {
            InitializeComponent();
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
                    using (SqlConnection sqlConn = new SqlConnection(@"Data Source=LAPTOP-ALDVS5GI;Initial Catalog=db_Rakis_computerr;Integrated Security=True;"))

                    using (SqlCommand sqlCmd = new SqlCommand("sp_CariDistributor", sqlConn))
                    {
                        sqlConn.Open();
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("Id_Distributor", txtID.Text.Trim());

                        SqlDataReader reader = sqlCmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            reader.Read();
                            // double num1 = Convert.ToDouble(reader["harga"]);
                            //string res2 = string.Format("{0:n0}", num1);

                            txtNama.SelectedText = Convert.ToString(reader["Nama"]);
                            txtTelepon.SelectedText = Convert.ToString(reader["no_hp"]);
                            txtEmail.SelectedText = Convert.ToString(reader["email"]);
                            txtAlamat.SelectedText = Convert.ToString(reader["alamat"]);


                            txtID.Enabled = false;
                            txtNama.Enabled = true;
                            txtTelepon.Enabled = true;
                            txtEmail.Enabled = true;
                            txtAlamat.Enabled = true;

                            btnBatal.Enabled = true;
                            btnHapus.Enabled = true;
                            btnUbah.Enabled = true;

                        }
                        else
                        {
                            MessageBox.Show("Data dengan ID tersebut tidak ditemukan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        sqlConn.Close();
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
            if (txtID.Text == "" || txtNama.Text == "" || txtTelepon.Text == "" || txtEmail.Text == "" || txtAlamat.Text == "")
            {
                MessageBox.Show("Isi seluruh data terlebih dahulu!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                string connectionstring = (@"Data Source=LAPTOP-ALDVS5GI;Initial Catalog=db_Rakis_computerr;Integrated Security=True");
                SqlConnection connection = new SqlConnection(connectionstring);

                SqlCommand update = new SqlCommand("sp_UpdateDistributor", connection);
                update.CommandType = CommandType.StoredProcedure;

                update.Parameters.AddWithValue("Id_Distributor", txtID.Text);
                update.Parameters.AddWithValue("Nama", txtNama.Text);
                update.Parameters.AddWithValue("no_hp", txtTelepon.Text);
                update.Parameters.AddWithValue("email", txtEmail.Text);
                update.Parameters.AddWithValue("alamat", txtAlamat.Text);

                try
                {
                    connection.Open();
                    update.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil disimpan", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear(); this.Close();

                    txtID.Enabled = true;
                    txtNama.Enabled = false;
                    txtTelepon.Enabled = false;
                    txtEmail.Enabled = false;
                    txtAlamat.Enabled = false;

                    btnBatal.Enabled = false;
                    btnHapus.Enabled = false;
                    btnUbah.Enabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data tidak dapat disimpan: " + ex.Message);
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
            clear();
            txtID.Enabled = true;
            txtNama.Enabled = false;
            txtTelepon.Enabled = false;
            txtEmail.Enabled = false;
            txtAlamat.Enabled = false;

            btnBatal.Enabled = false;
            btnHapus.Enabled = false;
            btnUbah.Enabled = false;
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            string msg = "Apakah anda yakin ingin menghapus data ini?";
            string title = "Peringatan";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(msg, title, buttons, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string connectionstring = (@"Data Source=LAPTOP-ALDVS5GI;Initial Catalog=db_Rakis_computerr;Integrated Security=True");
                SqlConnection connection = new SqlConnection(connectionstring);

                try
                {
                    connection.Open();
                    SqlCommand delete = new SqlCommand("sp_DeleteDistributor", connection);
                    delete.CommandType = CommandType.StoredProcedure;

                    delete.Parameters.AddWithValue("Id_Distributor", txtID.Text); ;
                    delete.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil dihapus", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data tidak dapat dihapus: " + ex.Message);
                }
                clear(); this.Close();
                txtID.Enabled = true;
                txtNama.Enabled = false;
                txtTelepon.Enabled = false;
                txtEmail.Enabled = false;
                txtAlamat.Enabled = false;

                btnBatal.Enabled = false;
                btnHapus.Enabled = true;
                btnUbah.Enabled = false;

            }
            else
            {

            }
        }

        private void txtTelepon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
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
    }
}


 


    


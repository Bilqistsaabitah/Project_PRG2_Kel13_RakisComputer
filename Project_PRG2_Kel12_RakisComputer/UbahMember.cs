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
    public partial class UbahMember : Form
    {
        public UbahMember()
        {
            InitializeComponent();
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {


            if (txtID.Text == "" || txtNama.Text == "" || txtTelepon.Text == "" || txtPoint.Text == "" || txtAlamat.Text == "")
            {
                MessageBox.Show("Isi seluruh data terlebih dahulu!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                string connectionstring = "integrated security = true; data source =.; initial catalog = db_Rakis_computerr";
                SqlConnection connection = new SqlConnection(connectionstring);

                SqlCommand update = new SqlCommand("sp_UpdateMember", connection);
                update.CommandType = CommandType.StoredProcedure;

                update.Parameters.AddWithValue("Id_Member", txtID.Text);
                update.Parameters.AddWithValue("Nama_Member", txtNama.Text);
                update.Parameters.AddWithValue("no_telp", txtTelepon.Text);
                update.Parameters.AddWithValue("poin", txtPoint.Text);
                update.Parameters.AddWithValue("Alamat", txtAlamat.Text);
               
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
                    txtPoint.Enabled = false;
                   
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

            private void clear()
        {
            txtID.Clear();
            txtNama.Clear();
            txtTelepon.Clear();
            txtPoint.Text = "";
            txtAlamat.Clear();
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
                    SqlCommand delete = new SqlCommand("sp_DeleteMember", connection);
                    delete.CommandType = CommandType.StoredProcedure;

                    delete.Parameters.AddWithValue("Id_Member", txtID.Text); ;
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
                txtPoint.Enabled = false;
                txtAlamat.Enabled = false;

                btnBatal.Enabled = false;
                btnHapus.Enabled = true;
                btnUbah.Enabled = false;

            }
            else
            {

            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {

            clear();
            txtID.Enabled = true;
            txtNama.Enabled = false;
            txtTelepon.Enabled = false;
            txtPoint.Enabled = false;
            txtAlamat.Enabled = false;

            btnBatal.Enabled = false;
            btnHapus.Enabled = false;
            btnUbah.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
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
        

        private void txtPoint_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
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

                    using (SqlCommand sqlCmd = new SqlCommand("sp_CariMember", sqlConn))
                    {
                        sqlConn.Open();
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("Id_Member", txtID.Text.Trim());

                        SqlDataReader reader = sqlCmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            reader.Read();
                            // double num1 = Convert.ToDouble(reader["harga"]);
                            //string res2 = string.Format("{0:n0}", num1);

                            txtNama.SelectedText = Convert.ToString(reader["Nama_Member"]);
                            txtTelepon.SelectedText = Convert.ToString(reader["no_telp"]);
                            txtPoint.SelectedText = Convert.ToString(reader["poin"]);
                            txtAlamat.SelectedText = Convert.ToString(reader["Alamat"]);


                            txtID.Enabled = false;
                            txtNama.Enabled = true;
                            txtTelepon.Enabled = true;
                            txtPoint.Enabled = true;
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
    }
}

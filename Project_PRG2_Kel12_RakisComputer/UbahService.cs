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
    public partial class UbahService : Form
    {
        public UbahService()
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

                    using (SqlCommand sqlCmd = new SqlCommand("sp_CariService", sqlConn))
                    {
                        sqlConn.Open();
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("Id_Service", txtID.Text.Trim());

                        SqlDataReader reader = sqlCmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            reader.Read();
                            //double num1 = Convert.ToDouble(reader["harga"]);
                            //string res2 = string.Format("{0:n0}", num1);

                            txtNama.SelectedText = Convert.ToString(reader["nama"]);
                            dtTglService.Text = Convert.ToString(reader["tgl_Service"]);
                            txtDeskripsi.SelectedText = Convert.ToString(reader["deskripsi"]);


                            txtID.Enabled = false;
                            txtNama.Enabled = true;
                            dtTglService.Enabled = true;
                            txtDeskripsi.Enabled = true;



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

        private void btnBatal_Click(object sender, EventArgs e)
        {
            clear();
            txtID.Enabled = true;
            txtNama.Enabled = false;
            txtDeskripsi.Enabled = false;
            dtTglService.Enabled = false;

            btnBatal.Enabled = false;
            btnHapus.Enabled = false;
            btnUbah.Enabled = false;
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {

            if (txtID.Text == "" || txtNama.Text == "" || txtDeskripsi.Text == "")
            {
                MessageBox.Show("Isi seluruh data terlebih dahulu!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                string connectionstring = (@"Data Source=LAPTOP-ALDVS5GI;Initial Catalog=db_Rakis_computerr;Integrated Security=True");
                SqlConnection connection = new SqlConnection(connectionstring);

                SqlCommand update = new SqlCommand("sp_UpdateService", connection);
                update.CommandType = CommandType.StoredProcedure;

                update.Parameters.AddWithValue("Id_Service", txtID.Text);
                update.Parameters.AddWithValue("nama", txtNama.Text);
                update.Parameters.AddWithValue("tgl_Service", dtTglService.Value);
                update.Parameters.AddWithValue("deskripsi", txtDeskripsi.Text);


                try
                {
                    connection.Open();
                    update.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil disimpan", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear(); this.Close();

                    txtID.Enabled = true;
                    txtNama.Enabled = false;
                    dtTglService.Enabled = false;
                    txtDeskripsi.Enabled = false;

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
                    SqlCommand delete = new SqlCommand("sp_DeleteService", connection);
                    delete.CommandType = CommandType.StoredProcedure;

                    delete.Parameters.AddWithValue("Id_Service", txtID.Text); ;
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
                dtTglService.Enabled = false;
                txtDeskripsi.Enabled = false;

                btnBatal.Enabled = false;
                btnHapus.Enabled = false;
                btnUbah.Enabled = false;

            }
            else
            {

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
            txtDeskripsi.Clear();

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

        private void dtTglService_Leave(object sender, EventArgs e)
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

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
    public partial class UbahPaket : Form
    {
        public UbahPaket()
        {
            InitializeComponent();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            clear();
            txtID.Enabled = true;
            txtStock.Enabled = false;
            txtHarga.Enabled = false;
            txtDeskripsi.Enabled = false;
           
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
                        using (SqlCommand sqlCmd = new SqlCommand("sp_CariPaket", sqlConn))
                        {
                            sqlConn.Open();
                            sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                            sqlCmd.Parameters.AddWithValue("Id_Paket", txtID.Text.Trim());

                            SqlDataReader reader = sqlCmd.ExecuteReader();
                            if (reader.HasRows)
                            {
                                reader.Read();
                                txtStock.SelectedText = Convert.ToString(reader["stok"]);
                                txtHarga.SelectedText = Convert.ToString(reader["harga"]);
                                txtDeskripsi.SelectedText = Convert.ToString(reader["Deskripsi"]);
                               

                                txtID.Enabled = false;
                                txtStock.Enabled = true;
                                txtHarga.Enabled = true;
                                txtDeskripsi.Enabled = true;
                                

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
            

            if (txtID.Text == "" || txtStock.Text == "" || txtHarga.Text == "" || txtDeskripsi.Text == "" )
            {
                MessageBox.Show("Isi seluruh data terlebih dahulu!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

               
                string connectionstring = "integrated security = true; data source =.; initial catalog = db_Rakis_computerr";
                SqlConnection connection = new SqlConnection(connectionstring);

                SqlCommand update = new SqlCommand("sp_UpdatePaket", connection);
                update.CommandType = CommandType.StoredProcedure;

                update.Parameters.AddWithValue("Id_Paket", txtID.Text);
                update.Parameters.AddWithValue("harga", txtHarga.Text);
                update.Parameters.AddWithValue("stok", txtStock.Text);
                update.Parameters.AddWithValue("Deskripsi", txtDeskripsi.Text);
       
                try
                {
                    connection.Open();
                    update.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil disimpan", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                    txtID.Enabled = true;
                    txtHarga.Enabled = false;
                    txtStock.Enabled = false;
                    txtDeskripsi.Enabled = false;
                    

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

        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clear()
        {
            txtID.Clear();
            txtHarga.Clear();
            txtStock.Clear();
            txtDeskripsi.Clear();
           

        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtStock_Leave(object sender, EventArgs e)
        {
            if (txtStock.Text == "")
            {
                epCorrect.SetError(txtStock, "");
                epError.SetError(txtStock, "Kolom harus diisi!");
            }
            else
            {
                epCorrect.SetError(txtStock, "Benar");
                epError.SetError(txtStock, "");
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

        private void txtHarga_Leave(object sender, EventArgs e)
        {
            if (txtHarga.Text == "")
            {
                epCorrect.SetError(txtHarga, "");
                epError.SetError(txtHarga, "Kolom harus diisi!");
            }
            else
            {
                epCorrect.SetError(txtHarga, "Benar");
                epError.SetError(txtHarga, "");
            }
        }

        private void txtHarga_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnHapus_Click_1(object sender, EventArgs e)
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
                    SqlCommand delete = new SqlCommand("sp_DeletePaket", connection);
                    delete.CommandType = CommandType.StoredProcedure;

                    delete.Parameters.AddWithValue("Id_Paket", txtID.Text); ;
                    delete.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil dihapus", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data tidak dapat dihapus: " + ex.Message);
                }
                clear(); this.Close();
                txtID.Enabled = true;
                txtStock.Enabled = false;
                txtDeskripsi.Enabled = false;
                txtHarga.Enabled = false;
              

                btnBatal.Enabled = false;
                btnHapus.Enabled = false;
                btnUbah.Enabled = false;

            }
            else
            {

            }
        }
    }
}

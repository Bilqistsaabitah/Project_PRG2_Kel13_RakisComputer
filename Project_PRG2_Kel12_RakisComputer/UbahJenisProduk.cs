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
    public partial class UbahJenisProduk : Form
    {
        public UbahJenisProduk()
        {
            InitializeComponent();
        }


        public string autogenerateID(string firstText, string query)
        {
            string connectionString = GetConnectionDB();
            SqlCommand sqlCmd;
            SqlConnection sqlCon;
            string result = "";
            int num = 0;
            try
            {
                sqlCon = new SqlConnection(connectionString);
                sqlCon.Open();
                sqlCmd = new SqlCommand(query, sqlCon);
                SqlDataReader reader = sqlCmd.ExecuteReader();
                if (reader.Read())
                {
                    string last = reader[0].ToString();
                    num = Convert.ToInt32(last.Remove(0, firstText.Length)) + 1;
                }
                else
                {
                    num = 1;
                }
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            result = firstText + num.ToString().PadLeft(2, '0');
            return result;
        }

        private void clear()
        {
            txtID.Clear();
            txtDeskripsi.Clear();

        }

        public string GetConnectionDB()
        {

            string myConnectionString = @"Data Source=LAPTOP-ALDVS5GI;Initial Catalog=db_Rakis_computerr;Integrated Security=True";


            return myConnectionString;
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

        private void btnUbah_Click(object sender, EventArgs e)
        {
            string jenis = "";

            if (txtID.Text == "" || txtDeskripsi.Text == "")
            {
                MessageBox.Show("Isi seluruh data terlebih dahulu!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {


                string connectionstring = "integrated security = true; data source =.; initial catalog = db_Rakis_computerr";
                SqlConnection connection = new SqlConnection(connectionstring);

                SqlCommand update = new SqlCommand("sp_UpdateJenisProduk", connection);
                update.CommandType = CommandType.StoredProcedure;

                update.Parameters.AddWithValue("Id_JenisProduk", txtID.Text);
                update.Parameters.AddWithValue("Deskripsi", txtDeskripsi.Text);

                try
                {
                    connection.Open();
                    update.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil disimpan", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                    txtID.Enabled = true;
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
                    SqlCommand update = new SqlCommand("sp_DeleteJenisProduk", connection);
                    update.CommandType = CommandType.StoredProcedure;

                    update.Parameters.AddWithValue("Id_JenisProduk", txtID.Text);
                    update.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil dihapus", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data tidak dapat dihapus: " + ex.Message);
                }
                clear();
                txtID.Enabled = true;
                txtDeskripsi.Enabled = false;


                btnBatal.Enabled = false;
                btnUbah.Enabled = false;
                btnHapus.Enabled = false;

                this.Close();
            }
            else
            {

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                            using (SqlCommand sqlCmd = new SqlCommand("sp_CariJenisProduk", sqlConn))
                            {
                                sqlConn.Open();
                                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                                sqlCmd.Parameters.AddWithValue("Id_JenisProduk", txtID.Text.Trim());

                                SqlDataReader reader = sqlCmd.ExecuteReader();
                                if (reader.HasRows)
                                {
                                    reader.Read();
                                    txtDeskripsi.SelectedText = Convert.ToString(reader["Deskripsi"]);

                                    txtID.Enabled = false;
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

        private void btnBatal_Click(object sender, EventArgs e)
        {
            clear();
            txtID.Enabled = true;
            txtDeskripsi.Enabled = false;

            btnBatal.Enabled = false;
            btnUbah.Enabled = false;
            btnHapus.Enabled = false;
        }
    }
}

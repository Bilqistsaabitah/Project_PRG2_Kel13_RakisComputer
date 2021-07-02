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
    public partial class UbahProduk : Form
    {
        public UbahProduk()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            clear();
            txtID.Enabled = true;
            txtNama.Enabled = false;
            txtHarga.Enabled = false;
            cmbJenisProduk.SelectedItem = -1;
            txtStock.Enabled = false;
            txtDeskripsi.Enabled = false;
          

            btnBatal.Enabled = false;
            btnUbah.Enabled = false;
            btnHapus.Enabled = false;
        }

        private void clear()
        {
            txtID.Clear();
            txtNama.Clear();
            txtHarga.Clear();
            cmbJenisProduk.SelectedItem = "";
            txtStock.Clear();
            txtDeskripsi.Clear();
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

                    using (SqlCommand sqlCmd = new SqlCommand("sp_CariProduk", sqlConn))
                    {
                        sqlConn.Open();
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("Id_produk", txtID.Text.Trim());

                        SqlDataReader reader = sqlCmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            reader.Read();
                            double num1 = Convert.ToDouble(reader["harga"]);
                            string res2 = string.Format("{0:n0}", num1);

                            txtNama.SelectedText = Convert.ToString(reader["nama_produk"]);
                            txtHarga.SelectedText = res2.ToString();
                            cmbJenisProduk.Text = Convert.ToString(reader["Id_JenisProduk"]);
                            txtStock.SelectedText = Convert.ToString(reader["Jumlah"]);
                            txtDeskripsi.SelectedText = Convert.ToString(reader["deskripsi"]);


                            txtID.Enabled = false;
                            txtNama.Enabled = true;
                            txtHarga.Enabled = true;
                            cmbJenisProduk.Enabled = true;
                            txtStock.Enabled = true;
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

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtNama.Text == "" || txtHarga.Text == "" || cmbJenisProduk.Text == "" || txtStock.Text == "" || txtDeskripsi.Text == "")
            {
                MessageBox.Show("Isi seluruh data terlebih dahulu!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                string connectionstring = (@"Data Source=LAPTOP-ALDVS5GI;Initial Catalog=db_Rakis_computerr;Integrated Security=True");
                SqlConnection connection = new SqlConnection(connectionstring);

                SqlCommand update = new SqlCommand("sp_UpdateProduk", connection);
                update.CommandType = CommandType.StoredProcedure;

                update.Parameters.AddWithValue("Id_produk", txtID.Text);
                update.Parameters.AddWithValue("nama_produk", txtNama.Text);
                update.Parameters.AddWithValue("harga", txtHarga.Text);
                update.Parameters.AddWithValue("Id_JenisProduk", cmbJenisProduk.SelectedValue);
                update.Parameters.AddWithValue("jumlah", txtStock.Text);
                update.Parameters.AddWithValue("deskripsi", txtDeskripsi.Text);


                try
                {
                    connection.Open();
                    update.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil disimpan", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear(); this.Close();

                    txtID.Enabled = true;
                    txtNama.Enabled = false;
                    cmbJenisProduk.Enabled = false;
                    txtDeskripsi.Enabled = false;
                    txtHarga.Enabled = false;

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
                    SqlCommand delete = new SqlCommand("sp_DeleteProduk", connection);
                    delete.CommandType = CommandType.StoredProcedure;

                    delete.Parameters.AddWithValue("Id_produk", txtID.Text); ;
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
                cmbJenisProduk.Enabled = false;
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

        private void btnBatal_Click_1(object sender, EventArgs e)
        {


            clear();
            txtID.Enabled = true;
            txtNama.Enabled = false;
            cmbJenisProduk.Enabled = false;
            txtDeskripsi.Enabled = false;
            txtHarga.Enabled = false;

            btnBatal.Enabled = false;
            btnHapus.Enabled = false;
            btnUbah.Enabled = false;
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

        public double split(String x)
        {
            String[] a = x.Split('.');
            //String[] b = a[1].Split('.');
            //String[] c = b[1].Split(',');
            String Total = a[0];
            double total = Double.Parse(separate(Total));

            return total;
        }

        public String separate(String a)
        {
            string[] test = a.Split(',');
            string x = "";
            foreach (string tst in test)
            {
                if (tst.Trim() != "")
                {
                    x = x + tst;
                    Console.Write(tst);
                }
            }
            return x;
        }

        private void txtHarga_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHarga_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void UbahProduk_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'db_Rakis_computerrDataSet.JenisProduk' table. You can move, or remove it, as needed.
            this.jenisProdukTableAdapter.Fill(this.db_Rakis_computerrDataSet.JenisProduk);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

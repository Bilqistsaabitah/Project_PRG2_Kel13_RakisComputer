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
    public partial class UbahPO : Form
    {
        public UbahPO()
        {
            InitializeComponent();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            if (txtIDPO.Text == "")
            {
                MessageBox.Show("Masukkan ID terlebih dahulu!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            try
            {
                if (!string.IsNullOrEmpty(txtIDPO.Text.Trim()))
                {
                    using (SqlConnection sqlConn = new SqlConnection(@"Data Source=LAPTOP-ALDVS5GI;Initial Catalog=db_Rakis_computerr;Integrated Security=True;"))

                    using (SqlCommand sqlCmd = new SqlCommand("sp_CariPurchasingOrder", sqlConn))
                    {
                        sqlConn.Open();
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("Id_PO", txtIDPO.Text.Trim());

                        SqlDataReader reader = sqlCmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            reader.Read();
                            //double num1 = Convert.ToDouble(reader["harga"]);
                            //string res2 = string.Format("{0:n0}", num1);

                            cbIdProduk.SelectedValue = Convert.ToString(reader["Id_produk"]);
                            cbIdDistributor.SelectedValue = Convert.ToString(reader["Id_Distributor"]);
                            dtpTglTransaksi.Text = Convert.ToString(reader["tgl_Transaksi"]);
                            txtHarga.SelectedText = Convert.ToString(reader["harga"]);
                            txtQty.SelectedText = Convert.ToString(reader["quantity"]);


                            txtIDPO.Enabled = false;
                            cbIdProduk.Enabled = true;
                            cbIdDistributor.Enabled = true;
                            dtpTglTransaksi.Enabled = true;
                            txtHarga.Enabled = true;
                            txtQty.Enabled = true;



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
            if (txtIDPO.Text == "" || txtQty.Text == "" || txtHarga.Text == "")
            {
                MessageBox.Show("Isi seluruh data terlebih dahulu!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                string connectionstring = (@"Data Source=LAPTOP-ALDVS5GI;Initial Catalog=db_Rakis_computerr;Integrated Security=True");
                SqlConnection connection = new SqlConnection(connectionstring);

                SqlCommand update = new SqlCommand("sp_UpdatePurchasingOrder", connection);
                update.CommandType = CommandType.StoredProcedure;

                update.Parameters.AddWithValue("Id_PO", txtIDPO.Text);
                update.Parameters.AddWithValue("Id_produk", cbIdProduk.SelectedValue);
                update.Parameters.AddWithValue("Id_Distributor", cbIdDistributor.SelectedValue);
                update.Parameters.AddWithValue("tgl_Transaksi", dtpTglTransaksi.Value);
                update.Parameters.AddWithValue("harga", txtHarga.Text);
                update.Parameters.AddWithValue("quantity", txtQty.Text);


                try
                {
                    connection.Open();
                    update.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil disimpan", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear(); this.Close();

                    txtIDPO.Enabled = true;
                    cbIdProduk.Enabled = false;
                    cbIdDistributor.Enabled = false;
                    dtpTglTransaksi.Enabled = false;
                    txtHarga.Enabled = false;
                    txtQty.Enabled = false;

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
                txtIDPO.Clear();
                cbIdProduk.SelectedIndex = -1;
                cbIdDistributor.SelectedIndex = -1;
                txtHarga.Clear();
                txtQty.Clear();
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
                    SqlCommand delete = new SqlCommand("sp_DeletePurchasingOrder", connection);
                    delete.CommandType = CommandType.StoredProcedure;

                    delete.Parameters.AddWithValue("Id_PO", txtIDPO.Text); ;
                    delete.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil dihapus", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data tidak dapat dihapus: " + ex.Message);
                }
                clear(); this.Close();
                txtIDPO.Enabled = true;
                cbIdProduk.Enabled = false;
                cbIdDistributor.Enabled = false;
                dtpTglTransaksi.Enabled = false;
                txtHarga.Enabled = false;
                txtQty.Enabled = false;

                btnBatal.Enabled = false;
                btnHapus.Enabled = false;
                btnUbah.Enabled = false;

            }
            else
            {

            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            clear();
            txtIDPO.Enabled = true;
            cbIdProduk.Enabled = false;
            cbIdDistributor.Enabled = false;
            dtpTglTransaksi.Enabled = false;
            txtHarga.Enabled = false;
            txtQty.Enabled = false;

            btnBatal.Enabled = false;
            btnHapus.Enabled = false;
            btnUbah.Enabled = false;
        }

        private void UbahPO_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'db_Rakis_computerrDataSet.Distributor' table. You can move, or remove it, as needed.
            this.distributorTableAdapter.Fill(this.db_Rakis_computerrDataSet.Distributor);
            // TODO: This line of code loads data into the 'db_Rakis_computerrDataSet.Produk' table. You can move, or remove it, as needed.
            this.produkTableAdapter.Fill(this.db_Rakis_computerrDataSet.Produk);

        }
    }
}


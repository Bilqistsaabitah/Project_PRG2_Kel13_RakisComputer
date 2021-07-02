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
    public partial class TambahPO : Form
    {
        public TambahPO()
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
                string sqlQuery = "SELECT TOP (1) MAX(RIGHT (Id_PO,2))+1 AS Id_PO FROM PurchasingOrder";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr["Id_PO"].ToString() == "")
                    {
                        autoid = 1;
                    }
                    else
                    {
                        autoid = Int32.Parse(dr["Id_PO"].ToString());
                    }
                }

                if (autoid < 10)
                {
                    kode = "PO0" + autoid;
                }
                else if (autoid < 100)
                {
                    kode = "PO" + autoid;
                }

                con.Close();

                return kode;
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
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (cbIdProduk.Text == "" || cbIdDistributor.Text == "" || txtQty.Text == "" || txtHarga.Text == "")
            {
                MessageBox.Show("Isi seluruh data terlebih dahulu!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
            }
            else
            {

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);

                SqlCommand insert = new SqlCommand("sp_InsertPurchasingOrder", con);
                insert.CommandType = CommandType.StoredProcedure;

                insert.Parameters.AddWithValue("Id_PO", AutogenerateID());
                insert.Parameters.AddWithValue("Id_produk", cbIdProduk.Text);
                insert.Parameters.AddWithValue("Id_Distributor", cbIdDistributor.Text);
                insert.Parameters.AddWithValue("tgl_transaksi", dtpTglTransaksi.Value);
                insert.Parameters.AddWithValue("harga", txtHarga.Text);
                insert.Parameters.AddWithValue("quantity", txtQty.Text);

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
        private void clear()
        {
            cbIdProduk.SelectedIndex = -1;
            cbIdDistributor.SelectedIndex = -1;
            txtHarga.Clear();
            txtQty.Clear();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtHarga_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TambahPO_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'db_Rakis_computerrDataSet.Distributor' table. You can move, or remove it, as needed.
            this.distributorTableAdapter.Fill(this.db_Rakis_computerrDataSet.Distributor);
            // TODO: This line of code loads data into the 'db_Rakis_computerrDataSet.Produk' table. You can move, or remove it, as needed.
            this.produkTableAdapter.Fill(this.db_Rakis_computerrDataSet.Produk);

        }
    }
}

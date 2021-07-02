﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_PRG2_Kel12_RakisComputer
{
    public partial class MasterJenisProduk : Form
    {
        public MasterJenisProduk()
        {
            InitializeComponent();
            this.Size = new Size(1920, 1080);
        }

        private void MasterJenisProduk_Load(object sender, EventArgs e)
        {
            loaddata();
            // TODO: This line of code loads data into the 'db_Rakis_computerrDataSet.JenisProduk' table. You can move, or remove it, as needed.
            //this.jenisProdukTableAdapter.Fill(this.db_Rakis_computerrDataSet.JenisProduk);

        }

        private void loaddata()
        {
            this.jenisProdukTableAdapter.Fill(this.db_Rakis_computerrDataSet.JenisProduk);

        }

        private void btnTmbhData_Click(object sender, EventArgs e)
        {
            TambahJenisProduk tambahJenisProduk = new TambahJenisProduk();
            tambahJenisProduk.Show();
        }

        private void btnUbahData_Click(object sender, EventArgs e)
        {
            UbahJenisProduk ubahJenisProduk = new UbahJenisProduk();
            ubahJenisProduk.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.jenisProdukTableAdapter.Fill(this.db_Rakis_computerrDataSet.JenisProduk);

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPegawai_Click(object sender, EventArgs e)
        {
            MasterPegawai masterPegawai = new MasterPegawai();
            masterPegawai.Show();
        }

        private void btnMember_Click(object sender, EventArgs e)
        {
            MasterMember masterMember = new MasterMember();
            masterMember.Show();
        }

        private void btnProduk_Click(object sender, EventArgs e)
        {
            MasterProduk masterProduk = new MasterProduk();
            masterProduk.Show();
        }

        private void btnJenisProduk_Click(object sender, EventArgs e)
        {
            MasterJenisProduk masterJenisProduk = new MasterJenisProduk();
            masterJenisProduk.Show();
        }

        private void btnDistributor_Click(object sender, EventArgs e)
        {
            MasterDistributor masterDistributor = new MasterDistributor();
            masterDistributor.Show();
        }

        private void btnPO_Click(object sender, EventArgs e)
        {
            MasterPO masterPO = new MasterPO();
            masterPO.Show();
                
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            MasterService masterService = new MasterService();
            masterService.Show();
        }

        private void btnPaket_Click(object sender, EventArgs e)
        {
            MasterPaket masterPaket = new MasterPaket();
            masterPaket.Show();
        }

        private void btnTtgAplikasi_Click(object sender, EventArgs e)
        {
            AboutAplikasi aboutAplikasi = new AboutAplikasi();
            aboutAplikasi.Show();
        }
    }
}

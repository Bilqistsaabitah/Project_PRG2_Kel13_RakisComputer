namespace Project_PRG2_Kel12_RakisComputer
{
    partial class TambahPO
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TambahPO));
            this.cbIdDistributor = new System.Windows.Forms.ComboBox();
            this.cbIdProduk = new System.Windows.Forms.ComboBox();
            this.dtpTglTransaksi = new System.Windows.Forms.DateTimePicker();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtHarga = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.btnBatal = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.header = new System.Windows.Forms.Panel();
            this.bunifuImageButton3 = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.db_Rakis_computerrDataSet = new Project_PRG2_Kel12_RakisComputer.db_Rakis_computerrDataSet();
            this.produkBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.produkTableAdapter = new Project_PRG2_Kel12_RakisComputer.db_Rakis_computerrDataSetTableAdapters.ProdukTableAdapter();
            this.distributorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.distributorTableAdapter = new Project_PRG2_Kel12_RakisComputer.db_Rakis_computerrDataSetTableAdapters.DistributorTableAdapter();
            this.header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_Rakis_computerrDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produkBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.distributorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cbIdDistributor
            // 
            this.cbIdDistributor.DataSource = this.distributorBindingSource;
            this.cbIdDistributor.DisplayMember = "Id_Distributor";
            this.cbIdDistributor.FormattingEnabled = true;
            this.cbIdDistributor.Location = new System.Drawing.Point(66, 307);
            this.cbIdDistributor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbIdDistributor.Name = "cbIdDistributor";
            this.cbIdDistributor.Size = new System.Drawing.Size(354, 28);
            this.cbIdDistributor.TabIndex = 148;
            this.cbIdDistributor.ValueMember = "Id_Distributor";
            // 
            // cbIdProduk
            // 
            this.cbIdProduk.DataSource = this.produkBindingSource;
            this.cbIdProduk.DisplayMember = "Id_produk";
            this.cbIdProduk.FormattingEnabled = true;
            this.cbIdProduk.Location = new System.Drawing.Point(66, 182);
            this.cbIdProduk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbIdProduk.Name = "cbIdProduk";
            this.cbIdProduk.Size = new System.Drawing.Size(354, 28);
            this.cbIdProduk.TabIndex = 147;
            this.cbIdProduk.ValueMember = "Id_produk";
            // 
            // dtpTglTransaksi
            // 
            this.dtpTglTransaksi.Location = new System.Drawing.Point(64, 442);
            this.dtpTglTransaksi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpTglTransaksi.Name = "dtpTglTransaksi";
            this.dtpTglTransaksi.Size = new System.Drawing.Size(355, 26);
            this.dtpTglTransaksi.TabIndex = 146;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Century Gothic", 12.75F, System.Drawing.FontStyle.Bold);
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.Bisque;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(330, 11);
            this.bunifuCustomLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(0, 30);
            this.bunifuCustomLabel1.TabIndex = 4;
            // 
            // txtHarga
            // 
            this.txtHarga.Location = new System.Drawing.Point(516, 308);
            this.txtHarga.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtHarga.Name = "txtHarga";
            this.txtHarga.Size = new System.Drawing.Size(400, 26);
            this.txtHarga.TabIndex = 144;
            this.txtHarga.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHarga_KeyPress);
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(514, 185);
            this.txtQty.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(402, 26);
            this.txtQty.TabIndex = 145;
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // btnBatal
            // 
            this.btnBatal.BackColor = System.Drawing.Color.RosyBrown;
            this.btnBatal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBatal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnBatal.ForeColor = System.Drawing.Color.Bisque;
            this.btnBatal.Location = new System.Drawing.Point(564, 579);
            this.btnBatal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(120, 42);
            this.btnBatal.TabIndex = 140;
            this.btnBatal.Text = "Batal";
            this.btnBatal.UseVisualStyleBackColor = false;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.IndianRed;
            this.label4.Location = new System.Drawing.Point(60, 393);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(237, 28);
            this.label4.TabIndex = 137;
            this.label4.Text = "Tanggal Pembelian";
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.RosyBrown;
            this.header.Controls.Add(this.bunifuImageButton3);
            this.header.Controls.Add(this.btnClose);
            this.header.Controls.Add(this.bunifuCustomLabel3);
            this.header.Controls.Add(this.bunifuCustomLabel1);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(994, 54);
            this.header.TabIndex = 136;
            // 
            // bunifuImageButton3
            // 
            this.bunifuImageButton3.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton3.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton3.Image")));
            this.bunifuImageButton3.ImageActive = null;
            this.bunifuImageButton3.Location = new System.Drawing.Point(14, 6);
            this.bunifuImageButton3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bunifuImageButton3.Name = "bunifuImageButton3";
            this.bunifuImageButton3.Size = new System.Drawing.Size(38, 38);
            this.bunifuImageButton3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bunifuImageButton3.TabIndex = 6;
            this.bunifuImageButton3.TabStop = false;
            this.bunifuImageButton3.Zoom = 10;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageActive = null;
            this.btnClose.Location = new System.Drawing.Point(945, 3);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(45, 46);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnClose.TabIndex = 6;
            this.btnClose.TabStop = false;
            this.btnClose.Zoom = 10;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Century Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel3.ForeColor = System.Drawing.Color.Bisque;
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(56, 11);
            this.bunifuCustomLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(315, 30);
            this.bunifuCustomLabel3.TabIndex = 6;
            this.bunifuCustomLabel3.Text = "Aplikasi Rakis Computer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.IndianRed;
            this.label3.Location = new System.Drawing.Point(58, 260);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 28);
            this.label3.TabIndex = 143;
            this.label3.Text = "ID Distributor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.IndianRed;
            this.label2.Location = new System.Drawing.Point(510, 274);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 28);
            this.label2.TabIndex = 142;
            this.label2.Text = "Harga";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.IndianRed;
            this.label1.Location = new System.Drawing.Point(510, 147);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 28);
            this.label1.TabIndex = 141;
            this.label1.Text = "Quantity";
            // 
            // btnSimpan
            // 
            this.btnSimpan.BackColor = System.Drawing.Color.RosyBrown;
            this.btnSimpan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimpan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSimpan.ForeColor = System.Drawing.Color.Bisque;
            this.btnSimpan.Location = new System.Drawing.Point(297, 579);
            this.btnSimpan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(120, 42);
            this.btnSimpan.TabIndex = 139;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = false;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.IndianRed;
            this.label7.Location = new System.Drawing.Point(60, 151);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 28);
            this.label7.TabIndex = 138;
            this.label7.Text = "Id Produk";
            // 
            // db_Rakis_computerrDataSet
            // 
            this.db_Rakis_computerrDataSet.DataSetName = "db_Rakis_computerrDataSet";
            this.db_Rakis_computerrDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // produkBindingSource
            // 
            this.produkBindingSource.DataMember = "Produk";
            this.produkBindingSource.DataSource = this.db_Rakis_computerrDataSet;
            // 
            // produkTableAdapter
            // 
            this.produkTableAdapter.ClearBeforeFill = true;
            // 
            // distributorBindingSource
            // 
            this.distributorBindingSource.DataMember = "Distributor";
            this.distributorBindingSource.DataSource = this.db_Rakis_computerrDataSet;
            // 
            // distributorTableAdapter
            // 
            this.distributorTableAdapter.ClearBeforeFill = true;
            // 
            // TambahPO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 643);
            this.Controls.Add(this.cbIdDistributor);
            this.Controls.Add(this.cbIdProduk);
            this.Controls.Add(this.dtpTglTransaksi);
            this.Controls.Add(this.txtHarga);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.header);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.label7);
            this.Name = "TambahPO";
            this.Text = "TambahPO";
            this.Load += new System.EventHandler(this.TambahPO_Load);
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_Rakis_computerrDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produkBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.distributorBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbIdDistributor;
        private System.Windows.Forms.ComboBox cbIdProduk;
        private System.Windows.Forms.DateTimePicker dtpTglTransaksi;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private System.Windows.Forms.TextBox txtHarga;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel header;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton3;
        private Bunifu.Framework.UI.BunifuImageButton btnClose;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Label label7;
        private db_Rakis_computerrDataSet db_Rakis_computerrDataSet;
        private System.Windows.Forms.BindingSource produkBindingSource;
        private db_Rakis_computerrDataSetTableAdapters.ProdukTableAdapter produkTableAdapter;
        private System.Windows.Forms.BindingSource distributorBindingSource;
        private db_Rakis_computerrDataSetTableAdapters.DistributorTableAdapter distributorTableAdapter;
    }
}
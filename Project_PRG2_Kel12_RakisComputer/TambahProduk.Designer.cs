namespace Project_PRG2_Kel12_RakisComputer
{
    partial class TambahProduk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TambahProduk));
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.btnBatal = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.header = new System.Windows.Forms.Panel();
            this.bunifuImageButton3 = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.epError = new System.Windows.Forms.ErrorProvider(this.components);
            this.epCorrect = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDeskripsi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbJenisProduk = new System.Windows.Forms.ComboBox();
            this.jenisProdukBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.db_Rakis_computerrDataSet = new Project_PRG2_Kel12_RakisComputer.db_Rakis_computerrDataSet();
            this.txtHarga = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.produkBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.produkTableAdapter = new Project_PRG2_Kel12_RakisComputer.db_Rakis_computerrDataSetTableAdapters.ProdukTableAdapter();
            this.jenisProdukTableAdapter = new Project_PRG2_Kel12_RakisComputer.db_Rakis_computerrDataSetTableAdapters.JenisProdukTableAdapter();
            this.header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCorrect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jenisProdukBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_Rakis_computerrDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produkBindingSource)).BeginInit();
            this.SuspendLayout();
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
            // btnBatal
            // 
            this.btnBatal.BackColor = System.Drawing.Color.RosyBrown;
            this.btnBatal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBatal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnBatal.ForeColor = System.Drawing.Color.Bisque;
            this.btnBatal.Location = new System.Drawing.Point(568, 652);
            this.btnBatal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(120, 42);
            this.btnBatal.TabIndex = 86;
            this.btnBatal.Text = "Batal";
            this.btnBatal.UseVisualStyleBackColor = false;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // btnSimpan
            // 
            this.btnSimpan.BackColor = System.Drawing.Color.RosyBrown;
            this.btnSimpan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimpan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSimpan.ForeColor = System.Drawing.Color.Bisque;
            this.btnSimpan.Location = new System.Drawing.Point(302, 652);
            this.btnSimpan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(120, 42);
            this.btnSimpan.TabIndex = 85;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = false;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // txtNama
            // 
            this.txtNama.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtNama.Location = new System.Drawing.Point(62, 162);
            this.txtNama.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNama.MaxLength = 20;
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(358, 28);
            this.txtNama.TabIndex = 72;
            this.txtNama.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNama_KeyPress);
            this.txtNama.Leave += new System.EventHandler(this.txtNama_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.IndianRed;
            this.label7.Location = new System.Drawing.Point(57, 252);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 28);
            this.label7.TabIndex = 83;
            this.label7.Text = "Harga";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.IndianRed;
            this.label4.Location = new System.Drawing.Point(57, 125);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 28);
            this.label4.TabIndex = 77;
            this.label4.Text = "Nama Produk";
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
            this.header.Size = new System.Drawing.Size(1008, 54);
            this.header.TabIndex = 71;
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
            // epError
            // 
            this.epError.ContainerControl = this;
            // 
            // epCorrect
            // 
            this.epCorrect.ContainerControl = this;
            this.epCorrect.Icon = ((System.Drawing.Icon)(resources.GetObject("epCorrect.Icon")));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.IndianRed;
            this.label1.Location = new System.Drawing.Point(510, 125);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 28);
            this.label1.TabIndex = 94;
            this.label1.Text = "Stock";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.IndianRed;
            this.label2.Location = new System.Drawing.Point(510, 252);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 28);
            this.label2.TabIndex = 96;
            this.label2.Text = "Deskripsi";
            // 
            // txtDeskripsi
            // 
            this.txtDeskripsi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeskripsi.Location = new System.Drawing.Point(515, 327);
            this.txtDeskripsi.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.txtDeskripsi.MaxLength = 50;
            this.txtDeskripsi.Multiline = true;
            this.txtDeskripsi.Name = "txtDeskripsi";
            this.txtDeskripsi.Size = new System.Drawing.Size(402, 116);
            this.txtDeskripsi.TabIndex = 97;
            this.txtDeskripsi.Leave += new System.EventHandler(this.txtDeskripsi_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.IndianRed;
            this.label3.Location = new System.Drawing.Point(57, 399);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 28);
            this.label3.TabIndex = 98;
            this.label3.Text = "Jenis Produk";
            // 
            // cmbJenisProduk
            // 
            this.cmbJenisProduk.DataSource = this.jenisProdukBindingSource;
            this.cmbJenisProduk.DisplayMember = "Deskripsi";
            this.cmbJenisProduk.FormattingEnabled = true;
            this.cmbJenisProduk.Location = new System.Drawing.Point(61, 472);
            this.cmbJenisProduk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbJenisProduk.Name = "cmbJenisProduk";
            this.cmbJenisProduk.Size = new System.Drawing.Size(358, 28);
            this.cmbJenisProduk.TabIndex = 115;
            this.cmbJenisProduk.ValueMember = "Deskripsi";
            // 
            // jenisProdukBindingSource
            // 
            this.jenisProdukBindingSource.DataMember = "JenisProduk";
            this.jenisProdukBindingSource.DataSource = this.db_Rakis_computerrDataSet;
            // 
            // db_Rakis_computerrDataSet
            // 
            this.db_Rakis_computerrDataSet.DataSetName = "db_Rakis_computerrDataSet";
            this.db_Rakis_computerrDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtHarga
            // 
            this.txtHarga.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtHarga.Location = new System.Drawing.Point(61, 312);
            this.txtHarga.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtHarga.MaxLength = 20;
            this.txtHarga.Name = "txtHarga";
            this.txtHarga.Size = new System.Drawing.Size(358, 28);
            this.txtHarga.TabIndex = 116;
            this.txtHarga.TextChanged += new System.EventHandler(this.txtHarga_TextChanged);
            this.txtHarga.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHarga_KeyPress);
            // 
            // txtStock
            // 
            this.txtStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtStock.Location = new System.Drawing.Point(515, 162);
            this.txtStock.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtStock.MaxLength = 20;
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(358, 28);
            this.txtStock.TabIndex = 117;
            this.txtStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStock_KeyPress);
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
            // jenisProdukTableAdapter
            // 
            this.jenisProdukTableAdapter.ClearBeforeFill = true;
            // 
            // TambahProduk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(1008, 710);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.txtHarga);
            this.Controls.Add(this.cmbJenisProduk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDeskripsi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.header);
            this.Name = "TambahProduk";
            this.Text = "AddProduk";
            this.Load += new System.EventHandler(this.TambahProduk_Load);
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCorrect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jenisProdukBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_Rakis_computerrDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produkBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuImageButton btnClose;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.Button btnSimpan;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton3;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel header;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private System.Windows.Forms.ErrorProvider epError;
        private System.Windows.Forms.ErrorProvider epCorrect;
        private System.Windows.Forms.TextBox txtDeskripsi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbJenisProduk;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.TextBox txtHarga;
        private db_Rakis_computerrDataSet db_Rakis_computerrDataSet;
        private System.Windows.Forms.BindingSource produkBindingSource;
        private db_Rakis_computerrDataSetTableAdapters.ProdukTableAdapter produkTableAdapter;
        private System.Windows.Forms.BindingSource jenisProdukBindingSource;
        private db_Rakis_computerrDataSetTableAdapters.JenisProdukTableAdapter jenisProdukTableAdapter;
    }
}
namespace Jijehh_TokoSembako
{
    partial class FormUtama
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
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnUbah = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.lblTotalRecord = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.txtKategori = new System.Windows.Forms.TextBox();
            this.txtStok = new System.Windows.Forms.TextBox();
            this.txtHarga = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(4, 378);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersWidth = 51;
            this.dgvData.RowTemplate.Height = 24;
            this.dgvData.Size = new System.Drawing.Size(1170, 256);
            this.dgvData.TabIndex = 0;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(77, 74);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(67, 16);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "ID Barang";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(77, 118);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(91, 16);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Nama Barang";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(77, 162);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(57, 16);
            this.Label3.TabIndex = 3;
            this.Label3.Text = "Kategori";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(77, 199);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(34, 16);
            this.Label4.TabIndex = 4;
            this.Label4.Text = "Stok";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(77, 241);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(45, 16);
            this.Label5.TabIndex = 5;
            this.Label5.Text = "Harga";
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(88, 316);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(96, 34);
            this.btnSimpan.TabIndex = 6;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            // 
            // btnUbah
            // 
            this.btnUbah.Location = new System.Drawing.Point(190, 316);
            this.btnUbah.Name = "btnUbah";
            this.btnUbah.Size = new System.Drawing.Size(96, 34);
            this.btnUbah.TabIndex = 7;
            this.btnUbah.Text = "Ubah";
            this.btnUbah.UseVisualStyleBackColor = true;
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(292, 316);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(96, 34);
            this.btnHapus.TabIndex = 8;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            // 
            // lblTotalRecord
            // 
            this.lblTotalRecord.AutoSize = true;
            this.lblTotalRecord.Location = new System.Drawing.Point(80, 665);
            this.lblTotalRecord.Name = "lblTotalRecord";
            this.lblTotalRecord.Size = new System.Drawing.Size(99, 16);
            this.lblTotalRecord.TabIndex = 9;
            this.lblTotalRecord.Text = "Total Record: 0";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(233, 74);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 22);
            this.txtID.TabIndex = 10;
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(233, 112);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(100, 22);
            this.txtNama.TabIndex = 11;
            // 
            // txtKategori
            // 
            this.txtKategori.Location = new System.Drawing.Point(233, 156);
            this.txtKategori.Name = "txtKategori";
            this.txtKategori.Size = new System.Drawing.Size(100, 22);
            this.txtKategori.TabIndex = 12;
            // 
            // txtStok
            // 
            this.txtStok.Location = new System.Drawing.Point(233, 199);
            this.txtStok.Name = "txtStok";
            this.txtStok.Size = new System.Drawing.Size(100, 22);
            this.txtStok.TabIndex = 13;
            // 
            // txtHarga
            // 
            this.txtHarga.Location = new System.Drawing.Point(233, 238);
            this.txtHarga.Name = "txtHarga";
            this.txtHarga.Size = new System.Drawing.Size(100, 22);
            this.txtHarga.TabIndex = 14;
            // 
            // FormUtama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 783);
            this.Controls.Add(this.txtHarga);
            this.Controls.Add(this.txtStok);
            this.Controls.Add(this.txtKategori);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblTotalRecord);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnUbah);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.dgvData);
            this.Name = "FormUtama";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormUtama_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnUbah;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Label lblTotalRecord;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.TextBox txtKategori;
        private System.Windows.Forms.TextBox txtStok;
        private System.Windows.Forms.TextBox txtHarga;
    }
}


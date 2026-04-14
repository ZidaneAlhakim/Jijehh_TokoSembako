namespace Jijehh_TokoSembako
{
    partial class FormLaporan
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvLaporan = new System.Windows.Forms.DataGridView();
            this.chartBestSeller = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBestSeller)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(103, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tabel Laporan Transaksi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(522, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Grafik Best Seller";
            // 
            // dgvLaporan
            // 
            this.dgvLaporan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLaporan.Location = new System.Drawing.Point(54, 112);
            this.dgvLaporan.Name = "dgvLaporan";
            this.dgvLaporan.RowHeadersWidth = 51;
            this.dgvLaporan.RowTemplate.Height = 24;
            this.dgvLaporan.Size = new System.Drawing.Size(280, 300);
            this.dgvLaporan.TabIndex = 2;
            // 
            // chartBestSeller
            // 
            chartArea1.Name = "ChartArea1";
            this.chartBestSeller.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartBestSeller.Legends.Add(legend1);
            this.chartBestSeller.Location = new System.Drawing.Point(424, 112);
            this.chartBestSeller.Name = "chartBestSeller";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartBestSeller.Series.Add(series1);
            this.chartBestSeller.Size = new System.Drawing.Size(300, 300);
            this.chartBestSeller.TabIndex = 3;
            this.chartBestSeller.Text = "chart1";
            // 
            // FormLaporan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chartBestSeller);
            this.Controls.Add(this.dgvLaporan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormLaporan";
            this.Text = "FormLaporan";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBestSeller)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvLaporan;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBestSeller;
    }
}
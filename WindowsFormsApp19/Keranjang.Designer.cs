namespace WindowsFormsApp19
{
    partial class Keranjang
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
            this.text_idTiket = new System.Windows.Forms.TextBox();
            this.label_idTiket = new System.Windows.Forms.Label();
            this.button_hapusTiket = new System.Windows.Forms.Button();
            this.button_refresh = new System.Windows.Forms.Button();
            this.listKeranjang = new System.Windows.Forms.ListView();
            this.id_pembelian = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nama_event = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pembeli = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.alamat_event = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // text_idTiket
            // 
            this.text_idTiket.Location = new System.Drawing.Point(333, 15);
            this.text_idTiket.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.text_idTiket.Name = "text_idTiket";
            this.text_idTiket.ReadOnly = true;
            this.text_idTiket.Size = new System.Drawing.Size(265, 22);
            this.text_idTiket.TabIndex = 35;
            // 
            // label_idTiket
            // 
            this.label_idTiket.AutoSize = true;
            this.label_idTiket.Location = new System.Drawing.Point(16, 18);
            this.label_idTiket.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_idTiket.Name = "label_idTiket";
            this.label_idTiket.Size = new System.Drawing.Size(56, 17);
            this.label_idTiket.TabIndex = 34;
            this.label_idTiket.Text = "ID Tiket";
            // 
            // button_hapusTiket
            // 
            this.button_hapusTiket.Location = new System.Drawing.Point(20, 369);
            this.button_hapusTiket.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_hapusTiket.Name = "button_hapusTiket";
            this.button_hapusTiket.Size = new System.Drawing.Size(136, 28);
            this.button_hapusTiket.TabIndex = 33;
            this.button_hapusTiket.Text = "Hapus Data Tiket";
            this.button_hapusTiket.UseVisualStyleBackColor = true;
            // 
            // button_refresh
            // 
            this.button_refresh.Location = new System.Drawing.Point(480, 369);
            this.button_refresh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(125, 28);
            this.button_refresh.TabIndex = 30;
            this.button_refresh.Text = "Refresh Data";
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.Button_refresh_Click);
            // 
            // listKeranjang
            // 
            this.listKeranjang.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id_pembelian,
            this.nama_event,
            this.pembeli,
            this.alamat_event});
            this.listKeranjang.HideSelection = false;
            this.listKeranjang.Location = new System.Drawing.Point(20, 60);
            this.listKeranjang.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listKeranjang.Name = "listKeranjang";
            this.listKeranjang.Size = new System.Drawing.Size(584, 290);
            this.listKeranjang.TabIndex = 28;
            this.listKeranjang.UseCompatibleStateImageBehavior = false;
            this.listKeranjang.View = System.Windows.Forms.View.Details;
            // 
            // id_pembelian
            // 
            this.id_pembelian.Text = "ID Pembelian";
            this.id_pembelian.Width = 53;
            // 
            // nama_event
            // 
            this.nama_event.Text = "Nama Event";
            this.nama_event.Width = 94;
            // 
            // pembeli
            // 
            this.pembeli.Text = "Pembeli";
            this.pembeli.Width = 93;
            // 
            // alamat_event
            // 
            this.alamat_event.Text = "Alamat Event";
            this.alamat_event.Width = 110;
            // 
            // Keranjang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 479);
            this.Controls.Add(this.text_idTiket);
            this.Controls.Add(this.label_idTiket);
            this.Controls.Add(this.button_hapusTiket);
            this.Controls.Add(this.button_refresh);
            this.Controls.Add(this.listKeranjang);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Keranjang";
            this.Text = "Keranjang";
            this.Load += new System.EventHandler(this.Keranjang_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox text_idTiket;
        private System.Windows.Forms.Label label_idTiket;
        private System.Windows.Forms.Button button_hapusTiket;
        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.ListView listKeranjang;
        private System.Windows.Forms.ColumnHeader id_pembelian;
        private System.Windows.Forms.ColumnHeader nama_event;
        private System.Windows.Forms.ColumnHeader pembeli;
        private System.Windows.Forms.ColumnHeader alamat_event;
    }
}
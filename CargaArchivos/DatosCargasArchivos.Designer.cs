namespace CargaArchivos
{
    partial class DatosCargasArchivos
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
            this.ArchivoCargar = new System.Windows.Forms.TextBox();
            this.cmRutas = new System.Windows.Forms.Button();
            this.LinkPagina = new System.Windows.Forms.TextBox();
            this.LinkPage = new System.Windows.Forms.Button();
            this.ArchivoaBajar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ArchivoCargar
            // 
            this.ArchivoCargar.Location = new System.Drawing.Point(12, 12);
            this.ArchivoCargar.Name = "ArchivoCargar";
            this.ArchivoCargar.Size = new System.Drawing.Size(574, 22);
            this.ArchivoCargar.TabIndex = 0;
            // 
            // cmRutas
            // 
            this.cmRutas.Location = new System.Drawing.Point(592, 11);
            this.cmRutas.Name = "cmRutas";
            this.cmRutas.Size = new System.Drawing.Size(75, 23);
            this.cmRutas.TabIndex = 1;
            this.cmRutas.Text = "Rutas";
            this.cmRutas.UseVisualStyleBackColor = true;
            this.cmRutas.Click += new System.EventHandler(this.cmRutas_Click);
            // 
            // LinkPagina
            // 
            this.LinkPagina.Location = new System.Drawing.Point(12, 53);
            this.LinkPagina.Name = "LinkPagina";
            this.LinkPagina.Size = new System.Drawing.Size(574, 22);
            this.LinkPagina.TabIndex = 2;
            this.LinkPagina.Text = "http://informacioninteligente10.xm.com.co/demanda/Paginas/HistoricoDemanda.aspx";
            // 
            // LinkPage
            // 
            this.LinkPage.Location = new System.Drawing.Point(592, 53);
            this.LinkPage.Name = "LinkPage";
            this.LinkPage.Size = new System.Drawing.Size(75, 23);
            this.LinkPage.TabIndex = 3;
            this.LinkPage.Text = "URL Demanda";
            this.LinkPage.UseVisualStyleBackColor = true;
            // 
            // ArchivoaBajar
            // 
            this.ArchivoaBajar.Location = new System.Drawing.Point(12, 94);
            this.ArchivoaBajar.Name = "ArchivoaBajar";
            this.ArchivoaBajar.Size = new System.Drawing.Size(574, 22);
            this.ArchivoaBajar.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(592, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Archivo Potencia";
            // 
            // DatosCargasArchivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ArchivoaBajar);
            this.Controls.Add(this.LinkPage);
            this.Controls.Add(this.LinkPagina);
            this.Controls.Add(this.cmRutas);
            this.Controls.Add(this.ArchivoCargar);
            this.Name = "DatosCargasArchivos";
            this.Text = "DatosCargasArchivos";
            this.Load += new System.EventHandler(this.DatosCargasArchivos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ArchivoCargar;
        private System.Windows.Forms.Button cmRutas;
        private System.Windows.Forms.TextBox LinkPagina;
        private System.Windows.Forms.Button LinkPage;
        private System.Windows.Forms.TextBox ArchivoaBajar;
        private System.Windows.Forms.Label label1;
    }
}
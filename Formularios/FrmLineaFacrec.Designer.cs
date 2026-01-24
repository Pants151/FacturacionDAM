namespace FacturacionDAM.Formularios
{
    partial class FrmLineaFacrec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLineaFacrec));
            this.pnBtns = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.pnData = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTotal = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbCuota = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbBase = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.gbCalculo = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numTipoIva = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.numPrecio = new System.Windows.Forms.NumericUpDown();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gbProducto = new System.Windows.Forms.GroupBox();
            this.BtnProducto = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbProducto = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pnBtns.SuspendLayout();
            this.pnData.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbCalculo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTipoIva)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecio)).BeginInit();
            this.gbProducto.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnBtns
            // 
            this.pnBtns.Controls.Add(this.btnCancelar);
            this.pnBtns.Controls.Add(this.btnAceptar);
            this.pnBtns.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBtns.Location = new System.Drawing.Point(0, 299);
            this.pnBtns.Name = "pnBtns";
            this.pnBtns.Size = new System.Drawing.Size(690, 63);
            this.pnBtns.TabIndex = 1;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(401, 14);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnCancelar.Size = new System.Drawing.Size(100, 36);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(198, 14);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnAceptar.Size = new System.Drawing.Size(100, 36);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // pnData
            // 
            this.pnData.Controls.Add(this.panel1);
            this.pnData.Controls.Add(this.gbCalculo);
            this.pnData.Controls.Add(this.gbProducto);
            this.pnData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnData.Location = new System.Drawing.Point(0, 0);
            this.pnData.Name = "pnData";
            this.pnData.Size = new System.Drawing.Size(690, 299);
            this.pnData.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbTotal);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.lbCuota);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.lbBase);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Location = new System.Drawing.Point(20, 233);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 48);
            this.panel1.TabIndex = 36;
            // 
            // lbTotal
            // 
            this.lbTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbTotal.ForeColor = System.Drawing.Color.Black;
            this.lbTotal.Location = new System.Drawing.Point(451, 12);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(87, 23);
            this.lbTotal.TabIndex = 18;
            this.lbTotal.Text = "10,00 €";
            this.lbTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(393, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 23);
            this.label12.TabIndex = 17;
            this.label12.Text = "Total:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbCuota
            // 
            this.lbCuota.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbCuota.ForeColor = System.Drawing.Color.Black;
            this.lbCuota.Location = new System.Drawing.Point(308, 12);
            this.lbCuota.Name = "lbCuota";
            this.lbCuota.Size = new System.Drawing.Size(87, 23);
            this.lbCuota.TabIndex = 16;
            this.lbCuota.Text = "10,00 €";
            this.lbCuota.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(252, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 23);
            this.label11.TabIndex = 15;
            this.label11.Text = "Cuota:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbBase
            // 
            this.lbBase.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbBase.ForeColor = System.Drawing.Color.Black;
            this.lbBase.Location = new System.Drawing.Point(157, 12);
            this.lbBase.Name = "lbBase";
            this.lbBase.Size = new System.Drawing.Size(87, 23);
            this.lbBase.TabIndex = 14;
            this.lbBase.Text = "10,00 €";
            this.lbBase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(99, 12);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 23);
            this.label17.TabIndex = 13;
            this.label17.Text = "Base:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbCalculo
            // 
            this.gbCalculo.Controls.Add(this.label6);
            this.gbCalculo.Controls.Add(this.numCantidad);
            this.gbCalculo.Controls.Add(this.label4);
            this.gbCalculo.Controls.Add(this.numTipoIva);
            this.gbCalculo.Controls.Add(this.label5);
            this.gbCalculo.Controls.Add(this.label10);
            this.gbCalculo.Controls.Add(this.numPrecio);
            this.gbCalculo.Controls.Add(this.txtDescripcion);
            this.gbCalculo.Controls.Add(this.label2);
            this.gbCalculo.Controls.Add(this.label3);
            this.gbCalculo.Location = new System.Drawing.Point(20, 120);
            this.gbCalculo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbCalculo.Name = "gbCalculo";
            this.gbCalculo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbCalculo.Size = new System.Drawing.Size(649, 100);
            this.gbCalculo.TabIndex = 18;
            this.gbCalculo.TabStop = false;
            this.gbCalculo.Text = "Cálculo de la Linea de Factura";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(205, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 23);
            this.label6.TabIndex = 34;
            this.label6.Text = "(sin IVA)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numCantidad
            // 
            this.numCantidad.Location = new System.Drawing.Point(524, 65);
            this.numCantidad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numCantidad.Maximum = new decimal(new int[] { 9999, 0, 0, 131072 });
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Size = new System.Drawing.Size(94, 23);
            this.numCantidad.TabIndex = 33;
            this.numCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(449, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 23);
            this.label4.TabIndex = 32;
            this.label4.Text = "Unidades:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numTipoIva
            // 
            this.numTipoIva.DecimalPlaces = 2;
            this.numTipoIva.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            this.numTipoIva.Location = new System.Drawing.Point(348, 65);
            this.numTipoIva.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numTipoIva.Maximum = new decimal(new int[] { 9999, 0, 0, 131072 });
            this.numTipoIva.Name = "numTipoIva";
            this.numTipoIva.Size = new System.Drawing.Size(64, 23);
            this.numTipoIva.TabIndex = 31;
            this.numTipoIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(414, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 23);
            this.label5.TabIndex = 30;
            this.label5.Text = "%";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(263, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 23);
            this.label10.TabIndex = 28;
            this.label10.Text = "Tipo de IVA:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numPrecio
            // 
            this.numPrecio.DecimalPlaces = 2;
            this.numPrecio.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            this.numPrecio.Location = new System.Drawing.Point(108, 65);
            this.numPrecio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numPrecio.Maximum = new decimal(new int[] { 99999, 0, 0, 131072 });
            this.numPrecio.Name = "numPrecio";
            this.numPrecio.Size = new System.Drawing.Size(95, 23);
            this.numPrecio.TabIndex = 27;
            this.numPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(108, 33);
            this.txtDescripcion.MaxLength = 255;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(511, 23);
            this.txtDescripcion.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 23);
            this.label2.TabIndex = 24;
            this.label2.Text = "Precio/Unidad:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(20, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 23);
            this.label3.TabIndex = 25;
            this.label3.Text = "Descripción:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbProducto
            // 
            this.gbProducto.Controls.Add(this.BtnProducto);
            this.gbProducto.Controls.Add(this.label1);
            this.gbProducto.Controls.Add(this.cbProducto);
            this.gbProducto.Controls.Add(this.label7);
            this.gbProducto.Location = new System.Drawing.Point(20, 14);
            this.gbProducto.Name = "gbProducto";
            this.gbProducto.Size = new System.Drawing.Size(649, 95);
            this.gbProducto.TabIndex = 5;
            this.gbProducto.TabStop = false;
            this.gbProducto.Text = "Producto (opcional)";
            // 
            // BtnProducto
            // 
            this.BtnProducto.Image = ((System.Drawing.Image)(resources.GetObject("BtnProducto.Image")));
            this.BtnProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnProducto.Location = new System.Drawing.Point(463, 52);
            this.BtnProducto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnProducto.Name = "BtnProducto";
            this.BtnProducto.Padding = new System.Windows.Forms.Padding(14, 0, 10, 0);
            this.BtnProducto.Size = new System.Drawing.Size(119, 32);
            this.BtnProducto.TabIndex = 9;
            this.BtnProducto.Text = "Trasladar";
            this.BtnProducto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnProducto.UseVisualStyleBackColor = true;
            this.BtnProducto.Click += new System.EventHandler(this.BtnProducto_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(514, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Selecciona un producto para trasladar su precio y tipo de IVA a los cálculos de l" +
    "a línea de factura.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbProducto
            // 
            this.cbProducto.FormattingEnabled = true;
            this.cbProducto.Location = new System.Drawing.Point(116, 58);
            this.cbProducto.Name = "cbProducto";
            this.cbProducto.Size = new System.Drawing.Size(334, 23);
            this.cbProducto.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(42, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 23);
            this.label7.TabIndex = 0;
            this.label7.Text = "Producto:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmLineaFacrec
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(690, 362);
            this.Controls.Add(this.pnData);
            this.Controls.Add(this.pnBtns);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLineaFacrec";
            this.Text = "Linea de Factura Recibida";
            this.Load += new System.EventHandler(this.FrmLineaFacrec_Load);
            this.pnBtns.ResumeLayout(false);
            this.pnData.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.gbCalculo.ResumeLayout(false);
            this.gbCalculo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTipoIva)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecio)).EndInit();
            this.gbProducto.ResumeLayout(false);
            this.gbProducto.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnBtns;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Panel pnData;
        private System.Windows.Forms.GroupBox gbProducto;
        private System.Windows.Forms.ComboBox cbProducto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnProducto;
        private System.Windows.Forms.GroupBox gbCalculo;
        private System.Windows.Forms.NumericUpDown numTipoIva;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numPrecio;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbCuota;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbBase;
        private System.Windows.Forms.Label label17;
    }
}
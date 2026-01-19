namespace FacturacionDAM.Formularios
{
    partial class FrmLineaFacrec
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            gbAyuda = new GroupBox();
            btnTrasladar = new Button();
            cbProducto = new ComboBox();
            label1 = new Label();
            gbDatos = new GroupBox();
            numTipoIva = new NumericUpDown();
            label5 = new Label();
            numPrecio = new NumericUpDown();
            label4 = new Label();
            numCantidad = new NumericUpDown();
            label3 = new Label();
            txtDescripcion = new TextBox();
            label2 = new Label();
            gbResumen = new GroupBox();
            lbTotal = new Label();
            label10 = new Label();
            lbIva = new Label();
            label8 = new Label();
            lbBase = new Label();
            label6 = new Label();
            btnAceptar = new Button();
            btnCancelar = new Button();
            gbAyuda.SuspendLayout();
            gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numTipoIva).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrecio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            gbResumen.SuspendLayout();
            SuspendLayout();
            // 
            // gbAyuda
            // 
            gbAyuda.Controls.Add(btnTrasladar);
            gbAyuda.Controls.Add(cbProducto);
            gbAyuda.Controls.Add(label1);
            gbAyuda.Location = new Point(12, 12);
            gbAyuda.Name = "gbAyuda";
            gbAyuda.Size = new Size(460, 65);
            gbAyuda.TabIndex = 0;
            gbAyuda.TabStop = false;
            gbAyuda.Text = "Ayuda: Buscar en catálogo de productos";
            // 
            // btnTrasladar
            // 
            btnTrasladar.Location = new Point(365, 27);
            btnTrasladar.Name = "btnTrasladar";
            btnTrasladar.Size = new Size(75, 25);
            btnTrasladar.TabIndex = 2;
            btnTrasladar.Text = "Trasladar";
            btnTrasladar.UseVisualStyleBackColor = true;
            btnTrasladar.Click += btnTrasladar_Click;
            // 
            // cbProducto
            // 
            cbProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            cbProducto.FormattingEnabled = true;
            cbProducto.Location = new Point(78, 28);
            cbProducto.Name = "cbProducto";
            cbProducto.Size = new Size(270, 23);
            cbProducto.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 31);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.Text = "Producto:";
            // 
            // gbDatos
            // 
            gbDatos.Controls.Add(numTipoIva);
            gbDatos.Controls.Add(label5);
            gbDatos.Controls.Add(numPrecio);
            gbDatos.Controls.Add(label4);
            gbDatos.Controls.Add(numCantidad);
            gbDatos.Controls.Add(label3);
            gbDatos.Controls.Add(txtDescripcion);
            gbDatos.Controls.Add(label2);
            gbDatos.Location = new Point(12, 83);
            gbDatos.Name = "gbDatos";
            gbDatos.Size = new Size(460, 110);
            gbDatos.TabIndex = 1;
            gbDatos.TabStop = false;
            gbDatos.Text = "Detalles de la línea de compra";
            // 
            // numTipoIva
            // 
            numTipoIva.DecimalPlaces = 2;
            numTipoIva.Location = new Point(365, 74);
            numTipoIva.Name = "numTipoIva";
            numTipoIva.Size = new Size(75, 23);
            numTipoIva.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(315, 78);
            label5.Name = "label5";
            label5.Size = new Size(37, 15);
            label5.Text = "% IVA";
            // 
            // numPrecio
            // 
            numPrecio.DecimalPlaces = 2;
            numPrecio.Location = new Point(194, 74);
            numPrecio.Name = "numPrecio";
            numPrecio.Size = new Size(95, 23);
            numPrecio.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(148, 78);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.Text = "Precio";
            // 
            // numCantidad
            // 
            numCantidad.DecimalPlaces = 2;
            numCantidad.Location = new Point(78, 74);
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(60, 23);
            numCantidad.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 78);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.Text = "Cantidad:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(94, 30);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(346, 23);
            txtDescripcion.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 33);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.Text = "Descripción:";
            // 
            // gbResumen
            // 
            gbResumen.Controls.Add(lbTotal);
            gbResumen.Controls.Add(label10);
            gbResumen.Controls.Add(lbIva);
            gbResumen.Controls.Add(label8);
            gbResumen.Controls.Add(lbBase);
            gbResumen.Controls.Add(label6);
            gbResumen.Location = new Point(12, 199);
            gbResumen.Name = "gbResumen";
            gbResumen.Size = new Size(460, 60);
            gbResumen.TabIndex = 2;
            gbResumen.TabStop = false;
            gbResumen.Text = "Importes de la línea";
            // 
            // lbTotal
            // 
            lbTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbTotal.Location = new Point(340, 33);
            lbTotal.Name = "lbTotal";
            lbTotal.Size = new Size(100, 15);
            lbTotal.Text = "0,00 €";
            lbTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(340, 17);
            label10.Name = "label10";
            label10.Size = new Size(32, 15);
            label10.Text = "Total";
            // 
            // lbIva
            // 
            lbIva.Location = new Point(194, 33);
            lbIva.Name = "lbIva";
            lbIva.Size = new Size(80, 15);
            lbIva.Text = "0,00 €";
            lbIva.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(194, 17);
            label8.Name = "label8";
            label8.Size = new Size(24, 15);
            label8.Text = "IVA";
            // 
            // lbBase
            // 
            lbBase.Location = new Point(13, 33);
            lbBase.Name = "lbBase";
            lbBase.Size = new Size(80, 15);
            lbBase.Text = "0,00 €";
            lbBase.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 17);
            label6.Name = "label6";
            label6.Size = new Size(31, 15);
            label6.Text = "Base";
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(296, 275);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(85, 30);
            btnAceptar.TabIndex = 3;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(387, 275);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(85, 30);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmLineaFacrec
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 321);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(gbResumen);
            Controls.Add(gbDatos);
            Controls.Add(gbAyuda);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmLineaFacrec";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Línea de Factura de Compra";
            Load += FrmLineaFacrec_Load;
            gbAyuda.ResumeLayout(false);
            gbAyuda.PerformLayout();
            gbDatos.ResumeLayout(false);
            gbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numTipoIva).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrecio).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            gbResumen.ResumeLayout(false);
            gbResumen.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbAyuda;
        private Label label1;
        private ComboBox cbProducto;
        private Button btnTrasladar;
        private GroupBox gbDatos;
        private Label label2;
        private TextBox txtDescripcion;
        private Label label3;
        private NumericUpDown numCantidad;
        private Label label4;
        private NumericUpDown numPrecio;
        private Label label5;
        private NumericUpDown numTipoIva;
        private GroupBox gbResumen;
        private Label label6;
        private Label lbBase;
        private Label label8;
        private Label lbIva;
        private Label label10;
        private Label lbTotal;
        private Button btnAceptar;
        private Button btnCancelar;
    }
}
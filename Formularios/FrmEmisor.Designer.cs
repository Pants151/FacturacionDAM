namespace FacturacionDAM.Formularios
{
    partial class FrmEmisor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEmisor));
            pnBtns = new Panel();
            btnCancelar = new Button();
            btnAceptar = new Button();
            pnData = new Panel();
            tabControl1 = new TabControl();
            tabData = new TabPage();
            groupBox1 = new GroupBox();
            txtPrefixFac = new TextBox();
            label6 = new Label();
            txtNextNumFac = new TextBox();
            label5 = new Label();
            gbContacto = new GroupBox();
            txtEmail = new TextBox();
            label13 = new Label();
            txtTel2 = new TextBox();
            label12 = new Label();
            txtTel1 = new TextBox();
            label11 = new Label();
            gbDomicilio = new GroupBox();
            cbProv = new ComboBox();
            label10 = new Label();
            txtPob = new TextBox();
            label9 = new Label();
            txtCp = new TextBox();
            label8 = new Label();
            txtDomicilio = new TextBox();
            label7 = new Label();
            gbIdentificacion = new GroupBox();
            txtApellidos = new TextBox();
            txtNombre = new TextBox();
            label3 = new Label();
            label4 = new Label();
            txtNombreComercial = new TextBox();
            txtNifCif = new TextBox();
            label2 = new Label();
            label1 = new Label();
            tabDescripcion = new TabPage();
            txtDescripcion = new RichTextBox();
            pnBtns.SuspendLayout();
            pnData.SuspendLayout();
            tabControl1.SuspendLayout();
            tabData.SuspendLayout();
            groupBox1.SuspendLayout();
            gbContacto.SuspendLayout();
            gbDomicilio.SuspendLayout();
            gbIdentificacion.SuspendLayout();
            tabDescripcion.SuspendLayout();
            SuspendLayout();
            // 
            // pnBtns
            // 
            pnBtns.Controls.Add(btnCancelar);
            pnBtns.Controls.Add(btnAceptar);
            pnBtns.Dock = DockStyle.Bottom;
            pnBtns.Location = new Point(0, 483);
            pnBtns.Name = "pnBtns";
            pnBtns.Size = new Size(811, 63);
            pnBtns.TabIndex = 0;
            // 
            // btnCancelar
            // 
            btnCancelar.Image = (Image)resources.GetObject("btnCancelar.Image");
            btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelar.Location = new Point(448, 14);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Padding = new Padding(10, 0, 10, 0);
            btnCancelar.Size = new Size(100, 36);
            btnCancelar.TabIndex = 15;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextAlign = ContentAlignment.MiddleRight;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Image = (Image)resources.GetObject("btnAceptar.Image");
            btnAceptar.ImageAlign = ContentAlignment.MiddleLeft;
            btnAceptar.Location = new Point(245, 14);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Padding = new Padding(10, 0, 10, 0);
            btnAceptar.Size = new Size(100, 36);
            btnAceptar.TabIndex = 14;
            btnAceptar.Text = "Aceptar";
            btnAceptar.TextAlign = ContentAlignment.MiddleRight;
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // pnData
            // 
            pnData.Controls.Add(tabControl1);
            pnData.Dock = DockStyle.Fill;
            pnData.Location = new Point(0, 0);
            pnData.Name = "pnData";
            pnData.Size = new Size(811, 483);
            pnData.TabIndex = 1;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabData);
            tabControl1.Controls.Add(tabDescripcion);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(811, 483);
            tabControl1.TabIndex = 0;
            // 
            // tabData
            // 
            tabData.Controls.Add(groupBox1);
            tabData.Controls.Add(gbContacto);
            tabData.Controls.Add(gbDomicilio);
            tabData.Controls.Add(gbIdentificacion);
            tabData.Location = new Point(4, 24);
            tabData.Name = "tabData";
            tabData.Padding = new Padding(3, 3, 3, 3);
            tabData.Size = new Size(803, 455);
            tabData.TabIndex = 0;
            tabData.Text = "Datos";
            tabData.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtPrefixFac);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtNextNumFac);
            groupBox1.Controls.Add(label5);
            groupBox1.Location = new Point(21, 368);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(744, 73);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Facturación";
            // 
            // txtPrefixFac
            // 
            txtPrefixFac.Location = new Point(281, 29);
            txtPrefixFac.MaxLength = 10;
            txtPrefixFac.Name = "txtPrefixFac";
            txtPrefixFac.Size = new Size(80, 23);
            txtPrefixFac.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(231, 32);
            label6.Name = "label6";
            label6.Size = new Size(44, 15);
            label6.TabIndex = 2;
            label6.Text = "Prefijo:";
            // 
            // txtNextNumFac
            // 
            txtNextNumFac.Location = new Point(119, 29);
            txtNextNumFac.MaxLength = 11;
            txtNextNumFac.Name = "txtNextNumFac";
            txtNextNumFac.Size = new Size(69, 23);
            txtNextNumFac.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(39, 32);
            label5.Name = "label5";
            label5.Size = new Size(74, 15);
            label5.TabIndex = 0;
            label5.Text = "Siguiente nº:";
            // 
            // gbContacto
            // 
            gbContacto.Controls.Add(txtEmail);
            gbContacto.Controls.Add(label13);
            gbContacto.Controls.Add(txtTel2);
            gbContacto.Controls.Add(label12);
            gbContacto.Controls.Add(txtTel1);
            gbContacto.Controls.Add(label11);
            gbContacto.Location = new Point(21, 242);
            gbContacto.Name = "gbContacto";
            gbContacto.Size = new Size(744, 108);
            gbContacto.TabIndex = 2;
            gbContacto.TabStop = false;
            gbContacto.Text = "Contacto";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(105, 63);
            txtEmail.MaxLength = 150;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(443, 23);
            txtEmail.TabIndex = 11;
            // 
            // label13
            // 
            label13.Location = new Point(10, 63);
            label13.Name = "label13";
            label13.Size = new Size(86, 23);
            label13.TabIndex = 4;
            label13.Text = "Email:";
            label13.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtTel2
            // 
            txtTel2.Location = new Point(387, 26);
            txtTel2.MaxLength = 20;
            txtTel2.Name = "txtTel2";
            txtTel2.Size = new Size(161, 23);
            txtTel2.TabIndex = 10;
            // 
            // label12
            // 
            label12.Location = new Point(313, 30);
            label12.Name = "label12";
            label12.Size = new Size(64, 15);
            label12.TabIndex = 2;
            label12.Text = "Teléfono 2:";
            label12.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtTel1
            // 
            txtTel1.Location = new Point(105, 26);
            txtTel1.MaxLength = 20;
            txtTel1.Name = "txtTel1";
            txtTel1.Size = new Size(161, 23);
            txtTel1.TabIndex = 9;
            // 
            // label11
            // 
            label11.Location = new Point(10, 26);
            label11.Name = "label11";
            label11.Size = new Size(86, 23);
            label11.TabIndex = 0;
            label11.Text = "Teléfono 1:";
            label11.TextAlign = ContentAlignment.MiddleRight;
            // 
            // gbDomicilio
            // 
            gbDomicilio.Controls.Add(cbProv);
            gbDomicilio.Controls.Add(label10);
            gbDomicilio.Controls.Add(txtPob);
            gbDomicilio.Controls.Add(label9);
            gbDomicilio.Controls.Add(txtCp);
            gbDomicilio.Controls.Add(label8);
            gbDomicilio.Controls.Add(txtDomicilio);
            gbDomicilio.Controls.Add(label7);
            gbDomicilio.Location = new Point(21, 127);
            gbDomicilio.Name = "gbDomicilio";
            gbDomicilio.Size = new Size(744, 109);
            gbDomicilio.TabIndex = 1;
            gbDomicilio.TabStop = false;
            gbDomicilio.Text = "Domicilio";
            // 
            // cbProv
            // 
            cbProv.FormattingEnabled = true;
            cbProv.Location = new Point(529, 61);
            cbProv.Name = "cbProv";
            cbProv.Size = new Size(197, 23);
            cbProv.TabIndex = 8;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(464, 65);
            label10.Name = "label10";
            label10.Size = new Size(59, 15);
            label10.TabIndex = 6;
            label10.Text = "Provincia:";
            // 
            // txtPob
            // 
            txtPob.Location = new Point(105, 61);
            txtPob.MaxLength = 75;
            txtPob.Name = "txtPob";
            txtPob.Size = new Size(335, 23);
            txtPob.TabIndex = 7;
            // 
            // label9
            // 
            label9.Location = new Point(10, 61);
            label9.Name = "label9";
            label9.Size = new Size(86, 23);
            label9.TabIndex = 4;
            label9.Text = "Población:";
            label9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtCp
            // 
            txtCp.Location = new Point(651, 27);
            txtCp.MaxLength = 5;
            txtCp.Name = "txtCp";
            txtCp.Size = new Size(75, 23);
            txtCp.TabIndex = 6;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(556, 31);
            label8.Name = "label8";
            label8.Size = new Size(84, 15);
            label8.TabIndex = 2;
            label8.Text = "Código Postal:";
            // 
            // txtDomicilio
            // 
            txtDomicilio.Location = new Point(105, 27);
            txtDomicilio.MaxLength = 200;
            txtDomicilio.Name = "txtDomicilio";
            txtDomicilio.PlaceholderText = "Calle, número, planta, ...";
            txtDomicilio.Size = new Size(418, 23);
            txtDomicilio.TabIndex = 5;
            // 
            // label7
            // 
            label7.Location = new Point(10, 27);
            label7.Name = "label7";
            label7.Size = new Size(86, 23);
            label7.TabIndex = 0;
            label7.Text = "Domicilio:";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // gbIdentificacion
            // 
            gbIdentificacion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbIdentificacion.Controls.Add(txtApellidos);
            gbIdentificacion.Controls.Add(txtNombre);
            gbIdentificacion.Controls.Add(label3);
            gbIdentificacion.Controls.Add(label4);
            gbIdentificacion.Controls.Add(txtNombreComercial);
            gbIdentificacion.Controls.Add(txtNifCif);
            gbIdentificacion.Controls.Add(label2);
            gbIdentificacion.Controls.Add(label1);
            gbIdentificacion.Location = new Point(21, 21);
            gbIdentificacion.Name = "gbIdentificacion";
            gbIdentificacion.Size = new Size(744, 100);
            gbIdentificacion.TabIndex = 0;
            gbIdentificacion.TabStop = false;
            gbIdentificacion.Text = "Identidad";
            // 
            // txtApellidos
            // 
            txtApellidos.Location = new Point(472, 57);
            txtApellidos.MaxLength = 75;
            txtApellidos.Name = "txtApellidos";
            txtApellidos.Size = new Size(245, 23);
            txtApellidos.TabIndex = 4;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(472, 25);
            txtNombre.MaxLength = 30;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(156, 23);
            txtNombre.TabIndex = 2;
            // 
            // label3
            // 
            label3.Location = new Point(391, 57);
            label3.Name = "label3";
            label3.Size = new Size(73, 23);
            label3.TabIndex = 5;
            label3.Text = "Apellidos:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.Location = new Point(391, 25);
            label4.Name = "label4";
            label4.Size = new Size(73, 23);
            label4.TabIndex = 4;
            label4.Text = "Nombre:";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtNombreComercial
            // 
            txtNombreComercial.Location = new Point(105, 57);
            txtNombreComercial.MaxLength = 150;
            txtNombreComercial.Name = "txtNombreComercial";
            txtNombreComercial.Size = new Size(272, 23);
            txtNombreComercial.TabIndex = 3;
            // 
            // txtNifCif
            // 
            txtNifCif.Location = new Point(105, 25);
            txtNifCif.MaxLength = 9;
            txtNifCif.Name = "txtNifCif";
            txtNifCif.Size = new Size(121, 23);
            txtNifCif.TabIndex = 1;
            // 
            // label2
            // 
            label2.Location = new Point(10, 57);
            label2.Name = "label2";
            label2.Size = new Size(86, 23);
            label2.TabIndex = 1;
            label2.Text = "Razón Social:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.Location = new Point(10, 25);
            label1.Name = "label1";
            label1.Size = new Size(86, 23);
            label1.TabIndex = 0;
            label1.Text = "NIF/CIF:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tabDescripcion
            // 
            tabDescripcion.Controls.Add(txtDescripcion);
            tabDescripcion.Location = new Point(4, 24);
            tabDescripcion.Name = "tabDescripcion";
            tabDescripcion.Padding = new Padding(3, 3, 3, 3);
            tabDescripcion.Size = new Size(803, 455);
            tabDescripcion.TabIndex = 1;
            tabDescripcion.Text = "Otros detalles";
            tabDescripcion.UseVisualStyleBackColor = true;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Dock = DockStyle.Fill;
            txtDescripcion.Location = new Point(3, 3);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(797, 449);
            txtDescripcion.TabIndex = 0;
            txtDescripcion.Text = "";
            // 
            // FrmEmisor
            // 
            AcceptButton = btnAceptar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(811, 546);
            Controls.Add(pnData);
            Controls.Add(pnBtns);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmEmisor";
            Text = "Datos del Emisor";
            Load += FrmEmisor_Load;
            pnBtns.ResumeLayout(false);
            pnData.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabData.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            gbContacto.ResumeLayout(false);
            gbContacto.PerformLayout();
            gbDomicilio.ResumeLayout(false);
            gbDomicilio.PerformLayout();
            gbIdentificacion.ResumeLayout(false);
            gbIdentificacion.PerformLayout();
            tabDescripcion.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnBtns;
        private Button btnCancelar;
        private Button btnAceptar;
        private Panel pnData;
        private TabControl tabControl1;
        private TabPage tabData;
        private TabPage tabDescripcion;
        private GroupBox gbDomicilio;
        private GroupBox gbIdentificacion;
        private GroupBox gbContacto;
        private TextBox txtNombreComercial;
        private TextBox txtNifCif;
        private Label label2;
        private Label label1;
        private GroupBox groupBox1;
        private TextBox txtPrefixFac;
        private Label label6;
        private TextBox txtNextNumFac;
        private Label label5;
        private TextBox txtApellidos;
        private TextBox txtNombre;
        private Label label3;
        private Label label4;
        private RichTextBox txtDescripcion;
        private TextBox txtDomicilio;
        private Label label7;
        private TextBox txtCp;
        private Label label8;
        private Label label11;
        private ComboBox cbProv;
        private Label label10;
        private TextBox txtPob;
        private Label label9;
        private TextBox txtTel1;
        private TextBox txtEmail;
        private Label label13;
        private TextBox txtTel2;
        private Label label12;
    }
}
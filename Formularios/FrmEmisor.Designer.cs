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
            panel1 = new Panel();
            btn_cancelar = new Button();
            btn_aceptar = new Button();
            tab_emisor = new TabControl();
            tpage_datos = new TabPage();
            gbox_facturacion = new GroupBox();
            txt_siguientenum = new TextBox();
            lbl_prefijo = new Label();
            lbl_siguientenum = new Label();
            txt_prefijo = new TextBox();
            gbox_contacto = new GroupBox();
            txt_email = new TextBox();
            lbl_email = new Label();
            txt_telefono1 = new TextBox();
            lbl_telefono2 = new Label();
            txt_telefono2 = new TextBox();
            lbl_telefono1 = new Label();
            gbox_direccion = new GroupBox();
            cbox_provincia = new ComboBox();
            txt_poblacion = new TextBox();
            lbl_provincia = new Label();
            lbl_poblacion = new Label();
            txt_domicilio = new TextBox();
            lbl_codigopostal = new Label();
            txt_codigopostal = new TextBox();
            lbl_domicilio = new Label();
            gbox_identidad = new GroupBox();
            txt_razonsocial = new TextBox();
            lbl_apellidos = new Label();
            txt_apellidos = new TextBox();
            lbl_razonsocial = new Label();
            txt_nifcif = new TextBox();
            lbl_nombre = new Label();
            txt_nombre = new TextBox();
            lbl_nifcif = new Label();
            tpage_otrosdetalles = new TabPage();
            panel1.SuspendLayout();
            tab_emisor.SuspendLayout();
            tpage_datos.SuspendLayout();
            gbox_facturacion.SuspendLayout();
            gbox_contacto.SuspendLayout();
            gbox_direccion.SuspendLayout();
            gbox_identidad.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btn_cancelar);
            panel1.Controls.Add(btn_aceptar);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 578);
            panel1.Name = "panel1";
            panel1.Size = new Size(787, 60);
            panel1.TabIndex = 0;
            // 
            // btn_cancelar
            // 
            btn_cancelar.Image = (Image)resources.GetObject("btn_cancelar.Image");
            btn_cancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btn_cancelar.Location = new Point(463, 18);
            btn_cancelar.Name = "btn_cancelar";
            btn_cancelar.Size = new Size(80, 23);
            btn_cancelar.TabIndex = 1;
            btn_cancelar.Text = "Cancelar";
            btn_cancelar.TextAlign = ContentAlignment.MiddleRight;
            btn_cancelar.UseVisualStyleBackColor = true;
            // 
            // btn_aceptar
            // 
            btn_aceptar.Image = (Image)resources.GetObject("btn_aceptar.Image");
            btn_aceptar.ImageAlign = ContentAlignment.MiddleLeft;
            btn_aceptar.Location = new Point(235, 18);
            btn_aceptar.Name = "btn_aceptar";
            btn_aceptar.Size = new Size(78, 23);
            btn_aceptar.TabIndex = 0;
            btn_aceptar.Text = "Aceptar";
            btn_aceptar.TextAlign = ContentAlignment.MiddleRight;
            btn_aceptar.UseVisualStyleBackColor = true;
            // 
            // tab_emisor
            // 
            tab_emisor.Controls.Add(tpage_datos);
            tab_emisor.Controls.Add(tpage_otrosdetalles);
            tab_emisor.Dock = DockStyle.Fill;
            tab_emisor.Location = new Point(0, 0);
            tab_emisor.Name = "tab_emisor";
            tab_emisor.SelectedIndex = 0;
            tab_emisor.Size = new Size(787, 578);
            tab_emisor.TabIndex = 1;
            // 
            // tpage_datos
            // 
            tpage_datos.Controls.Add(gbox_facturacion);
            tpage_datos.Controls.Add(gbox_contacto);
            tpage_datos.Controls.Add(gbox_direccion);
            tpage_datos.Controls.Add(gbox_identidad);
            tpage_datos.Location = new Point(4, 24);
            tpage_datos.Name = "tpage_datos";
            tpage_datos.Padding = new Padding(3);
            tpage_datos.Size = new Size(779, 550);
            tpage_datos.TabIndex = 0;
            tpage_datos.Text = "Datos";
            tpage_datos.UseVisualStyleBackColor = true;
            // 
            // gbox_facturacion
            // 
            gbox_facturacion.Controls.Add(txt_siguientenum);
            gbox_facturacion.Controls.Add(lbl_prefijo);
            gbox_facturacion.Controls.Add(lbl_siguientenum);
            gbox_facturacion.Controls.Add(txt_prefijo);
            gbox_facturacion.Location = new Point(16, 448);
            gbox_facturacion.Name = "gbox_facturacion";
            gbox_facturacion.Size = new Size(747, 81);
            gbox_facturacion.TabIndex = 14;
            gbox_facturacion.TabStop = false;
            gbox_facturacion.Text = "Facturación";
            // 
            // txt_siguientenum
            // 
            txt_siguientenum.Location = new Point(99, 32);
            txt_siguientenum.Name = "txt_siguientenum";
            txt_siguientenum.Size = new Size(161, 23);
            txt_siguientenum.TabIndex = 11;
            // 
            // lbl_prefijo
            // 
            lbl_prefijo.AutoSize = true;
            lbl_prefijo.Location = new Point(293, 40);
            lbl_prefijo.Name = "lbl_prefijo";
            lbl_prefijo.Size = new Size(41, 15);
            lbl_prefijo.TabIndex = 10;
            lbl_prefijo.Text = "Prefijo";
            // 
            // lbl_siguientenum
            // 
            lbl_siguientenum.AutoSize = true;
            lbl_siguientenum.Location = new Point(22, 40);
            lbl_siguientenum.Name = "lbl_siguientenum";
            lbl_siguientenum.Size = new Size(71, 15);
            lbl_siguientenum.TabIndex = 8;
            lbl_siguientenum.Text = "Siguiente nº";
            // 
            // txt_prefijo
            // 
            txt_prefijo.Location = new Point(340, 32);
            txt_prefijo.Name = "txt_prefijo";
            txt_prefijo.Size = new Size(153, 23);
            txt_prefijo.TabIndex = 9;
            // 
            // gbox_contacto
            // 
            gbox_contacto.Controls.Add(txt_email);
            gbox_contacto.Controls.Add(lbl_email);
            gbox_contacto.Controls.Add(txt_telefono1);
            gbox_contacto.Controls.Add(lbl_telefono2);
            gbox_contacto.Controls.Add(txt_telefono2);
            gbox_contacto.Controls.Add(lbl_telefono1);
            gbox_contacto.Location = new Point(16, 303);
            gbox_contacto.Name = "gbox_contacto";
            gbox_contacto.Size = new Size(747, 130);
            gbox_contacto.TabIndex = 13;
            gbox_contacto.TabStop = false;
            gbox_contacto.Text = "Contacto";
            // 
            // txt_email
            // 
            txt_email.Location = new Point(64, 80);
            txt_email.Name = "txt_email";
            txt_email.Size = new Size(369, 23);
            txt_email.TabIndex = 7;
            // 
            // lbl_email
            // 
            lbl_email.AutoSize = true;
            lbl_email.Location = new Point(22, 83);
            lbl_email.Name = "lbl_email";
            lbl_email.Size = new Size(36, 15);
            lbl_email.TabIndex = 4;
            lbl_email.Text = "Email";
            // 
            // txt_telefono1
            // 
            txt_telefono1.Location = new Point(107, 42);
            txt_telefono1.Name = "txt_telefono1";
            txt_telefono1.Size = new Size(161, 23);
            txt_telefono1.TabIndex = 3;
            // 
            // lbl_telefono2
            // 
            lbl_telefono2.AutoSize = true;
            lbl_telefono2.Location = new Point(293, 45);
            lbl_telefono2.Name = "lbl_telefono2";
            lbl_telefono2.Size = new Size(79, 15);
            lbl_telefono2.TabIndex = 2;
            lbl_telefono2.Text = "Teléfono Nº2:";
            // 
            // txt_telefono2
            // 
            txt_telefono2.Location = new Point(378, 42);
            txt_telefono2.Name = "txt_telefono2";
            txt_telefono2.Size = new Size(153, 23);
            txt_telefono2.TabIndex = 1;
            // 
            // lbl_telefono1
            // 
            lbl_telefono1.AutoSize = true;
            lbl_telefono1.Location = new Point(22, 45);
            lbl_telefono1.Name = "lbl_telefono1";
            lbl_telefono1.Size = new Size(79, 15);
            lbl_telefono1.TabIndex = 0;
            lbl_telefono1.Text = "Teléfono Nº1:";
            // 
            // gbox_direccion
            // 
            gbox_direccion.Controls.Add(cbox_provincia);
            gbox_direccion.Controls.Add(txt_poblacion);
            gbox_direccion.Controls.Add(lbl_provincia);
            gbox_direccion.Controls.Add(lbl_poblacion);
            gbox_direccion.Controls.Add(txt_domicilio);
            gbox_direccion.Controls.Add(lbl_codigopostal);
            gbox_direccion.Controls.Add(txt_codigopostal);
            gbox_direccion.Controls.Add(lbl_domicilio);
            gbox_direccion.Location = new Point(16, 159);
            gbox_direccion.Name = "gbox_direccion";
            gbox_direccion.Size = new Size(747, 130);
            gbox_direccion.TabIndex = 12;
            gbox_direccion.TabStop = false;
            gbox_direccion.Text = "Dirección";
            // 
            // cbox_provincia
            // 
            cbox_provincia.FormattingEnabled = true;
            cbox_provincia.Location = new Point(622, 75);
            cbox_provincia.Name = "cbox_provincia";
            cbox_provincia.Size = new Size(112, 23);
            cbox_provincia.TabIndex = 8;
            // 
            // txt_poblacion
            // 
            txt_poblacion.Location = new Point(81, 80);
            txt_poblacion.Name = "txt_poblacion";
            txt_poblacion.Size = new Size(369, 23);
            txt_poblacion.TabIndex = 7;
            // 
            // lbl_provincia
            // 
            lbl_provincia.AutoSize = true;
            lbl_provincia.Location = new Point(560, 83);
            lbl_provincia.Name = "lbl_provincia";
            lbl_provincia.Size = new Size(56, 15);
            lbl_provincia.TabIndex = 6;
            lbl_provincia.Text = "Provincia";
            // 
            // lbl_poblacion
            // 
            lbl_poblacion.AutoSize = true;
            lbl_poblacion.Location = new Point(17, 83);
            lbl_poblacion.Name = "lbl_poblacion";
            lbl_poblacion.Size = new Size(60, 15);
            lbl_poblacion.TabIndex = 4;
            lbl_poblacion.Text = "Población";
            // 
            // txt_domicilio
            // 
            txt_domicilio.Location = new Point(81, 37);
            txt_domicilio.Name = "txt_domicilio";
            txt_domicilio.Size = new Size(369, 23);
            txt_domicilio.TabIndex = 3;
            // 
            // lbl_codigopostal
            // 
            lbl_codigopostal.AutoSize = true;
            lbl_codigopostal.Location = new Point(535, 40);
            lbl_codigopostal.Name = "lbl_codigopostal";
            lbl_codigopostal.Size = new Size(81, 15);
            lbl_codigopostal.TabIndex = 2;
            lbl_codigopostal.Text = "Código Postal";
            // 
            // txt_codigopostal
            // 
            txt_codigopostal.Location = new Point(622, 37);
            txt_codigopostal.Name = "txt_codigopostal";
            txt_codigopostal.Size = new Size(112, 23);
            txt_codigopostal.TabIndex = 1;
            // 
            // lbl_domicilio
            // 
            lbl_domicilio.AutoSize = true;
            lbl_domicilio.Location = new Point(17, 40);
            lbl_domicilio.Name = "lbl_domicilio";
            lbl_domicilio.Size = new Size(58, 15);
            lbl_domicilio.TabIndex = 0;
            lbl_domicilio.Text = "Domicilio";
            // 
            // gbox_identidad
            // 
            gbox_identidad.Controls.Add(txt_razonsocial);
            gbox_identidad.Controls.Add(lbl_apellidos);
            gbox_identidad.Controls.Add(txt_apellidos);
            gbox_identidad.Controls.Add(lbl_razonsocial);
            gbox_identidad.Controls.Add(txt_nifcif);
            gbox_identidad.Controls.Add(lbl_nombre);
            gbox_identidad.Controls.Add(txt_nombre);
            gbox_identidad.Controls.Add(lbl_nifcif);
            gbox_identidad.Location = new Point(16, 15);
            gbox_identidad.Name = "gbox_identidad";
            gbox_identidad.Size = new Size(747, 129);
            gbox_identidad.TabIndex = 11;
            gbox_identidad.TabStop = false;
            gbox_identidad.Text = "Identidad";
            // 
            // txt_razonsocial
            // 
            txt_razonsocial.Location = new Point(99, 81);
            txt_razonsocial.Name = "txt_razonsocial";
            txt_razonsocial.Size = new Size(152, 23);
            txt_razonsocial.TabIndex = 7;
            // 
            // lbl_apellidos
            // 
            lbl_apellidos.AutoSize = true;
            lbl_apellidos.Location = new Point(467, 89);
            lbl_apellidos.Name = "lbl_apellidos";
            lbl_apellidos.Size = new Size(56, 15);
            lbl_apellidos.TabIndex = 6;
            lbl_apellidos.Text = "Apellidos";
            // 
            // txt_apellidos
            // 
            txt_apellidos.Location = new Point(524, 81);
            txt_apellidos.Name = "txt_apellidos";
            txt_apellidos.Size = new Size(192, 23);
            txt_apellidos.TabIndex = 5;
            // 
            // lbl_razonsocial
            // 
            lbl_razonsocial.AutoSize = true;
            lbl_razonsocial.Location = new Point(22, 89);
            lbl_razonsocial.Name = "lbl_razonsocial";
            lbl_razonsocial.Size = new Size(73, 15);
            lbl_razonsocial.TabIndex = 4;
            lbl_razonsocial.Text = "Razón Social";
            // 
            // txt_nifcif
            // 
            txt_nifcif.Location = new Point(75, 37);
            txt_nifcif.Name = "txt_nifcif";
            txt_nifcif.Size = new Size(152, 23);
            txt_nifcif.TabIndex = 3;
            // 
            // lbl_nombre
            // 
            lbl_nombre.AutoSize = true;
            lbl_nombre.Location = new Point(467, 45);
            lbl_nombre.Name = "lbl_nombre";
            lbl_nombre.Size = new Size(51, 15);
            lbl_nombre.TabIndex = 2;
            lbl_nombre.Text = "Nombre";
            // 
            // txt_nombre
            // 
            txt_nombre.Location = new Point(524, 37);
            txt_nombre.Name = "txt_nombre";
            txt_nombre.Size = new Size(192, 23);
            txt_nombre.TabIndex = 1;
            // 
            // lbl_nifcif
            // 
            lbl_nifcif.AutoSize = true;
            lbl_nifcif.Location = new Point(22, 45);
            lbl_nifcif.Name = "lbl_nifcif";
            lbl_nifcif.Size = new Size(47, 15);
            lbl_nifcif.TabIndex = 0;
            lbl_nifcif.Text = "NIF/CIF";
            // 
            // tpage_otrosdetalles
            // 
            tpage_otrosdetalles.Location = new Point(4, 24);
            tpage_otrosdetalles.Name = "tpage_otrosdetalles";
            tpage_otrosdetalles.Padding = new Padding(3);
            tpage_otrosdetalles.Size = new Size(779, 550);
            tpage_otrosdetalles.TabIndex = 1;
            tpage_otrosdetalles.Text = "Otros detalles";
            tpage_otrosdetalles.UseVisualStyleBackColor = true;
            // 
            // FrmEmisor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(787, 638);
            Controls.Add(tab_emisor);
            Controls.Add(panel1);
            Name = "FrmEmisor";
            Text = "Insertar emisor";
            Load += FrmEmisor_Load;
            panel1.ResumeLayout(false);
            tab_emisor.ResumeLayout(false);
            tpage_datos.ResumeLayout(false);
            gbox_facturacion.ResumeLayout(false);
            gbox_facturacion.PerformLayout();
            gbox_contacto.ResumeLayout(false);
            gbox_contacto.PerformLayout();
            gbox_direccion.ResumeLayout(false);
            gbox_direccion.PerformLayout();
            gbox_identidad.ResumeLayout(false);
            gbox_identidad.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btn_cancelar;
        private Button btn_aceptar;
        private TabControl tab_emisor;
        private TabPage tpage_datos;
        private GroupBox gbox_facturacion;
        private TextBox txt_siguientenum;
        private Label lbl_prefijo;
        private Label lbl_siguientenum;
        private TextBox txt_prefijo;
        private GroupBox gbox_contacto;
        private TextBox txt_email;
        private Label lbl_email;
        private TextBox txt_telefono1;
        private Label lbl_telefono2;
        private TextBox txt_telefono2;
        private Label lbl_telefono1;
        private GroupBox gbox_direccion;
        private ComboBox cbox_provincia;
        private TextBox txt_poblacion;
        private Label lbl_provincia;
        private Label lbl_poblacion;
        private TextBox txt_domicilio;
        private Label lbl_codigopostal;
        private TextBox txt_codigopostal;
        private Label lbl_domicilio;
        private GroupBox gbox_identidad;
        private TextBox txt_razonsocial;
        private Label lbl_apellidos;
        private TextBox txt_apellidos;
        private Label lbl_razonsocial;
        private TextBox txt_nifcif;
        private Label lbl_nombre;
        private TextBox txt_nombre;
        private Label lbl_nifcif;
        private TabPage tpage_otrosdetalles;

  

    }
}
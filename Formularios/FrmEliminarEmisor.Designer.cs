namespace FacturacionDAM.Formularios
{
    partial class FrmEliminarEmisor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEliminarEmisor));
            btnCancelar = new Button();
            label1 = new Label();
            gbSeleccion = new GroupBox();
            btnSeleccionar = new Button();
            cbEmisores = new ComboBox();
            gbSeleccion.SuspendLayout();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Image = (Image)resources.GetObject("btnCancelar.Image");
            btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelar.Location = new Point(399, 170);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Padding = new Padding(12, 0, 6, 0);
            btnCancelar.Size = new Size(108, 38);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextAlign = ContentAlignment.MiddleRight;
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.Location = new Point(28, 22);
            label1.Name = "label1";
            label1.Size = new Size(278, 20);
            label1.TabIndex = 8;
            label1.Text = "Selecciona el emisor que quiera eliminar";
            // 
            // gbSeleccion
            // 
            gbSeleccion.Controls.Add(btnSeleccionar);
            gbSeleccion.Controls.Add(cbEmisores);
            gbSeleccion.Location = new Point(28, 68);
            gbSeleccion.Name = "gbSeleccion";
            gbSeleccion.Size = new Size(512, 84);
            gbSeleccion.TabIndex = 7;
            gbSeleccion.TabStop = false;
            gbSeleccion.Text = "Seleccione un emisor:";
            // 
            // btnSeleccionar
            // 
            btnSeleccionar.Image = (Image)resources.GetObject("btnSeleccionar.Image");
            btnSeleccionar.ImageAlign = ContentAlignment.MiddleLeft;
            btnSeleccionar.Location = new Point(371, 26);
            btnSeleccionar.Margin = new Padding(20, 3, 3, 3);
            btnSeleccionar.Name = "btnSeleccionar";
            btnSeleccionar.Padding = new Padding(10, 0, 6, 0);
            btnSeleccionar.Size = new Size(118, 33);
            btnSeleccionar.TabIndex = 4;
            btnSeleccionar.Text = "Seleccionar";
            btnSeleccionar.TextAlign = ContentAlignment.MiddleRight;
            btnSeleccionar.UseVisualStyleBackColor = true;
            // 
            // cbEmisores
            // 
            cbEmisores.FormattingEnabled = true;
            cbEmisores.Location = new Point(41, 32);
            cbEmisores.Name = "cbEmisores";
            cbEmisores.Size = new Size(307, 23);
            cbEmisores.TabIndex = 3;
            // 
            // FrmEliminarEmisor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(551, 229);
            Controls.Add(btnCancelar);
            Controls.Add(label1);
            Controls.Add(gbSeleccion);
            Name = "FrmEliminarEmisor";
            Text = "FrmEliminarEmisor";
            Load += FrmEliminarEmisor_Load;
            gbSeleccion.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnCancelar;
        private Label label1;
        private GroupBox gbSeleccion;
        private Button btnSeleccionar;
        private ComboBox cbEmisores;
    }
}
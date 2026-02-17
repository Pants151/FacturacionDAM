namespace FacturacionDAM.Formularios
{
    partial class FrmInformFacemiAnual
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
            fecha_inicio = new DateTimePicker();
            label1 = new Label();
            btn_informe = new Button();
            label2 = new Label();
            fecha_final = new DateTimePicker();
            SuspendLayout();
            // 
            // fecha_inicio
            // 
            fecha_inicio.Format = DateTimePickerFormat.Short;
            fecha_inicio.Location = new Point(14, 44);
            fecha_inicio.Name = "fecha_inicio";
            fecha_inicio.Size = new Size(103, 23);
            fecha_inicio.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 26);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 2;
            label1.Text = "Fecha inicial";
            // 
            // btn_informe
            // 
            btn_informe.Font = new Font("Segoe UI", 14F);
            btn_informe.Location = new Point(66, 78);
            btn_informe.Name = "btn_informe";
            btn_informe.Size = new Size(188, 49);
            btn_informe.TabIndex = 3;
            btn_informe.Text = "Generar Informe";
            btn_informe.UseVisualStyleBackColor = true;
            btn_informe.Click += btn_informe_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(194, 26);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 5;
            label2.Text = "Fecha inicial";
            // 
            // fecha_final
            // 
            fecha_final.Format = DateTimePickerFormat.Short;
            fecha_final.Location = new Point(194, 44);
            fecha_final.Name = "fecha_final";
            fecha_final.Size = new Size(103, 23);
            fecha_final.TabIndex = 4;
            // 
            // FrmInformFacemiAnual
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(311, 140);
            Controls.Add(label2);
            Controls.Add(fecha_final);
            Controls.Add(btn_informe);
            Controls.Add(label1);
            Controls.Add(fecha_inicio);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmInformFacemiAnual";
            Text = "Facturas Emitidas entre fechas";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Button btn_informe;
        private Label label2;
        public DateTimePicker fecha_inicio;
        public DateTimePicker fecha_final;
    }
}
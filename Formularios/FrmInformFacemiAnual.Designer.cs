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
            btn_informe_agrupado = new Button();
            label3 = new Label();
            label4 = new Label();
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
            btn_informe.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_informe.Location = new Point(264, 91);
            btn_informe.Name = "btn_informe";
            btn_informe.Size = new Size(103, 26);
            btn_informe.TabIndex = 2;
            btn_informe.Text = "Generar Informe";
            btn_informe.UseVisualStyleBackColor = true;
            btn_informe.Click += btn_informe_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(266, 26);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 5;
            label2.Text = "Fecha inicial";
            // 
            // fecha_final
            // 
            fecha_final.Format = DateTimePickerFormat.Short;
            fecha_final.Location = new Point(264, 44);
            fecha_final.Name = "fecha_final";
            fecha_final.Size = new Size(103, 23);
            fecha_final.TabIndex = 1;
            // 
            // btn_informe_agrupado
            // 
            btn_informe_agrupado.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_informe_agrupado.Location = new Point(266, 126);
            btn_informe_agrupado.Name = "btn_informe_agrupado";
            btn_informe_agrupado.Size = new Size(101, 24);
            btn_informe_agrupado.TabIndex = 3;
            btn_informe_agrupado.Text = "Generar Informe";
            btn_informe_agrupado.UseVisualStyleBackColor = true;
            btn_informe_agrupado.Click += btn_informe_agrupado_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(53, 97);
            label3.Name = "label3";
            label3.Size = new Size(205, 15);
            label3.TabIndex = 7;
            label3.Text = "Generar un informe sin agrupaciones:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 126);
            label4.Name = "label4";
            label4.Size = new Size(248, 15);
            label4.TabIndex = 8;
            label4.Text = "Generar un informe categorizado por clientes:";
            // 
            // FrmInformFacemiAnual
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 159);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btn_informe_agrupado);
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
        private Button btn_informe_agrupado;
        private Label label3;
        private Label label4;
    }
}
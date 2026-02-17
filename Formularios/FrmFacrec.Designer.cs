namespace FacturacionDAM.Formularios
{
    partial class FrmFacrec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFacrec));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            pnBtns = new Panel();
            btnCancelar = new Button();
            btnAceptar = new Button();
            pnData = new Panel();
            tabControl1 = new TabControl();
            tabData = new TabPage();
            PnFacrelin = new Panel();
            pnGrid = new Panel();
            dgLineasFactura = new DataGridView();
            pnStatus = new Panel();
            statusStrip1 = new StatusStrip();
            tsLbNumReg = new ToolStripStatusLabel();
            tsLbStatus = new ToolStripStatusLabel();
            pnMenu = new Panel();
            tsHerramientas = new ToolStrip();
            tsBtnNew = new ToolStripButton();
            tsBtnEdit = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsBtnDelete = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            tsBtnFirst = new ToolStripButton();
            tsBtnPrev = new ToolStripButton();
            tsBtnNext = new ToolStripButton();
            tsBtnLast = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            tsBtnExportCSV = new ToolStripButton();
            tsBtnExportXML = new ToolStripButton();
            PnFacrec = new Panel();
            gbTotales = new GroupBox();
            lbRetencion = new Label();
            label13 = new Label();
            lbTotal = new Label();
            label12 = new Label();
            lbCuota = new Label();
            label11 = new Label();
            lbBase = new Label();
            label17 = new Label();
            gbFacrec = new GroupBox();
            numTipoRet = new NumericUpDown();
            label3 = new Label();
            chkRetencion = new CheckBox();
            chkPagada = new CheckBox();
            fechaFactura = new DateTimePicker();
            cbConceptFac = new ComboBox();
            label10 = new Label();
            txtDescripcion = new TextBox();
            label9 = new Label();
            label8 = new Label();
            txtNumero = new TextBox();
            label7 = new Label();
            gbEmisorProveedor = new GroupBox();
            lbNombreProveedor = new Label();
            lbNifcifProveedor = new Label();
            label5 = new Label();
            label6 = new Label();
            lbNombreEmisor = new Label();
            lbNifcifEmisor = new Label();
            label2 = new Label();
            label1 = new Label();
            tabNotas = new TabPage();
            txtNotas = new RichTextBox();
            pnBtns.SuspendLayout();
            pnData.SuspendLayout();
            tabControl1.SuspendLayout();
            tabData.SuspendLayout();
            PnFacrelin.SuspendLayout();
            pnGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgLineasFactura).BeginInit();
            pnStatus.SuspendLayout();
            statusStrip1.SuspendLayout();
            pnMenu.SuspendLayout();
            tsHerramientas.SuspendLayout();
            PnFacrec.SuspendLayout();
            gbTotales.SuspendLayout();
            gbFacrec.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numTipoRet).BeginInit();
            gbEmisorProveedor.SuspendLayout();
            tabNotas.SuspendLayout();
            SuspendLayout();
            // 
            // pnBtns
            // 
            pnBtns.Controls.Add(btnCancelar);
            pnBtns.Controls.Add(btnAceptar);
            pnBtns.Dock = DockStyle.Bottom;
            pnBtns.Location = new Point(0, 689);
            pnBtns.Name = "pnBtns";
            pnBtns.Size = new Size(876, 63);
            pnBtns.TabIndex = 1;
            // 
            // btnCancelar
            // 
            btnCancelar.Image = (Image)resources.GetObject("btnCancelar.Image");
            btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelar.Location = new Point(448, 14);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Padding = new Padding(10, 0, 10, 0);
            btnCancelar.Size = new Size(100, 36);
            btnCancelar.TabIndex = 1;
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
            btnAceptar.TabIndex = 0;
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
            pnData.Size = new Size(876, 689);
            pnData.TabIndex = 2;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabData);
            tabControl1.Controls.Add(tabNotas);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(876, 689);
            tabControl1.TabIndex = 0;
            // 
            // tabData
            // 
            tabData.Controls.Add(PnFacrelin);
            tabData.Controls.Add(PnFacrec);
            tabData.Location = new Point(4, 24);
            tabData.Name = "tabData";
            tabData.Padding = new Padding(3);
            tabData.Size = new Size(868, 661);
            tabData.TabIndex = 0;
            tabData.Text = "Datos";
            tabData.UseVisualStyleBackColor = true;
            // 
            // PnFacrelin
            // 
            PnFacrelin.BorderStyle = BorderStyle.Fixed3D;
            PnFacrelin.Controls.Add(pnGrid);
            PnFacrelin.Controls.Add(pnStatus);
            PnFacrelin.Controls.Add(pnMenu);
            PnFacrelin.Dock = DockStyle.Fill;
            PnFacrelin.Location = new Point(3, 339);
            PnFacrelin.Name = "PnFacrelin";
            PnFacrelin.Size = new Size(862, 319);
            PnFacrelin.TabIndex = 3;
            // 
            // pnGrid
            // 
            pnGrid.Controls.Add(dgLineasFactura);
            pnGrid.Dock = DockStyle.Fill;
            pnGrid.Location = new Point(0, 24);
            pnGrid.Name = "pnGrid";
            pnGrid.Padding = new Padding(0, 2, 0, 0);
            pnGrid.Size = new Size(858, 269);
            pnGrid.TabIndex = 3;
            // 
            // dgLineasFactura
            // 
            dgLineasFactura.AllowUserToAddRows = false;
            dgLineasFactura.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.LightGray;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgLineasFactura.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgLineasFactura.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgLineasFactura.Dock = DockStyle.Fill;
            dgLineasFactura.Location = new Point(0, 2);
            dgLineasFactura.Name = "dgLineasFactura";
            dgLineasFactura.ReadOnly = true;
            dgLineasFactura.RowHeadersWidth = 51;
            dgLineasFactura.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgLineasFactura.Size = new Size(858, 267);
            dgLineasFactura.TabIndex = 0;
            dgLineasFactura.CellMouseDoubleClick += dgLineasFactura_CellMouseDoubleClick;
            // 
            // pnStatus
            // 
            pnStatus.Controls.Add(statusStrip1);
            pnStatus.Dock = DockStyle.Bottom;
            pnStatus.Location = new Point(0, 293);
            pnStatus.Name = "pnStatus";
            pnStatus.Size = new Size(858, 22);
            pnStatus.TabIndex = 2;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { tsLbNumReg, tsLbStatus });
            statusStrip1.Location = new Point(0, 0);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(858, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // tsLbNumReg
            // 
            tsLbNumReg.Name = "tsLbNumReg";
            tsLbNumReg.Size = new Size(88, 17);
            tsLbNumReg.Text = "Nº de registros:";
            // 
            // tsLbStatus
            // 
            tsLbStatus.Margin = new Padding(10, 3, 0, 2);
            tsLbStatus.Name = "tsLbStatus";
            tsLbStatus.Size = new Size(0, 17);
            // 
            // pnMenu
            // 
            pnMenu.Controls.Add(tsHerramientas);
            pnMenu.Dock = DockStyle.Top;
            pnMenu.Location = new Point(0, 0);
            pnMenu.Name = "pnMenu";
            pnMenu.Size = new Size(858, 24);
            pnMenu.TabIndex = 1;
            // 
            // tsHerramientas
            // 
            tsHerramientas.ImageScalingSize = new Size(20, 20);
            tsHerramientas.Items.AddRange(new ToolStripItem[] { tsBtnNew, tsBtnEdit, toolStripSeparator1, tsBtnDelete, toolStripSeparator2, tsBtnFirst, tsBtnPrev, tsBtnNext, tsBtnLast, toolStripSeparator3, tsBtnExportCSV, tsBtnExportXML });
            tsHerramientas.Location = new Point(0, 0);
            tsHerramientas.Name = "tsHerramientas";
            tsHerramientas.Size = new Size(858, 27);
            tsHerramientas.TabIndex = 0;
            tsHerramientas.Text = "toolStrip1";
            // 
            // tsBtnNew
            // 
            tsBtnNew.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsBtnNew.Image = (Image)resources.GetObject("tsBtnNew.Image");
            tsBtnNew.Name = "tsBtnNew";
            tsBtnNew.Size = new Size(24, 24);
            tsBtnNew.Text = "Nuevo registro";
            tsBtnNew.Click += tsBtnNew_Click;
            // 
            // tsBtnEdit
            // 
            tsBtnEdit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsBtnEdit.Image = (Image)resources.GetObject("tsBtnEdit.Image");
            tsBtnEdit.Name = "tsBtnEdit";
            tsBtnEdit.Size = new Size(24, 24);
            tsBtnEdit.Text = "Editar registro";
            tsBtnEdit.Click += tsBtnEdit_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Margin = new Padding(5, 0, 5, 0);
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 27);
            // 
            // tsBtnDelete
            // 
            tsBtnDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsBtnDelete.Image = (Image)resources.GetObject("tsBtnDelete.Image");
            tsBtnDelete.Name = "tsBtnDelete";
            tsBtnDelete.Size = new Size(24, 24);
            tsBtnDelete.Text = "Eliminar registro";
            tsBtnDelete.Click += tsBtnDelete_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 27);
            // 
            // tsBtnFirst
            // 
            tsBtnFirst.Image = (Image)resources.GetObject("tsBtnFirst.Image");
            tsBtnFirst.Name = "tsBtnFirst";
            tsBtnFirst.Size = new Size(24, 24);
            // 
            // tsBtnPrev
            // 
            tsBtnPrev.Image = (Image)resources.GetObject("tsBtnPrev.Image");
            tsBtnPrev.Name = "tsBtnPrev";
            tsBtnPrev.Size = new Size(24, 24);
            // 
            // tsBtnNext
            // 
            tsBtnNext.Image = (Image)resources.GetObject("tsBtnNext.Image");
            tsBtnNext.Name = "tsBtnNext";
            tsBtnNext.Size = new Size(24, 24);
            // 
            // tsBtnLast
            // 
            tsBtnLast.Image = (Image)resources.GetObject("tsBtnLast.Image");
            tsBtnLast.Name = "tsBtnLast";
            tsBtnLast.Size = new Size(24, 24);
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 27);
            // 
            // tsBtnExportCSV
            // 
            tsBtnExportCSV.Image = Properties.Resources.importar_excel_1;
            tsBtnExportCSV.Name = "tsBtnExportCSV";
            tsBtnExportCSV.Size = new Size(24, 24);
            tsBtnExportCSV.Click += tsBtnExportCSV_Click;
            // 
            // tsBtnExportXML
            // 
            tsBtnExportXML.Image = (Image)resources.GetObject("tsBtnExportXML.Image");
            tsBtnExportXML.Name = "tsBtnExportXML";
            tsBtnExportXML.Size = new Size(24, 24);
            tsBtnExportXML.Click += tsBtnExportXML_Click;
            // 
            // PnFacrec
            // 
            PnFacrec.Controls.Add(gbTotales);
            PnFacrec.Controls.Add(gbFacrec);
            PnFacrec.Controls.Add(gbEmisorProveedor);
            PnFacrec.Dock = DockStyle.Top;
            PnFacrec.Location = new Point(3, 3);
            PnFacrec.Name = "PnFacrec";
            PnFacrec.Size = new Size(862, 336);
            PnFacrec.TabIndex = 2;
            // 
            // gbTotales
            // 
            gbTotales.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbTotales.BackColor = Color.Gainsboro;
            gbTotales.Controls.Add(lbRetencion);
            gbTotales.Controls.Add(label13);
            gbTotales.Controls.Add(lbTotal);
            gbTotales.Controls.Add(label12);
            gbTotales.Controls.Add(lbCuota);
            gbTotales.Controls.Add(label11);
            gbTotales.Controls.Add(lbBase);
            gbTotales.Controls.Add(label17);
            gbTotales.Location = new Point(10, 246);
            gbTotales.Name = "gbTotales";
            gbTotales.Size = new Size(837, 67);
            gbTotales.TabIndex = 4;
            gbTotales.TabStop = false;
            gbTotales.Text = "Totales";
            // 
            // lbRetencion
            // 
            lbRetencion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbRetencion.Location = new Point(545, 20);
            lbRetencion.Name = "lbRetencion";
            lbRetencion.Size = new Size(87, 23);
            lbRetencion.TabIndex = 0;
            lbRetencion.Text = "0,00 €";
            lbRetencion.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            label13.Location = new Point(467, 20);
            label13.Name = "label13";
            label13.Size = new Size(80, 23);
            label13.TabIndex = 1;
            label13.Text = "Retención:";
            label13.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbTotal
            // 
            lbTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbTotal.Location = new Point(356, 20);
            lbTotal.Name = "lbTotal";
            lbTotal.Size = new Size(87, 23);
            lbTotal.TabIndex = 2;
            lbTotal.Text = "0,00 €";
            lbTotal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            label12.Location = new Point(298, 20);
            label12.Name = "label12";
            label12.Size = new Size(56, 23);
            label12.TabIndex = 3;
            label12.Text = "Total:";
            label12.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbCuota
            // 
            lbCuota.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbCuota.Location = new Point(217, 20);
            lbCuota.Name = "lbCuota";
            lbCuota.Size = new Size(87, 23);
            lbCuota.TabIndex = 4;
            lbCuota.Text = "0,00 €";
            lbCuota.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            label11.Location = new Point(161, 20);
            label11.Name = "label11";
            label11.Size = new Size(56, 23);
            label11.TabIndex = 5;
            label11.Text = "Cuota:";
            label11.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbBase
            // 
            lbBase.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbBase.Location = new Point(83, 20);
            lbBase.Name = "lbBase";
            lbBase.Size = new Size(87, 23);
            lbBase.TabIndex = 6;
            lbBase.Text = "0,00 €";
            lbBase.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            label17.Location = new Point(25, 20);
            label17.Name = "label17";
            label17.Size = new Size(56, 23);
            label17.TabIndex = 7;
            label17.Text = "Base:";
            label17.TextAlign = ContentAlignment.MiddleRight;
            // 
            // gbFacrec
            // 
            gbFacrec.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbFacrec.Controls.Add(numTipoRet);
            gbFacrec.Controls.Add(label3);
            gbFacrec.Controls.Add(chkRetencion);
            gbFacrec.Controls.Add(chkPagada);
            gbFacrec.Controls.Add(fechaFactura);
            gbFacrec.Controls.Add(cbConceptFac);
            gbFacrec.Controls.Add(label10);
            gbFacrec.Controls.Add(txtDescripcion);
            gbFacrec.Controls.Add(label9);
            gbFacrec.Controls.Add(label8);
            gbFacrec.Controls.Add(txtNumero);
            gbFacrec.Controls.Add(label7);
            gbFacrec.Location = new Point(10, 104);
            gbFacrec.Name = "gbFacrec";
            gbFacrec.Size = new Size(837, 136);
            gbFacrec.TabIndex = 3;
            gbFacrec.TabStop = false;
            gbFacrec.Text = "Datos de la Factura";
            // 
            // numTipoRet
            // 
            numTipoRet.DecimalPlaces = 2;
            numTipoRet.Location = new Point(542, 98);
            numTipoRet.Name = "numTipoRet";
            numTipoRet.Size = new Size(60, 23);
            numTipoRet.TabIndex = 10;
            numTipoRet.TextAlign = HorizontalAlignment.Center;
            numTipoRet.Value = new decimal(new int[] { 15, 0, 0, 0 });
            numTipoRet.ValueChanged += numTipoRet_ValueChanged;
            // 
            // label3
            // 
            label3.Location = new Point(433, 98);
            label3.Name = "label3";
            label3.Size = new Size(105, 23);
            label3.TabIndex = 11;
            label3.Text = "Tipo de Retención";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // chkRetencion
            // 
            chkRetencion.AutoSize = true;
            chkRetencion.Location = new Point(292, 102);
            chkRetencion.Name = "chkRetencion";
            chkRetencion.Size = new Size(135, 19);
            chkRetencion.TabIndex = 12;
            chkRetencion.Text = "¿Se aplica retención?";
            chkRetencion.UseVisualStyleBackColor = true;
            chkRetencion.CheckedChanged += chkRetencion_CheckedChanged;
            // 
            // chkPagada
            // 
            chkPagada.AutoSize = true;
            chkPagada.Location = new Point(97, 102);
            chkPagada.Name = "chkPagada";
            chkPagada.Size = new Size(75, 19);
            chkPagada.TabIndex = 13;
            chkPagada.Text = "¿Pagada?";
            chkPagada.UseVisualStyleBackColor = true;
            // 
            // fechaFactura
            // 
            fechaFactura.Format = DateTimePickerFormat.Short;
            fechaFactura.Location = new Point(250, 27);
            fechaFactura.Name = "fechaFactura";
            fechaFactura.Size = new Size(96, 23);
            fechaFactura.TabIndex = 3;
            // 
            // cbConceptFac
            // 
            cbConceptFac.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbConceptFac.FormattingEnabled = true;
            cbConceptFac.Location = new Point(453, 28);
            cbConceptFac.Name = "cbConceptFac";
            cbConceptFac.Size = new Size(367, 23);
            cbConceptFac.TabIndex = 5;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(385, 31);
            label10.Name = "label10";
            label10.Size = new Size(62, 15);
            label10.TabIndex = 14;
            label10.Text = "Concepto:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDescripcion.Location = new Point(87, 61);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(733, 23);
            txtDescripcion.TabIndex = 7;
            // 
            // label9
            // 
            label9.Location = new Point(10, 61);
            label9.Name = "label9";
            label9.Size = new Size(70, 23);
            label9.TabIndex = 15;
            label9.Text = "Descripción";
            label9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(203, 31);
            label8.Name = "label8";
            label8.Size = new Size(41, 15);
            label8.TabIndex = 16;
            label8.Text = "Fecha:";
            // 
            // txtNumero
            // 
            txtNumero.Location = new Point(87, 29);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(88, 23);
            txtNumero.TabIndex = 1;
            // 
            // label7
            // 
            label7.Location = new Point(10, 27);
            label7.Name = "label7";
            label7.Size = new Size(70, 23);
            label7.TabIndex = 17;
            label7.Text = "Número";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // gbEmisorProveedor
            // 
            gbEmisorProveedor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbEmisorProveedor.Controls.Add(lbNombreProveedor);
            gbEmisorProveedor.Controls.Add(lbNifcifProveedor);
            gbEmisorProveedor.Controls.Add(label5);
            gbEmisorProveedor.Controls.Add(label6);
            gbEmisorProveedor.Controls.Add(lbNombreEmisor);
            gbEmisorProveedor.Controls.Add(lbNifcifEmisor);
            gbEmisorProveedor.Controls.Add(label2);
            gbEmisorProveedor.Controls.Add(label1);
            gbEmisorProveedor.Location = new Point(10, 11);
            gbEmisorProveedor.Name = "gbEmisorProveedor";
            gbEmisorProveedor.Size = new Size(837, 85);
            gbEmisorProveedor.TabIndex = 1;
            gbEmisorProveedor.TabStop = false;
            gbEmisorProveedor.Text = "Emisor y Proveedor";
            // 
            // lbNombreProveedor
            // 
            lbNombreProveedor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbNombreProveedor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbNombreProveedor.ForeColor = Color.DarkGoldenrod;
            lbNombreProveedor.Location = new Point(400, 51);
            lbNombreProveedor.Name = "lbNombreProveedor";
            lbNombreProveedor.Size = new Size(420, 23);
            lbNombreProveedor.TabIndex = 0;
            lbNombreProveedor.Text = "Nombre proveedor";
            lbNombreProveedor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbNifcifProveedor
            // 
            lbNifcifProveedor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbNifcifProveedor.ForeColor = Color.DarkGoldenrod;
            lbNifcifProveedor.Location = new Point(102, 51);
            lbNifcifProveedor.Name = "lbNifcifProveedor";
            lbNifcifProveedor.Size = new Size(125, 23);
            lbNifcifProveedor.TabIndex = 1;
            lbNifcifProveedor.Text = "NIF/CIF Proveedor";
            lbNifcifProveedor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.Location = new Point(233, 51);
            label5.Name = "label5";
            label5.Size = new Size(161, 23);
            label5.TabIndex = 2;
            label5.Text = "Nombre Proveedor:";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.Location = new Point(10, 51);
            label6.Name = "label6";
            label6.Size = new Size(91, 23);
            label6.TabIndex = 3;
            label6.Text = "NIF/CIF Proveedor:";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbNombreEmisor
            // 
            lbNombreEmisor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbNombreEmisor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbNombreEmisor.ForeColor = Color.RoyalBlue;
            lbNombreEmisor.Location = new Point(400, 20);
            lbNombreEmisor.Name = "lbNombreEmisor";
            lbNombreEmisor.Size = new Size(420, 23);
            lbNombreEmisor.TabIndex = 4;
            lbNombreEmisor.Text = "Nombre emisor";
            lbNombreEmisor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbNifcifEmisor
            // 
            lbNifcifEmisor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbNifcifEmisor.ForeColor = Color.RoyalBlue;
            lbNifcifEmisor.Location = new Point(102, 20);
            lbNifcifEmisor.Name = "lbNifcifEmisor";
            lbNifcifEmisor.Size = new Size(125, 23);
            lbNifcifEmisor.TabIndex = 5;
            lbNifcifEmisor.Text = "NIF/CIF Emisor";
            lbNifcifEmisor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Location = new Point(233, 20);
            label2.Name = "label2";
            label2.Size = new Size(161, 23);
            label2.TabIndex = 6;
            label2.Text = "Nombre Emisor:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.Location = new Point(10, 20);
            label1.Name = "label1";
            label1.Size = new Size(91, 23);
            label1.TabIndex = 7;
            label1.Text = "NIF/CIF Emisor:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tabNotas
            // 
            tabNotas.Controls.Add(txtNotas);
            tabNotas.Location = new Point(4, 24);
            tabNotas.Name = "tabNotas";
            tabNotas.Padding = new Padding(3);
            tabNotas.Size = new Size(868, 661);
            tabNotas.TabIndex = 1;
            tabNotas.Text = "Notas";
            tabNotas.UseVisualStyleBackColor = true;
            // 
            // txtNotas
            // 
            txtNotas.Dock = DockStyle.Fill;
            txtNotas.Location = new Point(3, 3);
            txtNotas.Name = "txtNotas";
            txtNotas.Size = new Size(862, 655);
            txtNotas.TabIndex = 0;
            txtNotas.Text = "";
            // 
            // FrmFacrec
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(876, 752);
            Controls.Add(pnData);
            Controls.Add(pnBtns);
            Name = "FrmFacrec";
            Text = "Factura de Compra (Recibida)";
            FormClosing += FrmFacrec_FormClosing;
            Load += FrmFacrec_Load;
            pnBtns.ResumeLayout(false);
            pnData.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabData.ResumeLayout(false);
            PnFacrelin.ResumeLayout(false);
            pnGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgLineasFactura).EndInit();
            pnStatus.ResumeLayout(false);
            pnStatus.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            pnMenu.ResumeLayout(false);
            pnMenu.PerformLayout();
            tsHerramientas.ResumeLayout(false);
            tsHerramientas.PerformLayout();
            PnFacrec.ResumeLayout(false);
            gbTotales.ResumeLayout(false);
            gbFacrec.ResumeLayout(false);
            gbFacrec.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numTipoRet).EndInit();
            gbEmisorProveedor.ResumeLayout(false);
            tabNotas.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnBtns;
        private Button btnCancelar;
        private Button btnAceptar;
        private Panel pnData;
        private TabControl tabControl1;
        private TabPage tabData;
        private TabPage tabNotas;
        private RichTextBox txtNotas;
        private Panel PnFacrec;
        private GroupBox gbFacrec;
        private ComboBox cbConceptFac;
        private Label label10;
        private TextBox txtDescripcion;
        private Label label9;
        private Label label8;
        private TextBox txtNumero;
        private Label label7;
        private GroupBox gbEmisorProveedor;
        private Label lbNombreEmisor;
        private Label lbNifcifEmisor;
        private Label label2;
        private Label label1;
        private Panel PnFacrelin;
        private Panel pnMenu;
        private ToolStrip tsHerramientas;
        private ToolStripButton tsBtnNew;
        private ToolStripButton tsBtnEdit;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tsBtnDelete;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tsBtnFirst;
        private ToolStripButton tsBtnPrev;
        private ToolStripButton tsBtnNext;
        private ToolStripButton tsBtnLast;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton tsBtnExportCSV;
        private ToolStripButton tsBtnExportXML;
        private DateTimePicker fechaFactura;
        private Panel pnStatus;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tsLbNumReg;
        private ToolStripStatusLabel tsLbStatus;
        private Panel pnGrid;
        private DataGridView dgLineasFactura;
        private Label lbNombreProveedor;
        private Label lbNifcifProveedor;
        private Label label5;
        private Label label6;
        private CheckBox chkRetencion;
        private CheckBox chkPagada;
        private NumericUpDown numTipoRet;
        private Label label3;
        private GroupBox gbTotales;
        private Label lbBase;
        private Label label17;
        private Label lbCuota;
        private Label label11;
        private Label lbRetencion;
        private Label label13;
        private Label lbTotal;
        private Label label12;
    }
}
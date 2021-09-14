
namespace Consultor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.dgDatosFiltrados = new System.Windows.Forms.DataGridView();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.txtNameFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lsvDatosCargados = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.lsvConsultados = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtFiltrar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pbImagen = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelProgreso = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pbGood = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpFechaI = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaF = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscarFechas = new System.Windows.Forms.Button();
            this.lblProcesando = new System.Windows.Forms.Label();
            this.cbTarea = new System.Windows.Forms.ComboBox();
            this.cbDelegacion = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtFInicial = new System.Windows.Forms.DateTimePicker();
            this.dtFFinal = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBRango = new System.Windows.Forms.CheckBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgDatosFiltrados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGood)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbStatus
            // 
            this.cbStatus.Enabled = false;
            this.cbStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "-Seleccione-"});
            this.cbStatus.Location = new System.Drawing.Point(128, 442);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(150, 23);
            this.cbStatus.TabIndex = 17;
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
            // 
            // dgDatosFiltrados
            // 
            this.dgDatosFiltrados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDatosFiltrados.Location = new System.Drawing.Point(21, 471);
            this.dgDatosFiltrados.Name = "dgDatosFiltrados";
            this.dgDatosFiltrados.RowTemplate.Height = 25;
            this.dgDatosFiltrados.Size = new System.Drawing.Size(569, 338);
            this.dgDatosFiltrados.TabIndex = 11;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnOpenFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOpenFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenFile.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnOpenFile.ForeColor = System.Drawing.Color.White;
            this.btnOpenFile.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenFile.Image")));
            this.btnOpenFile.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOpenFile.Location = new System.Drawing.Point(499, 1);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(91, 42);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "Abrir";
            this.btnOpenFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenFile.UseVisualStyleBackColor = false;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // txtNameFile
            // 
            this.txtNameFile.Cursor = System.Windows.Forms.Cursors.No;
            this.txtNameFile.Location = new System.Drawing.Point(204, 16);
            this.txtNameFile.Name = "txtNameFile";
            this.txtNameFile.ReadOnly = true;
            this.txtNameFile.Size = new System.Drawing.Size(279, 23);
            this.txtNameFile.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(21, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ruta de arcchivo:";
            // 
            // lsvDatosCargados
            // 
            this.lsvDatosCargados.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lsvDatosCargados.GridLines = true;
            this.lsvDatosCargados.HideSelection = false;
            this.lsvDatosCargados.Location = new System.Drawing.Point(21, 91);
            this.lsvDatosCargados.Name = "lsvDatosCargados";
            this.lsvDatosCargados.Size = new System.Drawing.Size(152, 327);
            this.lsvDatosCargados.TabIndex = 3;
            this.lsvDatosCargados.UseCompatibleStateImageBehavior = false;
            this.lsvDatosCargados.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "NO. TRAMITE";
            this.columnHeader1.Width = 130;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(21, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Datos cargados";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsultar.Enabled = false;
            this.btnConsultar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnConsultar.ForeColor = System.Drawing.Color.White;
            this.btnConsultar.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.Image")));
            this.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultar.Location = new System.Drawing.Point(204, 48);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(125, 40);
            this.btnConsultar.TabIndex = 5;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConsultar.UseVisualStyleBackColor = false;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // lsvConsultados
            // 
            this.lsvConsultados.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader14});
            this.lsvConsultados.GridLines = true;
            this.lsvConsultados.HideSelection = false;
            this.lsvConsultados.Location = new System.Drawing.Point(204, 91);
            this.lsvConsultados.Name = "lsvConsultados";
            this.lsvConsultados.Size = new System.Drawing.Size(619, 327);
            this.lsvConsultados.TabIndex = 6;
            this.lsvConsultados.UseCompatibleStateImageBehavior = false;
            this.lsvConsultados.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "No. Trámite";
            this.columnHeader2.Width = 130;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Fecha";
            this.columnHeader3.Width = 50;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Status";
            this.columnHeader4.Width = 80;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Orden";
            this.columnHeader5.Width = 50;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Tarea";
            this.columnHeader6.Width = 140;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Delegación";
            this.columnHeader7.Width = 120;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "No.";
            this.columnHeader14.Width = 50;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.Enabled = false;
            this.btnImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(706, 811);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(117, 41);
            this.btnImprimir.TabIndex = 9;
            this.btnImprimir.Text = "Exportar";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.No;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(774, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 69);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // txtFiltrar
            // 
            this.txtFiltrar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtFiltrar.Location = new System.Drawing.Point(21, 442);
            this.txtFiltrar.Name = "txtFiltrar";
            this.txtFiltrar.ReadOnly = true;
            this.txtFiltrar.Size = new System.Drawing.Size(101, 23);
            this.txtFiltrar.TabIndex = 12;
            this.txtFiltrar.TextChanged += new System.EventHandler(this.txtFiltrar_TextChanged);
            this.txtFiltrar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFiltrar_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(21, 422);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Buscar Trámite:";
            // 
            // pbImagen
            // 
            this.pbImagen.Image = ((System.Drawing.Image)(resources.GetObject("pbImagen.Image")));
            this.pbImagen.Location = new System.Drawing.Point(596, 551);
            this.pbImagen.Name = "pbImagen";
            this.pbImagen.Size = new System.Drawing.Size(242, 258);
            this.pbImagen.TabIndex = 14;
            this.pbImagen.TabStop = false;
            this.pbImagen.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.White;
            this.progressBar1.Location = new System.Drawing.Point(561, 65);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(239, 23);
            this.progressBar1.TabIndex = 15;
            this.progressBar1.Visible = false;
            // 
            // labelProgreso
            // 
            this.labelProgreso.AutoSize = true;
            this.labelProgreso.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelProgreso.ForeColor = System.Drawing.Color.Black;
            this.labelProgreso.Location = new System.Drawing.Point(806, 67);
            this.labelProgreso.Name = "labelProgreso";
            this.labelProgreso.Size = new System.Drawing.Size(32, 21);
            this.labelProgreso.TabIndex = 16;
            this.labelProgreso.Text = "0%";
            this.labelProgreso.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // pbGood
            // 
            this.pbGood.Image = ((System.Drawing.Image)(resources.GetObject("pbGood.Image")));
            this.pbGood.Location = new System.Drawing.Point(528, 56);
            this.pbGood.Name = "pbGood";
            this.pbGood.Size = new System.Drawing.Size(32, 32);
            this.pbGood.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbGood.TabIndex = 18;
            this.pbGood.TabStop = false;
            this.pbGood.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(128, 422);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "Status:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 20;
            this.label5.Text = "Fecha inicial:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(159, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 21;
            this.label6.Text = "Fecha final:";
            // 
            // dtpFechaI
            // 
            this.dtpFechaI.Enabled = false;
            this.dtpFechaI.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaI.Location = new System.Drawing.Point(6, 42);
            this.dtpFechaI.Name = "dtpFechaI";
            this.dtpFechaI.Size = new System.Drawing.Size(83, 23);
            this.dtpFechaI.TabIndex = 22;
            // 
            // dtpFechaF
            // 
            this.dtpFechaF.Enabled = false;
            this.dtpFechaF.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaF.Location = new System.Drawing.Point(159, 42);
            this.dtpFechaF.Name = "dtpFechaF";
            this.dtpFechaF.Size = new System.Drawing.Size(83, 23);
            this.dtpFechaF.TabIndex = 23;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscarFechas);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtpFechaF);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpFechaI);
            this.groupBox1.Location = new System.Drawing.Point(596, 441);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 104);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Busqueda por rango";
            // 
            // btnBuscarFechas
            // 
            this.btnBuscarFechas.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnBuscarFechas.Enabled = false;
            this.btnBuscarFechas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBuscarFechas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarFechas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBuscarFechas.ForeColor = System.Drawing.Color.White;
            this.btnBuscarFechas.Location = new System.Drawing.Point(7, 75);
            this.btnBuscarFechas.Name = "btnBuscarFechas";
            this.btnBuscarFechas.Size = new System.Drawing.Size(229, 23);
            this.btnBuscarFechas.TabIndex = 24;
            this.btnBuscarFechas.Text = "Buscar";
            this.btnBuscarFechas.UseVisualStyleBackColor = false;
            this.btnBuscarFechas.Click += new System.EventHandler(this.btnBuscarFechas_Click);
            // 
            // lblProcesando
            // 
            this.lblProcesando.AutoSize = true;
            this.lblProcesando.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblProcesando.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblProcesando.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblProcesando.ForeColor = System.Drawing.Color.DimGray;
            this.lblProcesando.Location = new System.Drawing.Point(561, 48);
            this.lblProcesando.Name = "lblProcesando";
            this.lblProcesando.Size = new System.Drawing.Size(86, 17);
            this.lblProcesando.TabIndex = 25;
            this.lblProcesando.Text = "Procesando...";
            this.lblProcesando.Visible = false;
            // 
            // cbTarea
            // 
            this.cbTarea.Enabled = false;
            this.cbTarea.FormattingEnabled = true;
            this.cbTarea.Location = new System.Drawing.Point(286, 442);
            this.cbTarea.Name = "cbTarea";
            this.cbTarea.Size = new System.Drawing.Size(191, 23);
            this.cbTarea.TabIndex = 26;
            this.cbTarea.SelectedIndexChanged += new System.EventHandler(this.cbTarea_SelectedIndexChanged);
            // 
            // cbDelegacion
            // 
            this.cbDelegacion.Enabled = false;
            this.cbDelegacion.FormattingEnabled = true;
            this.cbDelegacion.Location = new System.Drawing.Point(483, 442);
            this.cbDelegacion.Name = "cbDelegacion";
            this.cbDelegacion.Size = new System.Drawing.Size(107, 23);
            this.cbDelegacion.TabIndex = 27;
            this.cbDelegacion.SelectedIndexChanged += new System.EventHandler(this.cbDelegacion_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(286, 422);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 17);
            this.label7.TabIndex = 28;
            this.label7.Text = "Tarea:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(469, 421);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 17);
            this.label8.TabIndex = 29;
            this.label8.Text = "Delegación:";
            // 
            // dtFInicial
            // 
            this.dtFInicial.Enabled = false;
            this.dtFInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFInicial.Location = new System.Drawing.Point(335, 64);
            this.dtFInicial.Name = "dtFInicial";
            this.dtFInicial.Size = new System.Drawing.Size(91, 23);
            this.dtFInicial.TabIndex = 30;
            // 
            // dtFFinal
            // 
            this.dtFFinal.Enabled = false;
            this.dtFFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFFinal.Location = new System.Drawing.Point(432, 64);
            this.dtFFinal.Name = "dtFFinal";
            this.dtFFinal.Size = new System.Drawing.Size(90, 23);
            this.dtFFinal.TabIndex = 31;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(335, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 15);
            this.label10.TabIndex = 33;
            this.label10.Text = "Fecha inicial:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(431, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 25;
            this.label9.Text = "Fecha final:";
            // 
            // checkBRango
            // 
            this.checkBRango.AutoSize = true;
            this.checkBRango.Location = new System.Drawing.Point(602, 18);
            this.checkBRango.Name = "checkBRango";
            this.checkBRango.Size = new System.Drawing.Size(116, 19);
            this.checkBRango.TabIndex = 34;
            this.checkBRango.Text = "Buscar por rango";
            this.checkBRango.UseVisualStyleBackColor = true;
            this.checkBRango.CheckedChanged += new System.EventHandler(this.checkBRango_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(843, 853);
            this.Controls.Add(this.checkBRango);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtFFinal);
            this.Controls.Add(this.dtFInicial);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbDelegacion);
            this.Controls.Add(this.cbTarea);
            this.Controls.Add(this.lblProcesando);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pbGood);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.labelProgreso);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.pbImagen);
            this.Controls.Add(this.dgDatosFiltrados);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFiltrar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.lsvConsultados);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lsvDatosCargados);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNameFile);
            this.Controls.Add(this.btnOpenFile);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CONSULTOR DE TRÁMITES";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDatosFiltrados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGood)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.TextBox txtNameFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lsvDatosCargados;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.ListView lsvConsultados;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgDatosFiltrados;
        private System.Windows.Forms.TextBox txtFiltrar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbImagen;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelProgreso;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.PictureBox pbGood;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpFechaI;
        private System.Windows.Forms.DateTimePicker dtpFechaF;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscarFechas;
        private System.Windows.Forms.Label lblProcesando;
        private System.Windows.Forms.ComboBox cbTarea;
        private System.Windows.Forms.ComboBox cbDelegacion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtFInicial;
        private System.Windows.Forms.DateTimePicker dtFFinal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBRango;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}


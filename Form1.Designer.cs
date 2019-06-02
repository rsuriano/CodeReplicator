namespace CodeReplicator
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.quantumConnection = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.layerTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableList = new System.Windows.Forms.ComboBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PathDatasetTextbox = new System.Windows.Forms.TextBox();
            this.FileNameTextbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.connectionNameTextbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DT = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sqlBedrock = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.dbConnectionString = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.changeDB = new System.Windows.Forms.Button();
            this.fullConnString = new System.Windows.Forms.Label();
            this.dynamicCheckbox = new System.Windows.Forms.CheckBox();
            this.quickaccess2 = new System.Windows.Forms.Button();
            this.quickaccess1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // quantumConnection
            // 
            this.quantumConnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.quantumConnection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.quantumConnection.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.quantumConnection.ForeColor = System.Drawing.Color.DimGray;
            this.quantumConnection.Location = new System.Drawing.Point(32, 504);
            this.quantumConnection.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.quantumConnection.Name = "quantumConnection";
            this.quantumConnection.Size = new System.Drawing.Size(276, 37);
            this.quantumConnection.TabIndex = 0;
            this.quantumConnection.Text = "Generate Quantum™ Connection®";
            this.quantumConnection.UseVisualStyleBackColor = false;
            this.quantumConnection.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1023, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 18);
            this.label1.TabIndex = 1;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // layerTextbox
            // 
            this.layerTextbox.BackColor = System.Drawing.Color.White;
            this.layerTextbox.ForeColor = System.Drawing.Color.Black;
            this.layerTextbox.Location = new System.Drawing.Point(185, 9);
            this.layerTextbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.layerTextbox.Name = "layerTextbox";
            this.layerTextbox.Size = new System.Drawing.Size(123, 26);
            this.layerTextbox.TabIndex = 2;
            this.layerTextbox.Text = "Connection";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Layer";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 40);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Table";
            // 
            // tableList
            // 
            this.tableList.FormattingEnabled = true;
            this.tableList.Location = new System.Drawing.Point(185, 38);
            this.tableList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableList.Name = "tableList";
            this.tableList.Size = new System.Drawing.Size(123, 26);
            this.tableList.TabIndex = 8;
            this.tableList.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.richTextBox1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.richTextBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.richTextBox1.Location = new System.Drawing.Point(333, 70);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(908, 250);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "The generated quantum code will appear in this box.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 435);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "File Path";
            // 
            // PathDatasetTextbox
            // 
            this.PathDatasetTextbox.Location = new System.Drawing.Point(185, 431);
            this.PathDatasetTextbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PathDatasetTextbox.Name = "PathDatasetTextbox";
            this.PathDatasetTextbox.Size = new System.Drawing.Size(123, 26);
            this.PathDatasetTextbox.TabIndex = 11;
            this.PathDatasetTextbox.Text = "C:\\TestCode";
            this.PathDatasetTextbox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // FileNameTextbox
            // 
            this.FileNameTextbox.Location = new System.Drawing.Point(185, 463);
            this.FileNameTextbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.FileNameTextbox.Name = "FileNameTextbox";
            this.FileNameTextbox.Size = new System.Drawing.Size(123, 26);
            this.FileNameTextbox.TabIndex = 13;
            this.FileNameTextbox.Text = "TestCode";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 463);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 18);
            this.label5.TabIndex = 12;
            this.label5.Text = "File Name";
            // 
            // connectionNameTextbox
            // 
            this.connectionNameTextbox.Location = new System.Drawing.Point(185, 401);
            this.connectionNameTextbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.connectionNameTextbox.Name = "connectionNameTextbox";
            this.connectionNameTextbox.Size = new System.Drawing.Size(123, 26);
            this.connectionNameTextbox.TabIndex = 15;
            this.connectionNameTextbox.Text = "GestionDataSet";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 405);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 18);
            this.label6.TabIndex = 14;
            this.label6.Text = "DataSetName";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.SP,
            this.DT});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dataGridView1.Location = new System.Drawing.Point(32, 70);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.Size = new System.Drawing.Size(276, 293);
            this.dataGridView1.TabIndex = 17;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Select
            // 
            this.Select.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            dataGridViewCellStyle7.NullValue = false;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Select.DefaultCellStyle = dataGridViewCellStyle7;
            this.Select.FillWeight = 20F;
            this.Select.HeaderText = "";
            this.Select.Name = "Select";
            // 
            // SP
            // 
            this.SP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.SP.DefaultCellStyle = dataGridViewCellStyle8;
            this.SP.FillWeight = 55F;
            this.SP.HeaderText = "SP Name";
            this.SP.Name = "SP";
            // 
            // DT
            // 
            this.DT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            dataGridViewCellStyle9.NullValue = false;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.DT.DefaultCellStyle = dataGridViewCellStyle9;
            this.DT.FillWeight = 25F;
            this.DT.HeaderText = "Return DT?";
            this.DT.Name = "DT";
            this.DT.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // sqlBedrock
            // 
            this.sqlBedrock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.sqlBedrock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.sqlBedrock.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.sqlBedrock.ForeColor = System.Drawing.Color.DimGray;
            this.sqlBedrock.Location = new System.Drawing.Point(32, 547);
            this.sqlBedrock.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.sqlBedrock.Name = "sqlBedrock";
            this.sqlBedrock.Size = new System.Drawing.Size(276, 37);
            this.sqlBedrock.TabIndex = 18;
            this.sqlBedrock.Text = "Generate SQL Bedrock™";
            this.sqlBedrock.UseVisualStyleBackColor = false;
            this.sqlBedrock.Click += new System.EventHandler(this.button2_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.richTextBox2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.richTextBox2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.richTextBox2.Location = new System.Drawing.Point(333, 326);
            this.richTextBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(908, 258);
            this.richTextBox2.TabIndex = 19;
            this.richTextBox2.Text = "The generated SQL Bedrock will appear in this box.";
            this.richTextBox2.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged);
            // 
            // dbConnectionString
            // 
            this.dbConnectionString.Location = new System.Drawing.Point(457, 9);
            this.dbConnectionString.Name = "dbConnectionString";
            this.dbConnectionString.Size = new System.Drawing.Size(180, 26);
            this.dbConnectionString.TabIndex = 20;
            this.dbConnectionString.Text = "Genesis";
            this.dbConnectionString.TextChanged += new System.EventHandler(this.dbConnectionString_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(330, 9);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 18);
            this.label7.TabIndex = 21;
            this.label7.Text = "DataBase Name";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // changeDB
            // 
            this.changeDB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.changeDB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.changeDB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.changeDB.ForeColor = System.Drawing.Color.DimGray;
            this.changeDB.Location = new System.Drawing.Point(644, 9);
            this.changeDB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.changeDB.Name = "changeDB";
            this.changeDB.Size = new System.Drawing.Size(106, 26);
            this.changeDB.TabIndex = 22;
            this.changeDB.Text = "Go";
            this.changeDB.UseVisualStyleBackColor = false;
            this.changeDB.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // fullConnString
            // 
            this.fullConnString.AutoSize = true;
            this.fullConnString.Location = new System.Drawing.Point(330, 41);
            this.fullConnString.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fullConnString.Name = "fullConnString";
            this.fullConnString.Size = new System.Drawing.Size(545, 18);
            this.fullConnString.TabIndex = 23;
            this.fullConnString.Text = "Data Source=.\\SQLEXPRESS;Initial Catalog=Genesis;User ID=sa;Password=*****";
            // 
            // dynamicCheckbox
            // 
            this.dynamicCheckbox.AutoSize = true;
            this.dynamicCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.dynamicCheckbox.Location = new System.Drawing.Point(28, 374);
            this.dynamicCheckbox.Name = "dynamicCheckbox";
            this.dynamicCheckbox.Size = new System.Drawing.Size(192, 22);
            this.dynamicCheckbox.TabIndex = 25;
            this.dynamicCheckbox.Text = "Use Dynamic Connection";
            this.dynamicCheckbox.UseVisualStyleBackColor = true;
            this.dynamicCheckbox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // quickaccess2
            // 
            this.quickaccess2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.quickaccess2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.quickaccess2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.quickaccess2.ForeColor = System.Drawing.Color.DimGray;
            this.quickaccess2.Location = new System.Drawing.Point(1135, 8);
            this.quickaccess2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.quickaccess2.Name = "quickaccess2";
            this.quickaccess2.Size = new System.Drawing.Size(106, 26);
            this.quickaccess2.TabIndex = 26;
            this.quickaccess2.Text = "Dispensario";
            this.quickaccess2.UseVisualStyleBackColor = false;
            this.quickaccess2.Click += new System.EventHandler(this.quickaccess2_Click);
            // 
            // quickaccess1
            // 
            this.quickaccess1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.quickaccess1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.quickaccess1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.quickaccess1.ForeColor = System.Drawing.Color.DimGray;
            this.quickaccess1.Location = new System.Drawing.Point(1021, 8);
            this.quickaccess1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.quickaccess1.Name = "quickaccess1";
            this.quickaccess1.Size = new System.Drawing.Size(106, 26);
            this.quickaccess1.TabIndex = 27;
            this.quickaccess1.Text = "Genesis";
            this.quickaccess1.UseVisualStyleBackColor = false;
            this.quickaccess1.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(925, 9);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 18);
            this.label8.TabIndex = 28;
            this.label8.Text = "QuickAccess";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(1268, 596);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.quickaccess1);
            this.Controls.Add(this.quickaccess2);
            this.Controls.Add(this.dynamicCheckbox);
            this.Controls.Add(this.fullConnString);
            this.Controls.Add(this.changeDB);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dbConnectionString);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.sqlBedrock);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.connectionNameTextbox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.FileNameTextbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PathDatasetTextbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.tableList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.layerTextbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.quantumConnection);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "CodeReplicator2019 - v1.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button quantumConnection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox layerTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox tableList;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PathDatasetTextbox;
        private System.Windows.Forms.TextBox FileNameTextbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox connectionNameTextbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn SP;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DT;
        private System.Windows.Forms.Button sqlBedrock;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.TextBox dbConnectionString;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button changeDB;
        private System.Windows.Forms.Label fullConnString;
        private System.Windows.Forms.CheckBox dynamicCheckbox;
        private System.Windows.Forms.Button quickaccess2;
        private System.Windows.Forms.Button quickaccess1;
        private System.Windows.Forms.Label label8;
    }
}


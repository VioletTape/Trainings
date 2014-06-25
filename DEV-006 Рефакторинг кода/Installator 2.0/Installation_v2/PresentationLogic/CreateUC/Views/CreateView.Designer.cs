namespace Installation_v2.PresentationLogic.CreateUC.Views {
    partial class CreateView {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dialogCsc = new System.Windows.Forms.Button();
            this.dialogVsvars = new System.Windows.Forms.Button();
            this.dialogCE = new System.Windows.Forms.Button();
            this.csc = new System.Windows.Forms.TextBox();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vsvars = new System.Windows.Forms.TextBox();
            this.pathToCE = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dialogPathToAppl = new System.Windows.Forms.Button();
            this.dialogPathToExe = new System.Windows.Forms.Button();
            this.pathToAppl = new System.Windows.Forms.TextBox();
            this.pathToExe = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.create = new System.Windows.Forms.Button();
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(484, 252);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.dialogCsc);
            this.tabPage1.Controls.Add(this.dialogVsvars);
            this.tabPage1.Controls.Add(this.dialogCE);
            this.tabPage1.Controls.Add(this.csc);
            this.tabPage1.Controls.Add(this.vsvars);
            this.tabPage1.Controls.Add(this.pathToCE);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(476, 226);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Настройки окружения";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 174);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(111, 13);
            this.label13.TabIndex = 9;
            this.label13.Text = "Path to CSC (csc.exe)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 134);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(150, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Path to env bat (vsvars32.bat)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 95);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(244, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Path to SQL CE 3.5 (System.Data.SqlServerCe.dll)";
            // 
            // dialogCsc
            // 
            this.dialogCsc.Location = new System.Drawing.Point(433, 188);
            this.dialogCsc.Name = "dialogCsc";
            this.dialogCsc.Size = new System.Drawing.Size(31, 21);
            this.dialogCsc.TabIndex = 8;
            this.dialogCsc.Text = "...";
            this.dialogCsc.UseVisualStyleBackColor = true;
            this.dialogCsc.Click += new System.EventHandler(this.dialogCsc_Click);
            // 
            // dialogVsvars
            // 
            this.dialogVsvars.Location = new System.Drawing.Point(433, 148);
            this.dialogVsvars.Name = "dialogVsvars";
            this.dialogVsvars.Size = new System.Drawing.Size(31, 21);
            this.dialogVsvars.TabIndex = 8;
            this.dialogVsvars.Text = "...";
            this.dialogVsvars.UseVisualStyleBackColor = true;
            this.dialogVsvars.Click += new System.EventHandler(this.dialogVsvars_Click);
            // 
            // dialogCE
            // 
            this.dialogCE.Location = new System.Drawing.Point(433, 110);
            this.dialogCE.Name = "dialogCE";
            this.dialogCE.Size = new System.Drawing.Size(31, 21);
            this.dialogCE.TabIndex = 8;
            this.dialogCE.Text = "...";
            this.dialogCE.UseVisualStyleBackColor = true;
            this.dialogCE.Click += new System.EventHandler(this.dialogCE_Click);
            // 
            // csc
            // 
            this.csc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "PathToCsc", true));
            this.csc.Location = new System.Drawing.Point(15, 189);
            this.csc.Name = "csc";
            this.csc.Size = new System.Drawing.Size(412, 20);
            this.csc.TabIndex = 7;
            this.csc.Text = "C:\\Windows\\Microsoft.NET\\Framework\\v3.5\\Csc.exe";
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(Installation_v2.PresentationLogic.CreateUC.DataState.CreateViewState);
            // 
            // vsvars
            // 
            this.vsvars.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "PathToEnvBat", true));
            this.vsvars.Location = new System.Drawing.Point(15, 149);
            this.vsvars.Name = "vsvars";
            this.vsvars.Size = new System.Drawing.Size(412, 20);
            this.vsvars.TabIndex = 7;
            this.vsvars.Text = "C:\\Program Files (x86)\\Microsoft Visual Studio 9.0\\Common7\\Tools\\vsvars32.bat";
            // 
            // pathToCE
            // 
            this.pathToCE.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "PathToCE", true));
            this.pathToCE.Location = new System.Drawing.Point(15, 111);
            this.pathToCE.Name = "pathToCE";
            this.pathToCE.Size = new System.Drawing.Size(412, 20);
            this.pathToCE.TabIndex = 7;
            this.pathToCE.Text = "C:\\Program Files (x86)\\Microsoft SQL Server Compact Edition\\v3.5\\Desktop\\System.D" +
                "ata.SqlServerCe.dll";
            // 
            // textBox2
            // 
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Version", true));
            this.textBox2.Location = new System.Drawing.Point(189, 62);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(158, 20);
            this.textBox2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Version";
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "MinVersion", true));
            this.textBox1.Location = new System.Drawing.Point(189, 43);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(158, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(186, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Became";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(101, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Current";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CurrentVersion", true));
            this.label6.Location = new System.Drawing.Point(101, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "1.0.070709";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CurrentMinVersion", true));
            this.label3.Location = new System.Drawing.Point(101, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "1.0.010109";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Min Version";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(476, 226);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "SQL Скрипты";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Scripts", true));
            this.richTextBox1.DetectUrls = false;
            this.richTextBox1.Location = new System.Drawing.Point(6, 29);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(464, 149);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.dialogPathToAppl);
            this.tabPage3.Controls.Add(this.dialogPathToExe);
            this.tabPage3.Controls.Add(this.pathToAppl);
            this.tabPage3.Controls.Add(this.pathToExe);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.create);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(476, 226);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Создание";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Path to Application";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(198, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Path to place result exe and support files";
            // 
            // dialogPathToAppl
            // 
            this.dialogPathToAppl.Location = new System.Drawing.Point(429, 67);
            this.dialogPathToAppl.Name = "dialogPathToAppl";
            this.dialogPathToAppl.Size = new System.Drawing.Size(31, 21);
            this.dialogPathToAppl.TabIndex = 5;
            this.dialogPathToAppl.Text = "...";
            this.dialogPathToAppl.UseVisualStyleBackColor = true;
            this.dialogPathToAppl.Click += new System.EventHandler(this.dialogPathToAppl_Click);
            // 
            // dialogPathToExe
            // 
            this.dialogPathToExe.Location = new System.Drawing.Point(429, 28);
            this.dialogPathToExe.Name = "dialogPathToExe";
            this.dialogPathToExe.Size = new System.Drawing.Size(31, 21);
            this.dialogPathToExe.TabIndex = 5;
            this.dialogPathToExe.Text = "...";
            this.dialogPathToExe.UseVisualStyleBackColor = true;
            this.dialogPathToExe.Click += new System.EventHandler(this.pathToExe_Click);
            // 
            // pathToAppl
            // 
            this.pathToAppl.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "PathToAppl", true));
            this.pathToAppl.Location = new System.Drawing.Point(11, 68);
            this.pathToAppl.Name = "pathToAppl";
            this.pathToAppl.Size = new System.Drawing.Size(412, 20);
            this.pathToAppl.TabIndex = 4;
            this.pathToAppl.Text = "D:\\Project\\GrandeX\\Main\\Grande\\bin\\Debug";
            // 
            // pathToExe
            // 
            this.pathToExe.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "PathToPlaceNewInstaller", true));
            this.pathToExe.Location = new System.Drawing.Point(11, 29);
            this.pathToExe.Name = "pathToExe";
            this.pathToExe.Size = new System.Drawing.Size(412, 20);
            this.pathToExe.TabIndex = 4;
            this.pathToExe.Text = "D:\\Project\\experiment";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CreateProgress", true));
            this.label10.Location = new System.Drawing.Point(32, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "in progress";
            // 
            // create
            // 
            this.create.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.bindingSource, "CreateCore", true));
            this.create.Location = new System.Drawing.Point(35, 127);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(388, 67);
            this.create.TabIndex = 0;
            this.create.Text = "Создать";
            this.create.UseVisualStyleBackColor = true;
            this.create.Click += new System.EventHandler(this.button4_Click);
            // 
            // CreateView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "CreateView";
            this.Size = new System.Drawing.Size(490, 258);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button create;
        private System.Windows.Forms.FolderBrowserDialog folderDialog;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.Button dialogPathToExe;
        private System.Windows.Forms.TextBox pathToExe;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button dialogCE;
        private System.Windows.Forms.TextBox pathToCE;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox vsvars;
        private System.Windows.Forms.Button dialogVsvars;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button dialogCsc;
        private System.Windows.Forms.TextBox csc;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button dialogPathToAppl;
        private System.Windows.Forms.TextBox pathToAppl;
    }
}

using Installation_v2.PresentationLogic.WelcomeUC.DataState;

namespace Installation_v2.PresentationLogic.InstallSelectionUC.Views {
    partial class InstallSelectionView {
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
            this.stepCaption = new System.Windows.Forms.Label();
            this.stepInstructions = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.selectPath = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // stepCaption
            // 
            this.stepCaption.AutoSize = true;
            this.stepCaption.BackColor = System.Drawing.Color.Transparent;
            this.stepCaption.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "StepCaption", true));
            this.stepCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stepCaption.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.stepCaption.Location = new System.Drawing.Point(10, 5);
            this.stepCaption.Margin = new System.Windows.Forms.Padding(10, 5, 3, 0);
            this.stepCaption.Name = "stepCaption";
            this.stepCaption.Size = new System.Drawing.Size(72, 17);
            this.stepCaption.TabIndex = 1;
            this.stepCaption.Text = "Название";
            // 
            // stepInstructions
            // 
            this.stepInstructions.AutoSize = true;
            this.stepInstructions.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "StepInstructions", true));
            this.stepInstructions.Location = new System.Drawing.Point(40, 42);
            this.stepInstructions.Margin = new System.Windows.Forms.Padding(40, 20, 3, 0);
            this.stepInstructions.Name = "stepInstructions";
            this.stepInstructions.Size = new System.Drawing.Size(135, 13);
            this.stepInstructions.TabIndex = 2;
            this.stepInstructions.Text = "сопроводительный текст";
            // 
            // label1
            // 
            this.label1.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.bindingSource, "Install", true));
            this.label1.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.bindingSource, "InstallOptionVisible", true));
            this.label1.Location = new System.Drawing.Point(111, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 44);
            this.label1.TabIndex = 4;
            this.label1.Text = "Установка";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.bindingSource, "Repair", true));
            this.label2.Location = new System.Drawing.Point(111, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 44);
            this.label2.TabIndex = 4;
            this.label2.Text = "Восстановление";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.bindingSource, "Delete", true));
            this.label3.Location = new System.Drawing.Point(111, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 44);
            this.label3.TabIndex = 4;
            this.label3.Text = "Уаление";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Директория установки:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "InstallPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label5.Location = new System.Drawing.Point(40, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Wbr\\Grande";
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::Installation_v2.Properties.Resources.edittrash;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.bindingSource, "Delete", true));
            this.button3.Location = new System.Drawing.Point(43, 166);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(52, 44);
            this.button3.TabIndex = 3;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::Installation_v2.Properties.Resources.configure_toolbars32;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.bindingSource, "Repair", true));
            this.button2.Location = new System.Drawing.Point(43, 116);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(52, 44);
            this.button2.TabIndex = 3;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // selectPath
            // 
            this.selectPath.Image = global::Installation_v2.Properties.Resources.folder_explore;
            this.selectPath.Location = new System.Drawing.Point(423, 220);
            this.selectPath.Name = "selectPath";
            this.selectPath.Size = new System.Drawing.Size(34, 28);
            this.selectPath.TabIndex = 3;
            this.selectPath.UseVisualStyleBackColor = true;
            this.selectPath.Click += new System.EventHandler(this.SelectInstalPathClick);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Installation_v2.Properties.Resources.kpackage32;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.bindingSource, "Install", true));
            this.button1.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.bindingSource, "InstallOptionVisible", true));
            this.button1.Location = new System.Drawing.Point(43, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 44);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(Installation_v2.PresentationLogic.InstallSelectionUC.DataState.InstallSelectionViewState);
            this.bindingSource.CurrentItemChanged += new System.EventHandler(this.bindingSource_CurrentItemChanged);
            // 
            // InstallSelectionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.selectPath);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.stepInstructions);
            this.Controls.Add(this.stepCaption);
            this.Name = "InstallSelectionView";
            this.Size = new System.Drawing.Size(490, 258);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label stepCaption;
        private System.Windows.Forms.Label stepInstructions;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button selectPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
    }
}
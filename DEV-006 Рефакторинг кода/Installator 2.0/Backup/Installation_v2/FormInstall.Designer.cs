using Installation_v2.PresentationLogic.WelcomeUC.DataState;

namespace Installation_v2 {
    partial class FormInstall {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.finishLabel = new System.Windows.Forms.Label();
            this.installLabel = new System.Windows.Forms.Label();
            this.setupLabel = new System.Windows.Forms.Label();
            this.infoGatheringLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.prevAction = new System.Windows.Forms.Button();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nextAction = new System.Windows.Forms.Button();
            this.cancelAction = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mainStepPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.finishLabel);
            this.panel1.Controls.Add(this.installLabel);
            this.panel1.Controls.Add(this.setupLabel);
            this.panel1.Controls.Add(this.infoGatheringLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(15, 40, 0, 0);
            this.panel1.Size = new System.Drawing.Size(179, 307);
            this.panel1.TabIndex = 0;
            // 
            // finishLabel
            // 
            this.finishLabel.AutoSize = true;
            this.finishLabel.Location = new System.Drawing.Point(18, 124);
            this.finishLabel.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.finishLabel.Name = "finishLabel";
            this.finishLabel.Size = new System.Drawing.Size(117, 13);
            this.finishLabel.TabIndex = 0;
            this.finishLabel.Text = "Окончание установки";
            // 
            // installLabel
            // 
            this.installLabel.AutoSize = true;
            this.installLabel.Location = new System.Drawing.Point(18, 96);
            this.installLabel.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.installLabel.Name = "installLabel";
            this.installLabel.Size = new System.Drawing.Size(62, 13);
            this.installLabel.TabIndex = 0;
            this.installLabel.Text = "Установка";
            // 
            // setupLabel
            // 
            this.setupLabel.AutoSize = true;
            this.setupLabel.Location = new System.Drawing.Point(18, 68);
            this.setupLabel.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.setupLabel.Name = "setupLabel";
            this.setupLabel.Size = new System.Drawing.Size(95, 13);
            this.setupLabel.TabIndex = 0;
            this.setupLabel.Text = "Выбор установки";
            // 
            // infoGatheringLabel
            // 
            this.infoGatheringLabel.AutoSize = true;
            this.infoGatheringLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.infoGatheringLabel.Location = new System.Drawing.Point(18, 40);
            this.infoGatheringLabel.Name = "infoGatheringLabel";
            this.infoGatheringLabel.Size = new System.Drawing.Size(99, 13);
            this.infoGatheringLabel.TabIndex = 0;
            this.infoGatheringLabel.Text = "Сбор информации";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.prevAction);
            this.panel3.Controls.Add(this.nextAction);
            this.panel3.Controls.Add(this.cancelAction);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(179, 258);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(490, 49);
            this.panel3.TabIndex = 2;
            // 
            // prevAction
            // 
            this.prevAction.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.bindingSource, "PrevStepVisible", true));
            this.prevAction.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.bindingSource, "PrevStepAction", true));
            this.prevAction.Location = new System.Drawing.Point(191, 15);
            this.prevAction.Name = "prevAction";
            this.prevAction.Size = new System.Drawing.Size(91, 22);
            this.prevAction.TabIndex = 0;
            this.prevAction.Text = "<< Назад";
            this.prevAction.UseVisualStyleBackColor = true;
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(Installation_v2.PresentationLogic.BaseViewState);
            // 
            // nextAction
            // 
            this.nextAction.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.bindingSource, "NextStepVisible", true));
            this.nextAction.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.bindingSource, "NextStepAction", true));
            this.nextAction.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NextStepCaption", true));
            this.nextAction.Location = new System.Drawing.Point(288, 15);
            this.nextAction.Name = "nextAction";
            this.nextAction.Size = new System.Drawing.Size(91, 22);
            this.nextAction.TabIndex = 0;
            this.nextAction.Text = "Дальше >>";
            this.nextAction.UseVisualStyleBackColor = true;
            // 
            // cancelAction
            // 
            this.cancelAction.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.bindingSource, "CancelStepAction", true));
            this.cancelAction.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "FinishStepCaption", true));
            this.cancelAction.Location = new System.Drawing.Point(385, 15);
            this.cancelAction.Name = "cancelAction";
            this.cancelAction.Size = new System.Drawing.Size(93, 22);
            this.cancelAction.TabIndex = 0;
            this.cancelAction.Text = "Отмена";
            this.cancelAction.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Installation_v2.Properties.Resources.line;
            this.pictureBox1.Location = new System.Drawing.Point(6, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(472, 10);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // mainStepPanel
            // 
            this.mainStepPanel.BackColor = System.Drawing.Color.White;
            this.mainStepPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainStepPanel.Location = new System.Drawing.Point(179, 0);
            this.mainStepPanel.Name = "mainStepPanel";
            this.mainStepPanel.Size = new System.Drawing.Size(490, 258);
            this.mainStepPanel.TabIndex = 3;
            // 
            // FormInstall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 307);
            this.Controls.Add(this.mainStepPanel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormInstall";
            this.Text = "Установщик";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormInstall_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button cancelAction;
        private System.Windows.Forms.Panel mainStepPanel;
        private System.Windows.Forms.Button nextAction;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.Button prevAction;
        private System.Windows.Forms.Label infoGatheringLabel;
        private System.Windows.Forms.Label finishLabel;
        private System.Windows.Forms.Label installLabel;
        private System.Windows.Forms.Label setupLabel;
    }
}
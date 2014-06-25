using Installation_v2.PresentationLogic.WelcomeUC.DataState;

namespace Installation_v2.PresentationLogic.InstallUC.Views {
    partial class InstallView {
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
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stepInstructions = new System.Windows.Forms.Label();
            this.grid = new System.Windows.Forms.DataGridView();
            this.statusDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.captionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Error = new System.Windows.Forms.DataGridViewLinkColumn();
            this.requirementsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requirementsBindingSource)).BeginInit();
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
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(Installation_v2.PresentationLogic.InstallUC.DataState.InstallViewState);
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
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeColumns = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            this.grid.BackgroundColor = System.Drawing.Color.White;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.statusDataGridViewImageColumn,
            this.captionDataGridViewTextBoxColumn,
            this.Error});
            this.grid.DataSource = this.requirementsBindingSource;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grid.Location = new System.Drawing.Point(43, 79);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.grid.RowTemplate.Height = 18;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(401, 148);
            this.grid.TabIndex = 3;
            this.grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // statusDataGridViewImageColumn
            // 
            this.statusDataGridViewImageColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.statusDataGridViewImageColumn.DataPropertyName = "Status";
            this.statusDataGridViewImageColumn.HeaderText = "";
            this.statusDataGridViewImageColumn.Name = "statusDataGridViewImageColumn";
            this.statusDataGridViewImageColumn.ReadOnly = true;
            this.statusDataGridViewImageColumn.Width = 50;
            // 
            // captionDataGridViewTextBoxColumn
            // 
            this.captionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.captionDataGridViewTextBoxColumn.DataPropertyName = "Caption";
            this.captionDataGridViewTextBoxColumn.HeaderText = "Шаг";
            this.captionDataGridViewTextBoxColumn.Name = "captionDataGridViewTextBoxColumn";
            this.captionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Error
            // 
            this.Error.DataPropertyName = "Error";
            this.Error.FillWeight = 70F;
            this.Error.HeaderText = "Результат";
            this.Error.Name = "Error";
            this.Error.ReadOnly = true;
            this.Error.Width = 70;
            // 
            // requirementsBindingSource
            // 
            this.requirementsBindingSource.DataMember = "Requirements";
            this.requirementsBindingSource.DataSource = this.bindingSource;
            // 
            // progressBar1
            // 
            this.progressBar1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ProgressStep", true));
            this.progressBar1.DataBindings.Add(new System.Windows.Forms.Binding("Maximum", this.bindingSource, "ProgressMax", true));
            this.progressBar1.Location = new System.Drawing.Point(43, 61);
            this.progressBar1.Maximum = 2;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(338, 12);
            this.progressBar1.Step = 20;
            this.progressBar1.TabIndex = 4;
            this.progressBar1.Value = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ProgressInfoLabel", true));
            this.label1.Location = new System.Drawing.Point(405, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ErrorMessage", true));
            this.label2.Location = new System.Drawing.Point(40, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 6;
            // 
            // InstallView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.stepInstructions);
            this.Controls.Add(this.stepCaption);
            this.Name = "InstallView";
            this.Size = new System.Drawing.Size(490, 258);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requirementsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label stepCaption;
        private System.Windows.Forms.Label stepInstructions;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.BindingSource requirementsBindingSource;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewImageColumn statusDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn captionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewLinkColumn Error;
    }
}
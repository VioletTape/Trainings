namespace Installation_v2.PresentationLogic.RemoveTempUC.Views
{
    partial class RemoveTempView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.stepCaption = new System.Windows.Forms.Label();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stepInstructions = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.grid = new System.Windows.Forms.BindingSource(this.components);
            this.statusDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.captionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Error = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
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
            this.stepCaption.TabIndex = 2;
            this.stepCaption.Text = "Название";
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(Installation_v2.PresentationLogic.RemoveTempUC.DataState.RemoveTempViewState);
            // 
            // stepInstructions
            // 
            this.stepInstructions.AutoSize = true;
            this.stepInstructions.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "StepInstructions", true));
            this.stepInstructions.Location = new System.Drawing.Point(40, 42);
            this.stepInstructions.Margin = new System.Windows.Forms.Padding(40, 20, 3, 0);
            this.stepInstructions.Name = "stepInstructions";
            this.stepInstructions.Size = new System.Drawing.Size(135, 13);
            this.stepInstructions.TabIndex = 3;
            this.stepInstructions.Text = "сопроводительный текст";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.statusDataGridViewImageColumn,
            this.captionDataGridViewTextBoxColumn,
            this.Error});
            this.dataGridView1.DataSource = this.grid;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(43, 79);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 18;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(401, 148);
            this.dataGridView1.TabIndex = 3;
            // 
            // grid
            // 
            this.grid.DataMember = "Requirements";
            this.grid.DataSource = this.bindingSource;
            // 
            // statusDataGridViewImageColumn
            // 
            this.statusDataGridViewImageColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.statusDataGridViewImageColumn.DataPropertyName = "Status";
            this.statusDataGridViewImageColumn.FillWeight = 50F;
            this.statusDataGridViewImageColumn.HeaderText = "";
            this.statusDataGridViewImageColumn.Name = "statusDataGridViewImageColumn";
            this.statusDataGridViewImageColumn.ReadOnly = true;
            this.statusDataGridViewImageColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
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
            // RemoveTempView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.stepInstructions);
            this.Controls.Add(this.stepCaption);
            this.Name = "RemoveTempView";
            this.Size = new System.Drawing.Size(490, 258);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.Label stepCaption;
        private System.Windows.Forms.Label stepInstructions;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource grid;
        private System.Windows.Forms.DataGridViewImageColumn statusDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn captionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewLinkColumn Error;
    }
}

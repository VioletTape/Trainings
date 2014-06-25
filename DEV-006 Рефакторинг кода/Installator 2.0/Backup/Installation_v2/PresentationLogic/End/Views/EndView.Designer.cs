using Installation_v2.PresentationLogic.WelcomeUC.DataState;

namespace Installation_v2.PresentationLogic.End.Views {
    partial class EndView {
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
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(Installation_v2.PresentationLogic.End.DataState.EndViewState);
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
            // EndView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.stepInstructions);
            this.Controls.Add(this.stepCaption);
            this.Name = "EndView";
            this.Size = new System.Drawing.Size(490, 258);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label stepCaption;
        private System.Windows.Forms.Label stepInstructions;
        private System.Windows.Forms.BindingSource bindingSource;
    }
}
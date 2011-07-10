namespace Asquell.GUI
{
    partial class FormMemoryDetail
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
            this.groupBox_GenericDetail = new System.Windows.Forms.GroupBox();
            this.propertyGrid_Generics = new System.Windows.Forms.PropertyGrid();
            this.listBox_Specifics = new System.Windows.Forms.ListBox();
            this.groupBox_GenericDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_GenericDetail
            // 
            this.groupBox_GenericDetail.Controls.Add(this.propertyGrid_Generics);
            this.groupBox_GenericDetail.Location = new System.Drawing.Point(12, 12);
            this.groupBox_GenericDetail.Name = "groupBox_GenericDetail";
            this.groupBox_GenericDetail.Size = new System.Drawing.Size(333, 398);
            this.groupBox_GenericDetail.TabIndex = 0;
            this.groupBox_GenericDetail.TabStop = false;
            this.groupBox_GenericDetail.Text = "Generic Object Detail";
            // 
            // propertyGrid_Generics
            // 
            this.propertyGrid_Generics.Location = new System.Drawing.Point(6, 19);
            this.propertyGrid_Generics.Name = "propertyGrid_Generics";
            this.propertyGrid_Generics.Size = new System.Drawing.Size(321, 373);
            this.propertyGrid_Generics.TabIndex = 0;
            // 
            // listBox_Specifics
            // 
            this.listBox_Specifics.FormattingEnabled = true;
            this.listBox_Specifics.Location = new System.Drawing.Point(351, 12);
            this.listBox_Specifics.Name = "listBox_Specifics";
            this.listBox_Specifics.Size = new System.Drawing.Size(361, 394);
            this.listBox_Specifics.TabIndex = 1;
            this.listBox_Specifics.DoubleClick += new System.EventHandler(this.listBox_Specifics_DoubleClick);
            // 
            // FormMemoryDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 422);
            this.Controls.Add(this.listBox_Specifics);
            this.Controls.Add(this.groupBox_GenericDetail);
            this.MaximizeBox = false;
            this.Name = "FormMemoryDetail";
            this.Text = "Memory Detail";
            this.groupBox_GenericDetail.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_GenericDetail;
        private System.Windows.Forms.PropertyGrid propertyGrid_Generics;
        private System.Windows.Forms.ListBox listBox_Specifics;
    }
}
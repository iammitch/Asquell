namespace Asquell
{
    partial class FormMain
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox_MemoryObjects = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_RunLine = new System.Windows.Forms.Button();
            this.button_Execute = new System.Windows.Forms.Button();
            this.textBox_Code = new System.Windows.Forms.TextBox();
            this.textBox_lastLine = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.propertyGrid_MemoryObj = new System.Windows.Forms.PropertyGrid();
            this.button_loadScript = new System.Windows.Forms.Button();
            this.button_saveScript = new System.Windows.Forms.Button();
            this.openFileDialog_LoadScript = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog_SaveScript = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.propertyGrid_MemoryObj);
            this.groupBox1.Controls.Add(this.listBox_MemoryObjects);
            this.groupBox1.Location = new System.Drawing.Point(508, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 438);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Memory Objects";
            // 
            // listBox_MemoryObjects
            // 
            this.listBox_MemoryObjects.FormattingEnabled = true;
            this.listBox_MemoryObjects.Location = new System.Drawing.Point(6, 19);
            this.listBox_MemoryObjects.Name = "listBox_MemoryObjects";
            this.listBox_MemoryObjects.Size = new System.Drawing.Size(352, 147);
            this.listBox_MemoryObjects.TabIndex = 0;
            this.listBox_MemoryObjects.SelectedIndexChanged += new System.EventHandler(this.listBox_MemoryObjects_SelectedIndexChanged);
            this.listBox_MemoryObjects.DoubleClick += new System.EventHandler(this.listBox_MemoryObjects_DoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_saveScript);
            this.groupBox2.Controls.Add(this.button_loadScript);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(490, 82);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controls";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.textBox_lastLine);
            this.groupBox3.Controls.Add(this.button_RunLine);
            this.groupBox3.Controls.Add(this.button_Execute);
            this.groupBox3.Controls.Add(this.textBox_Code);
            this.groupBox3.Location = new System.Drawing.Point(12, 100);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(490, 350);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Script Input";
            // 
            // button_RunLine
            // 
            this.button_RunLine.Location = new System.Drawing.Point(6, 319);
            this.button_RunLine.Name = "button_RunLine";
            this.button_RunLine.Size = new System.Drawing.Size(75, 23);
            this.button_RunLine.TabIndex = 2;
            this.button_RunLine.Text = "Run Single Line";
            this.button_RunLine.UseVisualStyleBackColor = true;
            this.button_RunLine.Click += new System.EventHandler(this.button_RunLine_Click);
            // 
            // button_Execute
            // 
            this.button_Execute.Location = new System.Drawing.Point(409, 319);
            this.button_Execute.Name = "button_Execute";
            this.button_Execute.Size = new System.Drawing.Size(75, 23);
            this.button_Execute.TabIndex = 1;
            this.button_Execute.Text = "Execute";
            this.button_Execute.UseVisualStyleBackColor = true;
            this.button_Execute.Click += new System.EventHandler(this.button_Execute_Click);
            // 
            // textBox_Code
            // 
            this.textBox_Code.Location = new System.Drawing.Point(6, 19);
            this.textBox_Code.Multiline = true;
            this.textBox_Code.Name = "textBox_Code";
            this.textBox_Code.Size = new System.Drawing.Size(478, 268);
            this.textBox_Code.TabIndex = 0;
            // 
            // textBox_lastLine
            // 
            this.textBox_lastLine.Enabled = false;
            this.textBox_lastLine.Location = new System.Drawing.Point(90, 293);
            this.textBox_lastLine.Name = "textBox_lastLine";
            this.textBox_lastLine.Size = new System.Drawing.Size(394, 20);
            this.textBox_lastLine.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 296);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Line Executed:";
            // 
            // propertyGrid_MemoryObj
            // 
            this.propertyGrid_MemoryObj.Location = new System.Drawing.Point(6, 172);
            this.propertyGrid_MemoryObj.Name = "propertyGrid_MemoryObj";
            this.propertyGrid_MemoryObj.Size = new System.Drawing.Size(352, 260);
            this.propertyGrid_MemoryObj.TabIndex = 1;
            // 
            // button_loadScript
            // 
            this.button_loadScript.Location = new System.Drawing.Point(6, 19);
            this.button_loadScript.Name = "button_loadScript";
            this.button_loadScript.Size = new System.Drawing.Size(75, 23);
            this.button_loadScript.TabIndex = 0;
            this.button_loadScript.Text = "Load";
            this.button_loadScript.UseVisualStyleBackColor = true;
            this.button_loadScript.Click += new System.EventHandler(this.button_loadScript_Click);
            // 
            // button_saveScript
            // 
            this.button_saveScript.Location = new System.Drawing.Point(87, 19);
            this.button_saveScript.Name = "button_saveScript";
            this.button_saveScript.Size = new System.Drawing.Size(75, 23);
            this.button_saveScript.TabIndex = 1;
            this.button_saveScript.Text = "Save";
            this.button_saveScript.UseVisualStyleBackColor = true;
            this.button_saveScript.Click += new System.EventHandler(this.button_saveScript_Click);
            // 
            // openFileDialog_LoadScript
            // 
            this.openFileDialog_LoadScript.Filter = "All file|*.*";
            this.openFileDialog_LoadScript.Title = "Load Script...";
            // 
            // saveFileDialog_SaveScript
            // 
            this.saveFileDialog_SaveScript.Filter = "All files|*.*";
            this.saveFileDialog_SaveScript.Title = "Save Script As...";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 462);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "Asquell Test Platform";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox_MemoryObjects;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_Execute;
        private System.Windows.Forms.TextBox textBox_Code;
        private System.Windows.Forms.Button button_RunLine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_lastLine;
        private System.Windows.Forms.PropertyGrid propertyGrid_MemoryObj;
        private System.Windows.Forms.Button button_saveScript;
        private System.Windows.Forms.Button button_loadScript;
        private System.Windows.Forms.OpenFileDialog openFileDialog_LoadScript;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_SaveScript;
    }
}


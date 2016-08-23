namespace TestSyllableBreaker
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnSaveSyllable = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSaveSyllable = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtOpenFilePath = new System.Windows.Forms.TextBox();
            this.radiobtnOrtho = new System.Windows.Forms.RadioButton();
            this.radiobtnPhono = new System.Windows.Forms.RadioButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripLblSuccess = new System.Windows.Forms.ToolStripStatusLabel();
            this.picBoxLoading = new System.Windows.Forms.PictureBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Myanmar3", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(12, 154);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(462, 108);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(346, 266);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Break Syllable";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Font = new System.Drawing.Font("Myanmar3", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(12, 315);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(462, 115);
            this.textBox2.TabIndex = 3;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Myanmar3", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(12, 456);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox3.Size = new System.Drawing.Size(462, 108);
            this.textBox3.TabIndex = 4;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Input Text\r\n";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 299);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Orthographic Syllable Break\r\n";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 438);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Phonologic Syllable Break\r\n";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Text File(*.txt)|*.txt";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Text File(*.txt)|*.txt";
            // 
            // btnSaveSyllable
            // 
            this.btnSaveSyllable.Location = new System.Drawing.Point(382, 96);
            this.btnSaveSyllable.Name = "btnSaveSyllable";
            this.btnSaveSyllable.Size = new System.Drawing.Size(75, 23);
            this.btnSaveSyllable.TabIndex = 15;
            this.btnSaveSyllable.Text = "Save File";
            this.btnSaveSyllable.UseVisualStyleBackColor = true;
            this.btnSaveSyllable.Click += new System.EventHandler(this.btnSaveSyllable_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Open Only Burmese Sentences File";
            // 
            // txtSaveSyllable
            // 
            this.txtSaveSyllable.Location = new System.Drawing.Point(32, 98);
            this.txtSaveSyllable.Name = "txtSaveSyllable";
            this.txtSaveSyllable.ReadOnly = true;
            this.txtSaveSyllable.Size = new System.Drawing.Size(318, 20);
            this.txtSaveSyllable.TabIndex = 14;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(382, 25);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 12;
            this.btnOpen.Text = "Open File";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Save Syllable Break File";
            // 
            // txtOpenFilePath
            // 
            this.txtOpenFilePath.Location = new System.Drawing.Point(32, 25);
            this.txtOpenFilePath.Name = "txtOpenFilePath";
            this.txtOpenFilePath.ReadOnly = true;
            this.txtOpenFilePath.Size = new System.Drawing.Size(318, 20);
            this.txtOpenFilePath.TabIndex = 11;
            // 
            // radiobtnOrtho
            // 
            this.radiobtnOrtho.AutoSize = true;
            this.radiobtnOrtho.Location = new System.Drawing.Point(113, 54);
            this.radiobtnOrtho.Name = "radiobtnOrtho";
            this.radiobtnOrtho.Size = new System.Drawing.Size(117, 17);
            this.radiobtnOrtho.TabIndex = 17;
            this.radiobtnOrtho.TabStop = true;
            this.radiobtnOrtho.Text = "Orthographic Break";
            this.radiobtnOrtho.UseVisualStyleBackColor = true;
            this.radiobtnOrtho.CheckedChanged += new System.EventHandler(this.radiobtnOrtho_CheckedChanged);
            // 
            // radiobtnPhono
            // 
            this.radiobtnPhono.AutoSize = true;
            this.radiobtnPhono.Location = new System.Drawing.Point(238, 55);
            this.radiobtnPhono.Name = "radiobtnPhono";
            this.radiobtnPhono.Size = new System.Drawing.Size(109, 17);
            this.radiobtnPhono.TabIndex = 18;
            this.radiobtnPhono.TabStop = true;
            this.radiobtnPhono.Text = "Phonologic Break";
            this.radiobtnPhono.UseVisualStyleBackColor = true;
            this.radiobtnPhono.CheckedChanged += new System.EventHandler(this.radiobtnPhono_CheckedChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLblSuccess});
            this.statusStrip1.Location = new System.Drawing.Point(0, 567);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(486, 22);
            this.statusStrip1.TabIndex = 19;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripLblSuccess
            // 
            this.toolStripLblSuccess.Name = "toolStripLblSuccess";
            this.toolStripLblSuccess.Size = new System.Drawing.Size(0, 17);
            this.toolStripLblSuccess.Visible = false;
            // 
            // picBoxLoading
            // 
            this.picBoxLoading.Image = global::TestSyllableBreaker.Properties.Resources.loading;
            this.picBoxLoading.Location = new System.Drawing.Point(3, 571);
            this.picBoxLoading.Name = "picBoxLoading";
            this.picBoxLoading.Size = new System.Drawing.Size(128, 15);
            this.picBoxLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picBoxLoading.TabIndex = 20;
            this.picBoxLoading.TabStop = false;
            this.picBoxLoading.Visible = false;
            this.picBoxLoading.WaitOnLoad = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 589);
            this.Controls.Add(this.picBoxLoading);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.radiobtnPhono);
            this.Controls.Add(this.radiobtnOrtho);
            this.Controls.Add(this.btnSaveSyllable);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSaveSyllable);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtOpenFilePath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SyllableBreak";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnSaveSyllable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSaveSyllable;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtOpenFilePath;
        private System.Windows.Forms.RadioButton radiobtnOrtho;
        private System.Windows.Forms.RadioButton radiobtnPhono;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.PictureBox picBoxLoading;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLblSuccess;
    }
}


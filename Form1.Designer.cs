namespace WindowsFormsApp8
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnLoadFile = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnProcessFile = new MaterialSkin.Controls.MaterialRaisedButton();
            this.lblStatus = new MaterialSkin.Controls.MaterialLabel();
            this.btnClear = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Depth = 0;
            this.btnLoadFile.Location = new System.Drawing.Point(53, 100);
            this.btnLoadFile.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnLoadFile.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Primary = true;
            this.btnLoadFile.Size = new System.Drawing.Size(192, 94);
            this.btnLoadFile.TabIndex = 0;
            this.btnLoadFile.Text = "Drag and Drop the File";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // btnProcessFile
            // 
            this.btnProcessFile.Depth = 0;
            this.btnProcessFile.Location = new System.Drawing.Point(456, 100);
            this.btnProcessFile.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnProcessFile.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnProcessFile.Name = "btnProcessFile";
            this.btnProcessFile.Primary = true;
            this.btnProcessFile.Size = new System.Drawing.Size(191, 94);
            this.btnProcessFile.TabIndex = 1;
            this.btnProcessFile.Text = "Magic";
            this.btnProcessFile.UseVisualStyleBackColor = true;
            this.btnProcessFile.Click += new System.EventHandler(this.btnProcessFile_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Depth = 0;
            this.lblStatus.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblStatus.Location = new System.Drawing.Point(12, 200);
            this.lblStatus.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(676, 191);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // btnClear
            // 
            this.btnClear.Depth = 0;
            this.btnClear.Location = new System.Drawing.Point(237, 297);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClear.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClear.Name = "btnClear";
            this.btnClear.Primary = true;
            this.btnClear.Size = new System.Drawing.Size(119, 49);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(700, 500);
            this.Controls.Add(this.btnLoadFile);
            this.Controls.Add(this.btnProcessFile);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnClear);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PSS Construction";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        private MaterialSkin.Controls.MaterialRaisedButton btnLoadFile;
        private MaterialSkin.Controls.MaterialRaisedButton btnProcessFile;
        private MaterialSkin.Controls.MaterialLabel lblStatus;
        private MaterialSkin.Controls.MaterialRaisedButton btnClear;
    }
}

namespace CreatePowerPointSlide
{
    partial class frmCreateSlide
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
            this.btnCreate = new System.Windows.Forms.Button();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.rtText = new System.Windows.Forms.RichTextBox();
            this.btnSuggestImg = new System.Windows.Forms.Button();
            this.chkLstImages = new System.Windows.Forms.CheckedListBox();
            this.lblSuggestImgs = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(81, 415);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Create Slide";
            this.btnCreate.UseVisualStyleBackColor = true;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(81, 21);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(693, 20);
            this.txtTitle.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(23, 28);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(27, 13);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Title";
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(23, 61);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(28, 13);
            this.lblText.TabIndex = 3;
            this.lblText.Text = "Text";
            // 
            // rtText
            // 
            this.rtText.Location = new System.Drawing.Point(81, 61);
            this.rtText.Name = "rtText";
            this.rtText.Size = new System.Drawing.Size(693, 159);
            this.rtText.TabIndex = 4;
            this.rtText.Text = "";
            // 
            // btnSuggestImg
            // 
            this.btnSuggestImg.Location = new System.Drawing.Point(81, 227);
            this.btnSuggestImg.Name = "btnSuggestImg";
            this.btnSuggestImg.Size = new System.Drawing.Size(106, 23);
            this.btnSuggestImg.TabIndex = 5;
            this.btnSuggestImg.Text = "Suggest Images";
            this.btnSuggestImg.UseVisualStyleBackColor = true;
            // 
            // chkLstImages
            // 
            this.chkLstImages.FormattingEnabled = true;
            this.chkLstImages.Location = new System.Drawing.Point(81, 302);
            this.chkLstImages.Name = "chkLstImages";
            this.chkLstImages.Size = new System.Drawing.Size(484, 94);
            this.chkLstImages.TabIndex = 6;
            // 
            // lblSuggestImgs
            // 
            this.lblSuggestImgs.AutoSize = true;
            this.lblSuggestImgs.Location = new System.Drawing.Point(81, 283);
            this.lblSuggestImgs.Name = "lblSuggestImgs";
            this.lblSuggestImgs.Size = new System.Drawing.Size(95, 13);
            this.lblSuggestImgs.TabIndex = 7;
            this.lblSuggestImgs.Text = "Suggested Images";
            // 
            // frmCreateSlide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblSuggestImgs);
            this.Controls.Add(this.chkLstImages);
            this.Controls.Add(this.btnSuggestImg);
            this.Controls.Add(this.rtText);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.btnCreate);
            this.Name = "frmCreateSlide";
            this.Text = "Create PowerPoint Slide";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.RichTextBox rtText;
        private System.Windows.Forms.Button btnSuggestImg;
        private System.Windows.Forms.CheckedListBox chkLstImages;
        private System.Windows.Forms.Label lblSuggestImgs;
    }
}


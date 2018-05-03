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
            this.pictBox = new System.Windows.Forms.PictureBox();
            this.btnToggleBold = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(81, 466);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 4;
            this.btnCreate.Text = "Create Slide";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(81, 21);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(693, 20);
            this.txtTitle.TabIndex = 0;
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
            this.lblText.Location = new System.Drawing.Point(22, 97);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(28, 13);
            this.lblText.TabIndex = 3;
            this.lblText.Text = "Text";
            // 
            // rtText
            // 
            this.rtText.Location = new System.Drawing.Point(81, 97);
            this.rtText.Name = "rtText";
            this.rtText.Size = new System.Drawing.Size(693, 159);
            this.rtText.TabIndex = 1;
            this.rtText.Text = "";
            // 
            // btnSuggestImg
            // 
            this.btnSuggestImg.Location = new System.Drawing.Point(81, 262);
            this.btnSuggestImg.Name = "btnSuggestImg";
            this.btnSuggestImg.Size = new System.Drawing.Size(106, 23);
            this.btnSuggestImg.TabIndex = 2;
            this.btnSuggestImg.Text = "Suggest Images";
            this.btnSuggestImg.UseVisualStyleBackColor = true;
            this.btnSuggestImg.Click += new System.EventHandler(this.btnSuggestImg_Click);
            // 
            // chkLstImages
            // 
            this.chkLstImages.FormattingEnabled = true;
            this.chkLstImages.Location = new System.Drawing.Point(81, 353);
            this.chkLstImages.Name = "chkLstImages";
            this.chkLstImages.Size = new System.Drawing.Size(484, 94);
            this.chkLstImages.TabIndex = 3;
            this.chkLstImages.SelectedIndexChanged += new System.EventHandler(this.chkLstImages_SelectedIndexChanged);
            // 
            // lblSuggestImgs
            // 
            this.lblSuggestImgs.AutoSize = true;
            this.lblSuggestImgs.Location = new System.Drawing.Point(81, 334);
            this.lblSuggestImgs.Name = "lblSuggestImgs";
            this.lblSuggestImgs.Size = new System.Drawing.Size(95, 13);
            this.lblSuggestImgs.TabIndex = 7;
            this.lblSuggestImgs.Text = "Suggested Images";
            // 
            // pictBox
            // 
            this.pictBox.Location = new System.Drawing.Point(571, 272);
            this.pictBox.Name = "pictBox";
            this.pictBox.Size = new System.Drawing.Size(203, 246);
            this.pictBox.TabIndex = 8;
            this.pictBox.TabStop = false;
            // 
            // btnToggleBold
            // 
            this.btnToggleBold.Location = new System.Drawing.Point(81, 68);
            this.btnToggleBold.Name = "btnToggleBold";
            this.btnToggleBold.Size = new System.Drawing.Size(75, 23);
            this.btnToggleBold.TabIndex = 9;
            this.btnToggleBold.Text = "Bold*";
            this.btnToggleBold.UseVisualStyleBackColor = true;
            this.btnToggleBold.Click += new System.EventHandler(this.btnFormat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(205, 268);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "* - Bold words are used to suggest images";
            // 
            // frmCreateSlide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 530);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnToggleBold);
            this.Controls.Add(this.pictBox);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictBox)).EndInit();
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
        private System.Windows.Forms.PictureBox pictBox;
        private System.Windows.Forms.Button btnToggleBold;
        private System.Windows.Forms.Label label1;
    }
}


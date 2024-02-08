namespace WorldCupScore_OOP
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.rbMen = new System.Windows.Forms.RadioButton();
            this.rbWomen = new System.Windows.Forms.RadioButton();
            this.rbEnglish = new System.Windows.Forms.RadioButton();
            this.rbCroatian = new System.Windows.Forms.RadioButton();
            this.lblMode = new System.Windows.Forms.Label();
            this.cbOffline = new System.Windows.Forms.CheckBox();
            this.groupBoxChamp = new System.Windows.Forms.GroupBox();
            this.groupBoxLang = new System.Windows.Forms.GroupBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBoxChamp.SuspendLayout();
            this.groupBoxLang.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbMen
            // 
            resources.ApplyResources(this.rbMen, "rbMen");
            this.rbMen.Name = "rbMen";
            this.rbMen.TabStop = true;
            this.rbMen.UseVisualStyleBackColor = true;
            // 
            // rbWomen
            // 
            resources.ApplyResources(this.rbWomen, "rbWomen");
            this.rbWomen.Name = "rbWomen";
            this.rbWomen.TabStop = true;
            this.rbWomen.UseVisualStyleBackColor = true;
            // 
            // rbEnglish
            // 
            resources.ApplyResources(this.rbEnglish, "rbEnglish");
            this.rbEnglish.Name = "rbEnglish";
            this.rbEnglish.UseVisualStyleBackColor = true;
            // 
            // rbCroatian
            // 
            resources.ApplyResources(this.rbCroatian, "rbCroatian");
            this.rbCroatian.Checked = true;
            this.rbCroatian.Name = "rbCroatian";
            this.rbCroatian.TabStop = true;
            this.rbCroatian.UseVisualStyleBackColor = true;
            // 
            // lblMode
            // 
            resources.ApplyResources(this.lblMode, "lblMode");
            this.lblMode.Name = "lblMode";
            // 
            // cbOffline
            // 
            resources.ApplyResources(this.cbOffline, "cbOffline");
            this.cbOffline.Name = "cbOffline";
            this.cbOffline.UseVisualStyleBackColor = true;
            // 
            // groupBoxChamp
            // 
            resources.ApplyResources(this.groupBoxChamp, "groupBoxChamp");
            this.groupBoxChamp.Controls.Add(this.rbMen);
            this.groupBoxChamp.Controls.Add(this.cbOffline);
            this.groupBoxChamp.Controls.Add(this.rbWomen);
            this.groupBoxChamp.Controls.Add(this.lblMode);
            this.groupBoxChamp.Name = "groupBoxChamp";
            this.groupBoxChamp.TabStop = false;
            // 
            // groupBoxLang
            // 
            resources.ApplyResources(this.groupBoxLang, "groupBoxLang");
            this.groupBoxLang.Controls.Add(this.rbCroatian);
            this.groupBoxLang.Controls.Add(this.rbEnglish);
            this.groupBoxLang.Name = "groupBoxLang";
            this.groupBoxLang.TabStop = false;
            // 
            // btnConfirm
            // 
            resources.ApplyResources(this.btnConfirm, "btnConfirm");
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SettingsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.groupBoxLang);
            this.Controls.Add(this.groupBoxChamp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SettingsForm";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.groupBoxChamp.ResumeLayout(false);
            this.groupBoxChamp.PerformLayout();
            this.groupBoxLang.ResumeLayout(false);
            this.groupBoxLang.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbMen;
        private System.Windows.Forms.RadioButton rbWomen;
        private System.Windows.Forms.RadioButton rbEnglish;
        private System.Windows.Forms.RadioButton rbCroatian;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.CheckBox cbOffline;
        private System.Windows.Forms.GroupBox groupBoxChamp;
        private System.Windows.Forms.GroupBox groupBoxLang;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
    }
}
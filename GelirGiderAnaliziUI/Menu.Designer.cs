namespace GelirGiderAnaliziUI
{
    partial class Menu
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.btnGider = new System.Windows.Forms.Button();
            this.btnGiderIslem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGider
            // 
            this.btnGider.Location = new System.Drawing.Point(50, 30);
            this.btnGider.Name = "btnGider";
            this.btnGider.Size = new System.Drawing.Size(200, 50);
            this.btnGider.TabIndex = 0;
            this.btnGider.Text = "Gider";
            this.btnGider.UseVisualStyleBackColor = true;
            this.btnGider.Click += new System.EventHandler(this.btnGider_Click);
            // 
            // btnGiderIslem
            // 
            this.btnGiderIslem.Location = new System.Drawing.Point(50, 100);
            this.btnGiderIslem.Name = "btnGiderIslem";
            this.btnGiderIslem.Size = new System.Drawing.Size(200, 50);
            this.btnGiderIslem.TabIndex = 1;
            this.btnGiderIslem.Text = "Gider İşlem";
            this.btnGiderIslem.UseVisualStyleBackColor = true;
            this.btnGiderIslem.Click += new System.EventHandler(this.btnGiderIslem_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.btnGiderIslem);
            this.Controls.Add(this.btnGider);
            this.Name = "MenuForm";
            this.Text = "Ana Menü";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnGider;
        private System.Windows.Forms.Button btnGiderIslem;
    }
}

namespace GelirGiderAnaliziLocalDb
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
            btnGider = new Button();
            btnGiderIslem = new Button();
            SuspendLayout();
            // 
            // btnGider
            // 
            btnGider.Location = new Point(50, 38);
            btnGider.Margin = new Padding(3, 4, 3, 4);
            btnGider.Name = "btnGider";
            btnGider.Size = new Size(200, 62);
            btnGider.TabIndex = 0;
            btnGider.Text = "Gider";
            btnGider.UseVisualStyleBackColor = true;
            btnGider.Click += btnGider_Click;
            // 
            // btnGiderIslem
            // 
            btnGiderIslem.Location = new Point(50, 125);
            btnGiderIslem.Margin = new Padding(3, 4, 3, 4);
            btnGiderIslem.Name = "btnGiderIslem";
            btnGiderIslem.Size = new Size(200, 62);
            btnGiderIslem.TabIndex = 1;
            btnGiderIslem.Text = "Gider İşlem";
            btnGiderIslem.UseVisualStyleBackColor = true;
            btnGiderIslem.Click += btnGiderIslem_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(300, 250);
            Controls.Add(btnGiderIslem);
            Controls.Add(btnGider);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Menu";
            Text = "Ana Menü";
            Load += Menu_Load;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnGider;
        private System.Windows.Forms.Button btnGiderIslem;
    }
}

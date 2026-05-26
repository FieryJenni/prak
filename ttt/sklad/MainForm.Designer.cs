namespace sklad
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.productsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suppliersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suppliesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblUserRole = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();

            // menuStrip
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.productsMenuItem,
                this.suppliersMenuItem,
                this.suppliesMenuItem,
                this.adminMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";

            // productsMenuItem
            this.productsMenuItem.Name = "productsMenuItem";
            this.productsMenuItem.Size = new System.Drawing.Size(62, 20);
            this.productsMenuItem.Text = "Товары";
            this.productsMenuItem.Click += new System.EventHandler(this.productsMenuItem_Click);

            // suppliersMenuItem
            this.suppliersMenuItem.Name = "suppliersMenuItem";
            this.suppliersMenuItem.Size = new System.Drawing.Size(81, 20);
            this.suppliersMenuItem.Text = "Поставщики";
            this.suppliersMenuItem.Click += new System.EventHandler(this.suppliersMenuItem_Click);

            // suppliesMenuItem
            this.suppliesMenuItem.Name = "suppliesMenuItem";
            this.suppliesMenuItem.Size = new System.Drawing.Size(68, 20);
            this.suppliesMenuItem.Text = "Поставки";
            this.suppliesMenuItem.Click += new System.EventHandler(this.suppliesMenuItem_Click);

            // adminMenuItem
            this.adminMenuItem.Name = "adminMenuItem";
            this.adminMenuItem.Size = new System.Drawing.Size(86, 20);
            this.adminMenuItem.Text = "Администрирование";
            this.adminMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.usersMenuItem,
                this.logsMenuItem});

            // usersMenuItem
            this.usersMenuItem.Name = "usersMenuItem";
            this.usersMenuItem.Size = new System.Drawing.Size(186, 22);
            this.usersMenuItem.Text = "Пользователи";
            this.usersMenuItem.Click += new System.EventHandler(this.usersMenuItem_Click);

            // logsMenuItem
            this.logsMenuItem.Name = "logsMenuItem";
            this.logsMenuItem.Size = new System.Drawing.Size(186, 22);
            this.logsMenuItem.Text = "Журнал входов";
            this.logsMenuItem.Click += new System.EventHandler(this.logsMenuItem_Click);

            // statusStrip
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.lblUserRole});
            this.statusStrip.Location = new System.Drawing.Point(0, 428);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(800, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip";

            // lblUserRole
            this.lblUserRole.Name = "lblUserRole";
            this.lblUserRole.Size = new System.Drawing.Size(0, 17);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Складская информационная система";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem productsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suppliersMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suppliesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logsMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblUserRole;
    }
}
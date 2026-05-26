namespace sklad
{
    partial class RegistrForm
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelFIO = new System.Windows.Forms.Label();
            this.textBoxFIO = new System.Windows.Forms.TextBox();
            this.labelLogin = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelConfirm = new System.Windows.Forms.Label();
            this.textBoxConfirimPassword = new System.Windows.Forms.TextBox();
            this.buttonRegistration = new System.Windows.Forms.Button();
            this.labelToGoLogin = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();

            // panelTop
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.panelTop.Controls.Add(this.labelTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(500, 90);
            this.panelTop.TabIndex = 0;

            // labelTitle
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(170, 25);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(160, 37);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Регистрация";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // labelFIO
            this.labelFIO.AutoSize = true;
            this.labelFIO.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.labelFIO.Location = new System.Drawing.Point(70, 110);
            this.labelFIO.Name = "labelFIO";
            this.labelFIO.Size = new System.Drawing.Size(44, 20);
            this.labelFIO.TabIndex = 1;
            this.labelFIO.Text = "ФИО:";

            // textBoxFIO
            this.textBoxFIO.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxFIO.Location = new System.Drawing.Point(70, 135);
            this.textBoxFIO.Name = "textBoxFIO";
            this.textBoxFIO.Size = new System.Drawing.Size(360, 29);
            this.textBoxFIO.TabIndex = 2;
            this.textBoxFIO.Text = "Иванов Иван Иванович";
            this.textBoxFIO.ForeColor = System.Drawing.Color.Gray;
            this.textBoxFIO.Enter += new System.EventHandler(this.textBoxFIO_Enter);
            this.textBoxFIO.Leave += new System.EventHandler(this.textBoxFIO_Leave);

            // labelLogin
            this.labelLogin.AutoSize = true;
            this.labelLogin.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.labelLogin.Location = new System.Drawing.Point(70, 180);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(53, 20);
            this.labelLogin.TabIndex = 3;
            this.labelLogin.Text = "Логин:";

            // textBoxUserName
            this.textBoxUserName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxUserName.Location = new System.Drawing.Point(70, 205);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(360, 29);
            this.textBoxUserName.TabIndex = 4;
            this.textBoxUserName.Text = "ivanov";
            this.textBoxUserName.ForeColor = System.Drawing.Color.Gray;
            this.textBoxUserName.Enter += new System.EventHandler(this.textBoxUserName_Enter);
            this.textBoxUserName.Leave += new System.EventHandler(this.textBoxUserName_Leave);

            // labelEmail
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.labelEmail.Location = new System.Drawing.Point(70, 250);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(56, 20);
            this.labelEmail.TabIndex = 5;
            this.labelEmail.Text = "Почта:";

            // textBoxEmail
            this.textBoxEmail.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxEmail.Location = new System.Drawing.Point(70, 275);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(360, 29);
            this.textBoxEmail.TabIndex = 6;
            this.textBoxEmail.Text = "example@mail.com";
            this.textBoxEmail.ForeColor = System.Drawing.Color.Gray;
            this.textBoxEmail.Enter += new System.EventHandler(this.textBoxEmail_Enter);
            this.textBoxEmail.Leave += new System.EventHandler(this.textBoxEmail_Leave);

            // labelPassword
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.labelPassword.Location = new System.Drawing.Point(70, 320);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(65, 20);
            this.labelPassword.TabIndex = 7;
            this.labelPassword.Text = "Пароль:";

            // textBoxPassword
            this.textBoxPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxPassword.Location = new System.Drawing.Point(70, 345);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(360, 29);
            this.textBoxPassword.TabIndex = 8;
            this.textBoxPassword.Text = "пароль";
            this.textBoxPassword.ForeColor = System.Drawing.Color.Gray;
            this.textBoxPassword.UseSystemPasswordChar = false;
            this.textBoxPassword.Enter += new System.EventHandler(this.textBoxPassword_Enter);
            this.textBoxPassword.Leave += new System.EventHandler(this.textBoxPassword_Leave);

            // labelConfirm
            this.labelConfirm.AutoSize = true;
            this.labelConfirm.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.labelConfirm.Location = new System.Drawing.Point(70, 390);
            this.labelConfirm.Name = "labelConfirm";
            this.labelConfirm.Size = new System.Drawing.Size(123, 20);
            this.labelConfirm.TabIndex = 9;
            this.labelConfirm.Text = "Подтверждение:";

            // textBoxConfirimPassword
            this.textBoxConfirimPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxConfirimPassword.Location = new System.Drawing.Point(70, 415);
            this.textBoxConfirimPassword.Name = "textBoxConfirimPassword";
            this.textBoxConfirimPassword.Size = new System.Drawing.Size(360, 29);
            this.textBoxConfirimPassword.TabIndex = 10;
            this.textBoxConfirimPassword.Text = "пароль";
            this.textBoxConfirimPassword.ForeColor = System.Drawing.Color.Gray;
            this.textBoxConfirimPassword.UseSystemPasswordChar = false;
            this.textBoxConfirimPassword.Enter += new System.EventHandler(this.textBoxConfirimPassword_Enter);
            this.textBoxConfirimPassword.Leave += new System.EventHandler(this.textBoxConfirimPassword_Leave);

            // buttonRegistration
            this.buttonRegistration.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.buttonRegistration.FlatAppearance.BorderSize = 0;
            this.buttonRegistration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegistration.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.buttonRegistration.ForeColor = System.Drawing.Color.White;
            this.buttonRegistration.Location = new System.Drawing.Point(70, 480);
            this.buttonRegistration.Name = "buttonRegistration";
            this.buttonRegistration.Size = new System.Drawing.Size(360, 45);
            this.buttonRegistration.TabIndex = 11;
            this.buttonRegistration.Text = "Зарегистрироваться";
            this.buttonRegistration.UseVisualStyleBackColor = false;
            this.buttonRegistration.Click += new System.EventHandler(this.buttonRegistration_Click);

            // labelToGoLogin
            this.labelToGoLogin.AutoSize = true;
            this.labelToGoLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline);
            this.labelToGoLogin.ForeColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.labelToGoLogin.Location = new System.Drawing.Point(165, 555);
            this.labelToGoLogin.Name = "labelToGoLogin";
            this.labelToGoLogin.Size = new System.Drawing.Size(161, 19);
            this.labelToGoLogin.TabIndex = 12;
            this.labelToGoLogin.Text = "Есть аккаунт? Войти";
            this.labelToGoLogin.Click += new System.EventHandler(this.labelToGoLogin_Click);

            // RegistrForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 620);
            this.Controls.Add(this.labelToGoLogin);
            this.Controls.Add(this.buttonRegistration);
            this.Controls.Add(this.textBoxConfirimPassword);
            this.Controls.Add(this.labelConfirm);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.textBoxFIO);
            this.Controls.Add(this.labelFIO);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MaximizeBox = false;
            this.Name = "RegistrForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Регистрация нового пользователя";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelFIO;
        private System.Windows.Forms.TextBox textBoxFIO;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelConfirm;
        private System.Windows.Forms.TextBox textBoxConfirimPassword;
        private System.Windows.Forms.Button buttonRegistration;
        private System.Windows.Forms.Label labelToGoLogin;
    }
}
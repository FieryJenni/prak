namespace sklad
{
    partial class LoginForm
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
            this.labelLogin = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelCaptcha = new System.Windows.Forms.Label();
            this.txtCaptcha = new System.Windows.Forms.TextBox();
            this.lblCaptchaCode = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.labelToGoRegistration = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();

            // panelTop
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.panelTop.Controls.Add(this.labelTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(450, 90);
            this.panelTop.TabIndex = 0;

            // labelTitle
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(140, 25);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(193, 37);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Авторизация";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // labelLogin
            this.labelLogin.AutoSize = true;
            this.labelLogin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelLogin.Location = new System.Drawing.Point(70, 120);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(57, 21);
            this.labelLogin.TabIndex = 1;
            this.labelLogin.Text = "Логин:";

            // textBoxUserName
            this.textBoxUserName.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.textBoxUserName.Location = new System.Drawing.Point(70, 145);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(310, 32);
            this.textBoxUserName.TabIndex = 2;
            this.textBoxUserName.Text = "ivanov";
            this.textBoxUserName.ForeColor = System.Drawing.Color.Gray;
            this.textBoxUserName.Enter += new System.EventHandler(this.textBoxUserName_Enter);
            this.textBoxUserName.Leave += new System.EventHandler(this.textBoxUserName_Leave);

            // labelPassword
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelPassword.Location = new System.Drawing.Point(70, 190);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(66, 21);
            this.labelPassword.TabIndex = 3;
            this.labelPassword.Text = "Пароль:";

            // textBoxPassword
            this.textBoxPassword.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.textBoxPassword.Location = new System.Drawing.Point(70, 215);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(310, 32);
            this.textBoxPassword.TabIndex = 4;
            this.textBoxPassword.Text = "пароль";
            this.textBoxPassword.ForeColor = System.Drawing.Color.Gray;
            this.textBoxPassword.UseSystemPasswordChar = false;
            this.textBoxPassword.Enter += new System.EventHandler(this.textBoxPassword_Enter);
            this.textBoxPassword.Leave += new System.EventHandler(this.textBoxPassword_Leave);

            // labelCaptcha (надпись)
            this.labelCaptcha.AutoSize = true;
            this.labelCaptcha.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelCaptcha.Location = new System.Drawing.Point(70, 260);
            this.labelCaptcha.Name = "labelCaptcha";
            this.labelCaptcha.Size = new System.Drawing.Size(69, 21);
            this.labelCaptcha.TabIndex = 5;
            this.labelCaptcha.Text = "CAPTCHA:";

            // lblCaptchaCode (отображение кода)
            this.lblCaptchaCode.AutoSize = true;
            this.lblCaptchaCode.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblCaptchaCode.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblCaptchaCode.Location = new System.Drawing.Point(70, 285);
            this.lblCaptchaCode.Name = "lblCaptchaCode";
            this.lblCaptchaCode.Size = new System.Drawing.Size(120, 32);
            this.lblCaptchaCode.TabIndex = 6;
            this.lblCaptchaCode.Text = "XXXXX";

            // txtCaptcha (поле ввода капчи)
            this.txtCaptcha.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCaptcha.Location = new System.Drawing.Point(70, 325);
            this.txtCaptcha.Name = "txtCaptcha";
            this.txtCaptcha.Size = new System.Drawing.Size(200, 29);
            this.txtCaptcha.TabIndex = 7;
            this.txtCaptcha.Text = "";

            // buttonLogin
            this.buttonLogin.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.buttonLogin.FlatAppearance.BorderSize = 0;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.buttonLogin.ForeColor = System.Drawing.Color.White;
            this.buttonLogin.Location = new System.Drawing.Point(70, 380);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(310, 45);
            this.buttonLogin.TabIndex = 8;
            this.buttonLogin.Text = "Войти";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);

            // labelToGoRegistration
            this.labelToGoRegistration.AutoSize = true;
            this.labelToGoRegistration.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline);
            this.labelToGoRegistration.ForeColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.labelToGoRegistration.Location = new System.Drawing.Point(95, 445);
            this.labelToGoRegistration.Name = "labelToGoRegistration";
            this.labelToGoRegistration.Size = new System.Drawing.Size(229, 19);
            this.labelToGoRegistration.TabIndex = 9;
            this.labelToGoRegistration.Text = "Нет аккаунта? Зарегистрироваться";
            this.labelToGoRegistration.Click += new System.EventHandler(this.labelToGoRegistration_Click);

            // LoginForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(450, 520);
            this.Controls.Add(this.labelToGoRegistration);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.txtCaptcha);
            this.Controls.Add(this.lblCaptchaCode);
            this.Controls.Add(this.labelCaptcha);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вход в систему";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelCaptcha;
        private System.Windows.Forms.Label lblCaptchaCode;
        private System.Windows.Forms.TextBox txtCaptcha;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label labelToGoRegistration;
    }
}
using System;
using System.Drawing;
using System.Windows.Forms;

namespace sklad
{
    public partial class LoginForm : Form
    {
        private CaptchaService _captcha;
        private AuthService _authService;

        public LoginForm()
        {
            InitializeComponent();
            _captcha = new CaptchaService();
            _authService = new AuthService();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            GenerateNewCaptcha();
        }

        private void GenerateNewCaptcha()
        {
            lblCaptchaCode.Text = _captcha.Generate();
        }

        // Placeholder для логина
        private void textBoxUserName_Enter(object sender, EventArgs e)
        {
            if (textBoxUserName.Text == "ivanov")
            {
                textBoxUserName.Text = "";
                textBoxUserName.ForeColor = Color.Black;
            }
        }

        private void textBoxUserName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxUserName.Text))
            {
                textBoxUserName.Text = "ivanov";
                textBoxUserName.ForeColor = Color.Gray;
            }
        }

        // Placeholder для пароля
        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "пароль")
            {
                textBoxPassword.Text = "";
                textBoxPassword.ForeColor = Color.Black;
                textBoxPassword.UseSystemPasswordChar = true;
            }
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                textBoxPassword.UseSystemPasswordChar = false;
                textBoxPassword.Text = "пароль";
                textBoxPassword.ForeColor = Color.Gray;
            }
        }

        // Переход на форму регистрации
        private void labelToGoRegistration_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrForm registrForm = new RegistrForm();
            registrForm.Show();
        }

        // Авторизация
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string login = textBoxUserName.Text.Trim();
            string password = textBoxPassword.Text;
            string captchaInput = txtCaptcha.Text.Trim();

            // Проверка на пустые поля (учитывая подсказки)
            if (login == "ivanov" || string.IsNullOrEmpty(login))
            {
                MessageBox.Show("Введите логин.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (password == "пароль" || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(captchaInput))
            {
                MessageBox.Show("Введите код с картинки.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                User user = _authService.Login(login, password, captchaInput, _captcha);
                // Вход выполнен успешно
                MessageBox.Show($"Добро пожаловать, {user.Login}!\nВаша роль: {user.RoleName}",
                                "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Здесь нужно открыть главную форму приложения и передать в неё user
                // Вместо MessageBox и Hide()
                MainForm mainForm = new MainForm(user);
                mainForm.Show();
                this.Hide();
                // mainForm.FormClosed += (s, args) => this.Close();

            }
            catch (Exception ex)
            {
                // При ошибке генерируем новую CAPTCHA и очищаем поле ввода капчи
                GenerateNewCaptcha();
                txtCaptcha.Clear();
                MessageBox.Show(ex.Message, "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
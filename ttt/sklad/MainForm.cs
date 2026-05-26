using System;
using System.Windows.Forms;
using sklad.Models;

namespace sklad
{
    public partial class MainForm : Form
    {
        private User _currentUser;

        public MainForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
            // Настройка видимости пунктов меню в зависимости от роли
            ConfigureMenuByRole();
            // Отображение роли в статусной строке
            lblUserRole.Text = $"Вы вошли как: {_currentUser.Login} (роль: {_currentUser.RoleName})";
        }

        private void ConfigureMenuByRole()
        {
            // Администратору доступно всё
            if (_currentUser.RoleName == "admin")
            {
                adminMenuItem.Visible = true;
                productsMenuItem.Visible = true;
                suppliersMenuItem.Visible = true;
                suppliesMenuItem.Visible = true;
            }
            // Менеджеру (operator/manager) – только товары, поставщики, поставки, без администрирования
            else if (_currentUser.RoleName == "manager" || _currentUser.RoleName == "operator")
            {
                adminMenuItem.Visible = false;
                productsMenuItem.Visible = true;
                suppliersMenuItem.Visible = true;
                suppliesMenuItem.Visible = true;
            }
            // Обычному пользователю – только просмотр товаров (или ничего)
            else
            {
                adminMenuItem.Visible = false;
                productsMenuItem.Visible = true;   // можно только просмотр, но в форме товаров ограничим кнопки
                suppliersMenuItem.Visible = false;
                suppliesMenuItem.Visible = false;
            }
        }

        private void productsMenuItem_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm(_currentUser);
            productForm.ShowDialog();
        }

        private void suppliersMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Форма поставщиков в разработке");
        }

        private void suppliesMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Форма поставок в разработке");
        }

        private void usersMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Управление пользователями в разработке");
        }

        private void logsMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Журнал входов в разработке");
        }
    }
}
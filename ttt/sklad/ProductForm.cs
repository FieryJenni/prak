using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sklad.Models;
using sklad.Repositories;

namespace sklad
{
    public partial class ProductForm : Form
    {
        private ProductRepository _repo;
        private User _currentUser;
        private bool _isAdminOrManager;

        public ProductForm(User user)
        {
            InitializeComponent();
            _repo = new ProductRepository();
            _currentUser = user;
            // Определяем, может ли пользователь редактировать/добавлять/удалять
            _isAdminOrManager = user.RoleName == "admin" || user.RoleName == "manager" || user.RoleName == "operator";
            ConfigureButtonsByRole();
        }

        private void ConfigureButtonsByRole()
        {
            // Если роль не позволяет редактировать – отключаем кнопки добавления, изменения, удаления, экспорта
            if (!_isAdminOrManager)
            {
                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnExportCsv.Enabled = false;
            }
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts(string search = "")
        {
            var list = _repo.GetAll(search);
            dgvProducts.DataSource = null;
            dgvProducts.DataSource = list;
            // Настройка заголовков столбцов
            if (dgvProducts.Columns["Id"] != null)
                dgvProducts.Columns["Id"].HeaderText = "ID";
            if (dgvProducts.Columns["Name"] != null)
                dgvProducts.Columns["Name"].HeaderText = "Наименование";
            if (dgvProducts.Columns["Article"] != null)
                dgvProducts.Columns["Article"].HeaderText = "Артикул";
            if (dgvProducts.Columns["Price"] != null)
                dgvProducts.Columns["Price"].HeaderText = "Цена";
            if (dgvProducts.Columns["Quantity"] != null)
                dgvProducts.Columns["Quantity"].HeaderText = "Количество";
        }

        // Поиск
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim();
            if (search == "Поиск...") search = "";
            LoadProducts(search);
        }

        // Добавление
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var editForm = new ProductEditForm())
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadProducts(txtSearch.Text.Trim() == "Поиск..." ? "" : txtSearch.Text.Trim());
                }
            }
        }

        // Редактирование
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show("Выберите товар для редактирования.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Product selected = (Product)dgvProducts.CurrentRow.DataBoundItem;
            using (var editForm = new ProductEditForm(selected))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadProducts(txtSearch.Text.Trim() == "Поиск..." ? "" : txtSearch.Text.Trim());
                }
            }
        }

        // Удаление
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show("Выберите товар для удаления.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Product selected = (Product)dgvProducts.CurrentRow.DataBoundItem;
            if (MessageBox.Show($"Удалить товар \"{selected.Name}\"?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _repo.Delete(selected.Id);
                LoadProducts(txtSearch.Text.Trim() == "Поиск..." ? "" : txtSearch.Text.Trim());
            }
        }

        // Индивидуальная модификация: экспорт в CSV
        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            var products = _repo.GetAll(); // все товары, без фильтра
            if (products.Count == 0)
            {
                MessageBox.Show("Нет данных для экспорта.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV файлы (*.csv)|*.csv";
            sfd.DefaultExt = "csv";
            sfd.FileName = $"Товары_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    // Заголовки
                    sb.AppendLine("ID;Наименование;Артикул;Цена;Количество");
                    foreach (var p in products)
                    {
                        sb.AppendLine($"{p.Id};{EscapeCsv(p.Name)};{EscapeCsv(p.Article)};{p.Price};{p.Quantity}");
                    }
                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show($"Экспорт завершён. Файл сохранён: {sfd.FileName}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при экспорте: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string EscapeCsv(string value)
        {
            if (string.IsNullOrEmpty(value)) return "";
            // Если внутри есть точка с запятой или кавычки, оборачиваем в кавычки
            if (value.Contains(";") || value.Contains("\""))
                return "\"" + value.Replace("\"", "\"\"") + "\"";
            return value;
        }

        // Placeholder для поиска
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Поиск...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Поиск...";
                txtSearch.ForeColor = System.Drawing.Color.Gray;
            }
        }
    }
}
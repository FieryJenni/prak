using System;
using System.Windows.Forms;
using sklad.Models;
using sklad.Repositories;

namespace sklad
{
    public partial class ProductEditForm : Form
    {
        private Product _product;
        private bool _isEditMode;
        private ProductRepository _repo;

        public ProductEditForm(Product product = null)
        {
            InitializeComponent();
            _repo = new ProductRepository();
            if (product == null)
            {
                _isEditMode = false;
                _product = new Product();
            }
            else
            {
                _isEditMode = true;
                _product = product;
                LoadData();
            }
        }

        private void LoadData()
        {
            txtName.Text = _product.Name;
            txtArticle.Text = _product.Article;
            txtPrice.Text = _product.Price.ToString("0.00");
            txtQuantity.Text = _product.Quantity.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Валидация
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите наименование товара.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtArticle.Text))
            {
                MessageBox.Show("Введите артикул.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Некорректная цена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtQuantity.Text, out int quantity))
            {
                MessageBox.Show("Некорректное количество.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _product.Name = txtName.Text.Trim();
            _product.Article = txtArticle.Text.Trim();
            _product.Price = price;
            _product.Quantity = quantity;

            try
            {
                if (_isEditMode)
                    _repo.Update(_product);
                else
                    _repo.Add(_product);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
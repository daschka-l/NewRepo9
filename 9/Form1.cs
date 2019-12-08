using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Добавляем значение в Grid
        private void Button1_Click(object sender, EventArgs e)
        {
            
            Product newProduct = new Product();
            newProduct.name = textBox1.Text;
            newProduct.count = (int) numericUpDown1.Value;
            newProduct.price = numericUpDown2.Value;

            Date date = new Date();
            date.Day = dateTimePicker1.Value.Day;
            date.Month = dateTimePicker1.Value.Month;
            date.Year = dateTimePicker1.Value.Year;

            newProduct.date = date;


            if ((newProduct.price > 0) && (dataGridView1.Rows.Count < 10))
            {
                dataGridView1.Rows.Add(newProduct.name, newProduct.count, newProduct.price, newProduct.date.ToString());
            }
            else
            {
                MessageBox.Show("Склад переволнен");
            }

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // Рассчет средней стоимости товара
        private void Button2_Click(object sender, EventArgs e)
        {
            // Получаем список товаров из Grid
            Products products = this.getGridProducts();
         
            avg_result.Text = Convert.ToString(products.avg());
        }

        private Products getGridProducts()
        {
            // Создаем класс для хранения списка продуктов
            Products products = new Products();

            var i = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Создаем и заполняем структуру Продукт
                Product newProduct = new Product();
                newProduct.name = (string)row.Cells[0].Value;
                newProduct.count = Convert.ToInt32(row.Cells[1].Value);
                newProduct.price = Convert.ToDecimal(row.Cells[2].Value);


                var dateString = (string)row.Cells[3].Value;
                var dateItems = dateString.Split('.');
                // Создаем и заполняем структуру Дата из массива
                Date date = new Date();
                date.Day = Convert.ToInt32(dateItems[0]);
                date.Month = Convert.ToInt32(dateItems[1]);
                date.Year = Convert.ToInt32(dateItems[2]);

                newProduct.date = date;
                products[i] = newProduct;

                i++;

            }
            return products;
        }

        private void NumericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }
    }

}

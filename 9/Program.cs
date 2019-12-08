using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9
{
    struct Product
    {
        public string name;
        public int count;
        public decimal price;
        public Date date;
        public Product(string name, int count, decimal price, Date date)
        {
            this.name = name;
            this.count = count;
            this.price = price;
            this.date = date;
        }
    }
    struct Date
    {
        public int Day;
        public int Month;
        public int Year;
        public Date(int Day, int Month, int Year)
        {
            this.Day = Day;
            this.Month = Month;
            this.Year = Year;
        }

        public override string ToString()
        {

            return Convert.ToString(this.Day) + "." + Convert.ToString(this.Month) + "." + Convert.ToString(this.Year);
        }
    }
    class Products
    {
        Product[] products;
        public Products()
        {
            products = new Product[10];
        }
        public Product this[int index]
        {
            get
            {
                return products[index];
            }
            set
            {
                products[index] = value;
            }
        }
        public decimal avg()
        {
            int count = 0;
            decimal sum = 0;


            for (int i = 0; i< 10; i++)
            {
                Product item = products[i];
                
                if (item.price > 0)
                {
                    sum += item.price;
                    count++;
                }
            }

            decimal result = sum / count;
            return result;
        }

    }


    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

           
        }
    }
}

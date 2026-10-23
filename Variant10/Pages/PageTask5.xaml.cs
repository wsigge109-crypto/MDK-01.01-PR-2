using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Variant10.Pages
{
    public partial class PageTask5 : Page
    {
        int[,] data;   

        public PageTask5()
        {
            InitializeComponent();
        }
        //Сгенерировать массив из M столбцов и N строк, содержащий числа от -10 до 10. Отобразить его.
        //Отсортировать элементы по возрастанию и по убыванию (две таблицы). Найти максимальный и минимальный элементы.


        private DataView MakeTable(int[,] a)
        {
            DataTable table = new DataTable();
            for (int c = 0; c < a.GetLength(1); c++)
            {
                table.Columns.Add((c + 1).ToString(), typeof(int));
            }
            for (int r = 0; r < a.GetLength(0); r++)
            {
                DataRow row = table.NewRow();
                for (int c = 0; c < a.GetLength(1); c++)
                {
                    row[c] = a[r, c];
                }
                table.Rows.Add(row);
            }
            return table.DefaultView;
        }
        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            int m, n;
            if (!int.TryParse(txtM.Text, out m) || !int.TryParse(txtN.Text, out n)
                || m < 1 || m > 15 || n < 1 || n > 15)
            {
                MessageBox.Show("M и N должны быть числами от 1 до 15!");
                return;
            }
            Random rnd = new Random();
            data = new int[n, m];
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < m; c++)
                {
                    data[r, c] = rnd.Next(-10, 11);   // от -10 до 10
                }
            }
            dgSource.ItemsSource = MakeTable(data);
            dgAsc.ItemsSource = null;
            dgDesc.ItemsSource = null;
            txtResult.Text = "";
        }
        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (data == null)
            {
                MessageBox.Show("Сначала нажмите «Сгенерировать»!");
                return;
            }
            int n = data.GetLength(0);
            int m = data.GetLength(1);

            int[] flat = new int[n * m];
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < m; c++)
                {
                    flat[r * m + c] = data[r, c];
                }
            }

            Array.Sort(flat);

            int[,] asc = new int[n, m];
            int[,] desc = new int[n, m];
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < m; c++)
                {
                    asc[r, c] = flat[r * m + c];
                    desc[r, c] = flat[flat.Length - 1 - (r * m + c)];
                }
            }

            dgAsc.ItemsSource = MakeTable(asc);
            dgDesc.ItemsSource = MakeTable(desc);

            txtResult.Text = "Минимальный элемент: " + flat[0] + ",   максимальный элемент: " + flat[flat.Length - 1];
        }
    }
}

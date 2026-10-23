using System;
using System.Windows;
using System.Windows.Controls;

namespace Variant10.Pages
{
    public partial class PageTask3 : Page
    {
        public PageTask3()
        {
            InitializeComponent();
        }
        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            int n;
            if (!int.TryParse(txtN.Text, out n) || n < 10 || n > 100)
            {
                MessageBox.Show("N должно быть числом от 10 до 100!");
                return;
            }

            Random rnd = new Random();
            string text = "";
            for (int i = 0; i < n; i++)
            {
                text += rnd.Next(-20, 51) + " ";
            }
            txtArray.Text = text;

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            // Дан целочисленный массив A размера N (N не меньше 10). Вывести номер первого элемента A[i], для которого A[1] &lt; A[i] &lt; A[10].
            // Если таких элементов нет, вывести 0

            string[] parts = txtArray.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 10)
            {
                MessageBox.Show("В массиве должно быть не меньше 10 чисел!");
                return;
            }

            int[] a = new int[parts.Length];
            for (int i = 0; i < parts.Length; i++)
            {
                if (!int.TryParse(parts[i], out a[i]))
                {
                    MessageBox.Show("Массив должен состоять из целых чисел!");
                    return;
                }
            }
            int first = a[0];
            int tenth = a[9];
            int number = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > first && a[i] < tenth)
                {
                    number = i + 1;   
                    break;
                }
            }
            txtResult.Text = "A[1] = " + first + ", A[10] = " + tenth + "\nОтвет: " + number;
        }
    }
}

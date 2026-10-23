using System;
using System.Windows;
using System.Windows.Controls;

namespace Variant10.Pages
{
    public partial class PageTask4 : Page
    {
        public PageTask4()
        {
            InitializeComponent();
        }
        //Поменять местами первое простое и первое совершенное числа в массиве


        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            int n;
            if (!int.TryParse(txtN.Text, out n) || n < 2 || n > 100)
            {
                MessageBox.Show("N должно быть числом от 2 до 100!");
                return;
            }

            Random rnd = new Random();
            string text = "";
            for (int i = 0; i < n; i++)
            {
                text += rnd.Next(1, 51) + " ";
            }
            txtArray.Text = text;
        }

        
        private bool IsPrime(int n)
        {
            if (n < 2) return false;
            for (int d = 2; d < n; d++)
            {
                if (n % d == 0) return false;
            }
            return true;
        }

   
        private bool IsPerfect(int n)
        {
            int sum = 0;
            for (int d = 1; d < n; d++)
            {
                if (n % d == 0) sum += d;
            }
            return n > 1 && sum == n;
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            
            string[] parts = txtArray.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2)
            {
                MessageBox.Show("В массиве должно быть не меньше 2 чисел!");
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

            int primeIndex = -1;
            int perfectIndex = -1;
            for (int i = 0; i < a.Length; i++)
            {
                if (primeIndex == -1 && IsPrime(a[i])) primeIndex = i;
                if (perfectIndex == -1 && IsPerfect(a[i])) perfectIndex = i;
            }

            string result = "Исходный массив:\n" + string.Join(" ", a) + "\n\n";

            if (primeIndex == -1 || perfectIndex == -1)
            {
                result += "В массиве нет простого или совершенного числа, менять нечего.";
            }
            else
            {
                int temp = a[primeIndex];
                a[primeIndex] = a[perfectIndex];
                a[perfectIndex] = temp;

                result += "Простое: " + a[perfectIndex] + ", совершенное: " + a[primeIndex] + "\n\n";
                result += "После перестановки:\n" + string.Join(" ", a);
            }

            txtResult.Text = result;
        }
    }
}

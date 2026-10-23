using System.Windows;
using System.Windows.Controls;

namespace Variant10.Pages
{
    public partial class PageTask1 : Page
    {
        public PageTask1()
        {
            InitializeComponent();
        }
        //Дано число. Вывести цифры, которые повторяются в записи числа больше одного раза

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            string text = txtInput.Text.Trim().TrimStart('-');

            if (text == "")
            {
                MessageBox.Show("Введите число!");
                return;
            }
            foreach (char c in text)
            {
                if (!char.IsDigit(c))
                {
                    MessageBox.Show("Введите целое число (только цифры)!");
                    return;
                }
            }
            string result = "";
            for (char d = '0'; d <= '9'; d++)
            {
                int count = 0;
                foreach (char c in text)
                {
                    if (c == d) count++;
                }
                if (count > 1)
                {
                    result += "Цифра " + d + " повторяется " + count + " раз(а)\n";
                }
            }

            if (result == "") result = "Повторяющихся цифр нет";
            txtResult.Text = result;
        }
    }
}

using System;
using System.Windows;
using System.Windows.Controls;

namespace Variant10.Pages
{
    public partial class PageTask2 : Page
    {
        public PageTask2()
        {
            InitializeComponent();
        }
        
        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            char[] separators = { ' ', ',', '.', '!', '?', ';', ':', '"', '(', ')' };
            string[] words = txtInput.Text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            if (words.Length == 0)
            {
                MessageBox.Show("Введите предложение!");
                return;
            }
            string longest = words[0];
            foreach (string word in words)
            {
                if (word.Length > longest.Length)
                {
                    longest = word;
                }
            }

            txtResult.Text = "Самое длинное слово: " + longest + "\nДлина: " + longest.Length;
        }
    }
}

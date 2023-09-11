using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string currentNumber = "";
        string previousNumber = "";
        char operation;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void BtnNumber_Click(object sender, RoutedEventArgs e)
        {
            if (currentNumber == "0")
                currentNumber = "";

            currentNumber += (sender as Button).Content;
            txtCurrent.Text = currentNumber;
        }

        private void BtnDecimal_Click(object sender, RoutedEventArgs e)
        {
            if (!currentNumber.Contains("."))
            {
                currentNumber += ".";
                txtCurrent.Text = currentNumber;
            }
        }

        private void BtnOperator_Click(object sender, RoutedEventArgs e)
        {
            previousNumber = currentNumber;
            operation = (sender as Button).Content.ToString()[0];
            currentNumber = "";
            txtPrevious.Text = previousNumber + " " + operation;
        }

        private void BtnEqual_Click(object sender, RoutedEventArgs e)
        {
            double result = Calculate();
            txtCurrent.Text = result.ToString();
            previousNumber = "";
            operation = ' ';
        }

        private void BtnCE_Click(object sender, RoutedEventArgs e)
        {
            currentNumber = "";
            txtCurrent.Text = "0";
        }

        private void BtnC_Click(object sender, RoutedEventArgs e)
        {
            currentNumber = "";
            previousNumber = "";
            txtCurrent.Text = "0";
            txtPrevious.Text = "";
        }

        private void BtnBackspace_Click(object sender, RoutedEventArgs e)
        {
            if (currentNumber.Length > 0)
            {
                currentNumber = currentNumber.Substring(0, currentNumber.Length - 1);
                if (currentNumber == "")
                    currentNumber = "0";
                txtCurrent.Text = currentNumber;
            }
        }

        private double Calculate()
        {
            double x = double.Parse(previousNumber);
            double y = double.Parse(currentNumber);
            switch (operation)
            {
                case '+':
                    return x + y;
                case '-':
                    return x - y;
                case '*':
                    return x * y;
                case '/':
                    return x / y;
            }
            return 0;
        }
    }
}


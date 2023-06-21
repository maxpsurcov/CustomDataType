using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPkursova7489
{
    public partial class Form1 : Form
    {
        private CustomNumber customNum;
        private ErrorProvider errorProvider;
        public Form1()
        {
            InitializeComponent();

            customNum = new CustomNumber("");
            errorProvider = new ErrorProvider();
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            string newValue = ValueTextBox.Text;

            if (IsValidInput(newValue))
            {
                if (IsValidNumber(newValue))
                {
                    customNum.SetValue(newValue);
                    customNum.PrintValue();
                    errorProvider.Clear();
                }
                else
                {
                    errorProvider.SetError(ValueTextBox, "Некоректне число. Введіть ціле число в діапазоні від 1 до 100000000.");
                }
            }
            else
            {
                errorProvider.SetError(ValueTextBox, "Некоректний ввід. Введіть тільки цифри зі знаком '+' або '-'.");
            }
        }
        private bool IsValidInput(string value)
        {
            foreach (char c in value)
            {
                if (!char.IsDigit(c) && c != '+' && c != '-')
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsValidNumber(string value)
        {
            bool isValid = false;

            if (int.TryParse(value, out int number))
            {
                if (Math.Abs(number) >= 1 && Math.Abs(number) <= 100000000)
                {
                    isValid = true;
                }
            }

            return isValid;
        }
    }
    public class CustomNumber
    {
        private List<char> value;

        public CustomNumber(string number)
        {
            value = new List<char>(number);
        }

        public CustomNumber(CustomNumber other)
        {
            value = new List<char>(other.value);
        }

        public void SetValue(string number)
        {
            value = new List<char>(number);
        }

        public string GetValue()
        {
            return new string(value.ToArray());
        }

        public void PrintValue()
        {
            MessageBox.Show(new string(value.ToArray()), "Custom Number");
        }

        public void ChangePart(string newValue)
        {
            if (IsValidInput(newValue))
            {
                value = new List<char>(newValue);
            }
            else
            {
                MessageBox.Show("Некоректний ввід. Введіть тільки цифри зі знаком '+' або '-'.", "Помилка");
            }
        }

        public void DisplayContent()
        {
            MessageBox.Show(new string(value.ToArray()), "Custom Number");
        }

        public void Increment()
        {
            int number;
            if (int.TryParse(new string(value.ToArray()), out number))
            {
                number++;
                value = new List<char>(number.ToString());
            }
        }

        public void Decrement()
        {
            int number;
            if (int.TryParse(new string(value.ToArray()), out number))
            {
                number--;
                value = new List<char>(number.ToString());
            }
        }

        public void Negate()
        {
            int number;
            if (int.TryParse(new string(value.ToArray()), out number))
            {
                number = -number;
                value = new List<char>(number.ToString());
            }
        }

        private bool IsValidInput(string value)
        {
            foreach (char c in value)
            {
                if (!char.IsDigit(c) && c != '+' && c != '-')
                {
                    return false;
                }
            }

            return true;
        }
    }
}

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
using System.IO;

namespace Caesar_Cipher
{
    public partial class Interface : Page
    {
        public Interface()
        {
            InitializeComponent();
        }

        private void Return(object sender, RoutedEventArgs e)
        {
            Cipher.Encrypt(text.Text, 0);
            NavigationService.GoBack();
        }

        private void PreviewStepInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !StepIsValid(((TextBox)sender).Text + e.Text);
        }
        private static bool StepIsValid(string str)
        {
            return byte.TryParse(str, out byte i) && i >= 0 && i <= 32 && str != "00";
        }
        private void StepChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(step.Text))
            {
                DisplayLetter(byte.Parse(step.Text));
                text.Text = Cipher.Encrypt(text.Text, byte.Parse(step.Text));
            }
        }

        private void DisplayLetter(byte step)
        {
            letter.Text = Cipher.russianAlphabet[step].ToString();
        }
        private void MinusStep(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(step.Text))
            {
                step.Text = "0";
            }
            else
            {
                if (step.Text == "0" || step.Text == "00")
                {
                    step.Text = "32";
                }
                else
                {
                    step.Text = (byte.Parse(step.Text) - 1).ToString();
                }
            }
        }
        private void PlusStep(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(step.Text))
            {
                step.Text = "0";
            }
            else
            {
                if (step.Text == "32")
                {
                    step.Text = "0";
                }
                else
                {
                    step.Text = (byte.Parse(step.Text) + 1).ToString();
                }
            }
        }
        private void TryHack(object sender, RoutedEventArgs e)
        {
            step.Text = Cipher.GuessStep(text.Text).ToString();
        }
        private void UploadText(object sender, RoutedEventArgs e)
        {
            string newText = FileManagement.Upload();
            if (!String.IsNullOrEmpty(newText))
            {
                text.Text = newText;
            }
        }
        private void SaveText(object sender, RoutedEventArgs e)
        {
            FileManagement.Save(text.Text);
        }

        bool hasBeenClicked = false;

        private void TextBox_Focus(object sender, RoutedEventArgs e)
        {
            if (!hasBeenClicked)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked = true;
            }
        }
    }
}

using Rationals;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    /// <summary>
    ///     Ctor.
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();
        TextBoxLeftSideTop.TextChanged += Calculate;
        TextBoxLeftSideBot.TextChanged += Calculate;
        TextBoxRightSideTop.TextChanged += Calculate;
        TextBoxRightSideBot.TextChanged += Calculate;
        RadioButtonPlus.Checked += Calculate;
        RadioButtonDivision.Checked += Calculate;
        RadioButtonMinus.Checked += Calculate;
        RadioButtonMultiplication.Checked += Calculate;
    }

    private static bool Validate(TextBox box, out int value, bool isBot = false)
    {
        if (!int.TryParse(box.Text.Trim(), out value) || isBot && value is 0)
        {
            box.Background = Brushes.Red;
            return false;
        }

        box.Background = Brushes.White;
        return true;
    }

    private void Calculate(object sender, EventArgs e)
    {
        if (!(Validate(TextBoxLeftSideTop, out var lTop) &&
              Validate(TextBoxLeftSideBot, out var lBot, true) &&
              Validate(TextBoxRightSideTop, out var rTop) &&
              Validate(TextBoxRightSideBot, out var rBot, true)))
            return;

        Rational left = new(lTop, lBot);
        Rational right = new(rTop, rBot);

        if (RadioButtonDivision.IsChecked == true)
        {
            if (!(Validate(TextBoxLeftSideTop, out lTop, true) &&
                  Validate(TextBoxRightSideTop, out rTop, true)))
                return;
            LabelResult.Content = left / right;
        }
        else if (RadioButtonMinus.IsChecked is true)
            LabelResult.Content = left - right;
        else if (RadioButtonMultiplication.IsChecked is true)
            LabelResult.Content = left * right;
        else
            LabelResult.Content = left + right;
    }
}
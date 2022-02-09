using Rationals;
using System;
using System.Numerics;
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
        if ((!int.TryParse(box.Text.Trim(), out value)) || (isBot && value is 0))
        {
            box.Background = Brushes.Red;
            return false;
        }
        box.Background = Brushes.White;
        return true;
    }

    private void Calculate(object sender, EventArgs e)
    {
        if (!(Validate(TextBoxLeftSideTop, out int lTop) &&
            Validate(TextBoxLeftSideBot, out int lBot, true) &&
            Validate(TextBoxRightSideTop, out int rTop) &&
            Validate(TextBoxRightSideBot, out int rBot, true)))
        {
            return;
        }

        Rational left = new(
            new BigInteger(lTop),
            new BigInteger(lBot)
        );
        Rational right = new(
            new BigInteger(rTop),
            new BigInteger(rBot)
        );

        if (RadioButtonDivision.IsChecked is true)
            LabelResult.Content = left / right;
        else if (RadioButtonMinus.IsChecked is true)
            LabelResult.Content = left - right;
        else if (RadioButtonMultiplication.IsChecked is true)
            LabelResult.Content = left * right;
        else
            LabelResult.Content = left + right;
    }
}
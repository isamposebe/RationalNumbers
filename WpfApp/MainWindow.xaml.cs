using Rationals;
using System;
using System.Numerics;
using System.Windows;

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

    private void Calculate(object sender, EventArgs e)
    {
        var lTop = 1;
        var lBot = 1;
        var rTop = 1;
        var rBot = 1;

        if (!(int.TryParse(TextBoxLeftSideTop.Text.Trim(), out lTop) ||
            int.TryParse(TextBoxLeftSideBot.Text.Trim(), out lBot) ||
            int.TryParse(TextBoxRightSideTop.Text.Trim(), out rTop) ||
            int.TryParse(TextBoxRightSideBot.Text.Trim(), out rBot)))
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

        if (RadioButtonDivision.IsChecked == true)
            LabelResult.Content = left / right;
        else if (RadioButtonMinus.IsChecked == true)
            LabelResult.Content = left - right;
        else if (RadioButtonMultiplication.IsChecked == true)
            LabelResult.Content = left * right;
        else
            LabelResult.Content = left + right;
    }
}
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
    public int num = 0;
    public Rational Rational_rez = new Rational(0);
    
    /// <summary>
    ///     Ctor.
    /// </summary>
    public MainWindow()
    {
        
        InitializeComponent();
        test_dataTB.Clear();
        test_dataTB.TextChanged += Calculate;

        ButtonDivision.Click += ButtonDivision_Click; 
        ButtonPlus.Click += ButtonPlus_Click;
        ButtonMinus.Click += ButtonMinus_Click;
        ButtonMultiplication.Click += ButtonMultiplication_Click;
        ButtonRez.Click += ButtonRez_Click; 

        
    }

    private void ButtonRez_Click(object sender, RoutedEventArgs e)
    {

        var buf = Rational_rez.AsDouble();

        test_rez.Text = buf.ToString();
        Rational_rez = new Rational(0);
    }

    private void ButtonMultiplication_Click(object sender, RoutedEventArgs e)
    {
        num = int.Parse(test_dataTB.Text);
        test_dataTB.Clear();
        Rational rational = new Rational(num);
        Rational_rez = Rational_rez * rational;
    }

    private void ButtonDivision_Click(object sender, RoutedEventArgs e)
    {
        num = int.Parse(test_dataTB.Text);
        test_dataTB.Clear();
        Rational rational = new Rational(num);
        Rational_rez = Rational_rez / rational;
    }

    private void ButtonMinus_Click(object sender, RoutedEventArgs e)
    {
        num = int.Parse(test_dataTB.Text);
        test_dataTB.Clear();
        Rational rational = new Rational(num);
        Rational_rez = Rational_rez - rational;
    }

    private void ButtonPlus_Click(object sender, RoutedEventArgs e)
    {
        
        num = int.Parse(test_dataTB.Text);
        test_dataTB.Clear();
        Rational rational = new Rational(num);
        Rational_rez = Rational_rez + rational;
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
    private void Buf(object sender, EventArgs e)
    {
        int num = int.Parse(test_dataTB.Text);
        test_dataTB.Clear();



    }
    private void Calculate(object sender, EventArgs e)
    {
        if (!(Validate(test_dataTB, out var lTop, true)))
            return;
        



        //Rational left = new(lTop, lBot);
        //Rational right = new(rTop, rBot);

        //if (RadioButtonDivision.IsChecked == true)
        //{
        //    if (!(Validate(TextBoxLeftSideTop, out lTop, true) &&
        //          Validate(TextBoxRightSideTop, out rTop, true)))
        //        return;
        //    LabelResult.Content = left / right;
        //}
        //else if (RadioButtonMinus.IsChecked is true)
        //    LabelResult.Content = left - right;
        //else if (RadioButtonMultiplication.IsChecked is true)
        //    LabelResult.Content = left * right;
        //else
        //    LabelResult.Content = left + right;
    }
}
using System;
using System.Globalization;
using System.Windows;
using Rationals;

namespace WpfApp;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    /// <summary>
    ///     Ctor.
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();
        ButtonPlus.Click += ButtonPlus_Click;
        ButtonDivision.Click += ButtonDivision_Click;
        ButtonMinus.Click += ButtonMinus_Click;
        ButtonMultiplication.Click += ButtonMultiplication_Click;
    }

    private void ButtonMultiplication_Click(object sender, RoutedEventArgs e)
    {
        UpData(out var rationalOne, out var rationalTwo);
        LoadData(rationalOne * rationalTwo);
    }

    private void ButtonMinus_Click(object sender, RoutedEventArgs e)
    {
        UpData(out var rationalOne, out var rationalTwo);
        var rational = rationalOne - rationalTwo;
        LoadData(rational);
    }

    private void ButtonDivision_Click(object sender, RoutedEventArgs e)
    {
        UpData(out var rationalOne, out var rationalTwo);
        Rational rational = new();
        Rational check = new("0/1");

        if (rationalTwo == check)
        {
            rational = AssemblyNumber("0", "0", "0");
        }
        else
        {
            rational = AssemblyNumber("0", rationalOne.ToString(), rationalTwo.ToString());
        }

        LoadData(rational);
    }

    private void ButtonPlus_Click(object sender, RoutedEventArgs e)
    {
        UpData(out var rationalOne, out var rationalTwo);
        var rational = rationalOne + rationalTwo;
        LoadData(rational);
    }

    /// <summary>
    ///     Отображение данных на форме
    /// </summary>
    /// <param name="rational">Результат который нужно отобразить</param>
    private void LoadData(Rational rational)
    {
        TextBoxOrd.Text = rational.AsDouble().ToString(CultureInfo.InvariantCulture);
        TextBoxDecimalsForm.Text = rational.ToString();
    }

    /// <summary>
    ///     Запись в переменные
    ///     <param name="rationalOne" />
    ///     и
    ///     <param name="rationalTwo" />
    ///     Получая переменные заполняются из формы
    /// </summary>
    /// <param name="rationalOne">Первое число</param>
    /// <param name="rationalTwo">Второе число</param>
    /// <exception cref="NotImplementedException"></exception>
    private void UpData(out Rational rationalOne, out Rational rationalTwo)
    {
        // Ввод данных из TexBox в переменные
        rationalOne = AssemblyNumber(TextBoxInputInteger1.Text, TextBoxInputNumerator1.Text,
            TextBoxInputDenominator1.Text);

        rationalTwo = AssemblyNumber(TextBoxInputInteger2.Text, TextBoxInputNumerator2.Text,
            TextBoxInputDenominator2.Text);
    }

    /// <summary>
    ///     Сборка рационального числа из целой части, числителя дроби и знаменателя.
    /// </summary>
    /// <param name="integerPart">Целая часть дроби.</param>
    /// <param name="numerator">Числитель дроби.</param>
    /// <param name="denominator">Знаменатель дроби.</param>
    /// <returns>Рациональное число.</returns>
    private static Rational AssemblyNumber(string integerPart, string numerator, string denominator)
    {
        Rational integer = new();
        Rational fractional = new();
        try
        {
            integer = new(integerPart);
            fractional = new(numerator + '/' + denominator);
        }
        catch (Exception Eorr)
        {

            MessageBox.Show(Eorr.Message.ToString());
            fractional = new("0/1");
            
        }


        return integer + fractional;
    }
}
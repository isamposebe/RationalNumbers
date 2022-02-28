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
        var rational = rationalOne / rationalTwo;
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
        rationalOne = AssemblyNumber(ParseInt(TextBoxInputInteger1.Text),
            ParseInt(TextBoxInputNumerator1.Text),
            ParseDenominator(TextBoxInputDenominator1.Text));

        rationalTwo = AssemblyNumber(ParseInt(TextBoxInputInteger2.Text),
            ParseInt(TextBoxInputNumerator2.Text),
            ParseDenominator(TextBoxInputDenominator2.Text));
    }

    /// <summary>
    ///     Читаем и проверяем
    /// </summary>
    /// <param name="str">Число в виде строки</param>
    /// <returns>число в int</returns>
    private static int ParseInt(string str)
    {
        return int.Parse(str);
    }

    /// <summary>
    ///     Чтение и проверка знаменателя на "правильные" данные.
    /// </summary>
    /// <param name="str">Число в виде строки.</param>
    /// <exception cref="DivideByZeroException">Деление на ноль.</exception>
    /// <returns>Integer number.</returns>
    private static int ParseDenominator(string str)
    {
        if (str == "0")
            throw new DivideByZeroException("Деление на ноль");
        return int.Parse(str);
    }

    /// <summary>
    ///     Сборка рационального числа из целой части, числителя дроби и знаменателя.
    /// </summary>
    /// <param name="integerPart">Целая часть дроби.</param>
    /// <param name="numerator">Числитель дроби.</param>
    /// <param name="denominator">Знаменатель дроби.</param>
    /// <returns>Рациональное число.</returns>
    private static Rational AssemblyNumber(int integerPart, int numerator, int denominator)
    {
        Rational integer = new(integerPart);
        Rational fractional = new(numerator, denominator);
        return integer + fractional;
    }
}
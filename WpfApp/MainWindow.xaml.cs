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
        ButtonPlus.Click += ButtonPlus_Click;
        ButtonDivision.Click += ButtonDivision_Click;
        ButtonMinus.Click += ButtonMinus_Click;
        ButtonMultiplication.Click += ButtonMultiplication_Click;
    }

    private void ButtonMultiplication_Click(object sender, RoutedEventArgs e)
    {
        UpData(out var rationalOne, out var rationalTwo);
        loadData(rationalOne * rationalTwo);
    }

    private void ButtonMinus_Click(object sender, RoutedEventArgs e)
    {
        Rational rationalOne = new Rational();
        Rational rationalTwo = new Rational();
        UpData(out rationalOne, out rationalTwo);

        Rational rational = rationalOne - rationalTwo;
        loadData(rational);
    }

    private void ButtonDivision_Click(object sender, RoutedEventArgs e)
    {
        Rational rationalOne = new Rational();
        Rational rationalTwo = new Rational();
        UpData(out rationalOne, out rationalTwo);

        Rational rational = rationalOne / rationalTwo;
        loadData(rational);
    }

    private void ButtonPlus_Click(object sender, RoutedEventArgs e)
    {
        Rational rationalOne = new Rational();
        Rational rationalTwo = new Rational();
        UpData(out rationalOne, out rationalTwo);

        Rational rational = rationalOne + rationalTwo;
        loadData(rational);
    }

    /// <summary>
    ///     Отображение данных на форме
    /// </summary>
    /// <param name="rational">Результат который нужно отобразить</param>
    private void loadData(Rational rational)
    {
        TextBoxOrd.Text = rational.AsDouble().ToString();
        TextBoxDecimalsForm.Text = rational.ToString();
    }

    /// <summary>
    ///     Запись в переменые <param name="rationalOne"> и <param name="rationalTwo">
    ///     Получая переменые заполняются из формы
    /// </summary>
    /// <param name="rationalOne">Первое число</param>
    /// <param name="rationalTwo">Второе число</param>
    /// <exception cref="NotImplementedException"></exception>
    private static void UpData(out Rational rationalOne, out Rational rationalTwo)
    {
        // 3 try/catch

        // Ввод данных из TexBox в переменые
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
    /// <param name="str">Число ввиде строки</param>
    /// <returns>число в int</returns>
    private static int ParseInt(string str)
    {
        return int.Parse(str);
    }

    /// <summary>
    ///     Чтение и проверка знаменателя на валидные данные.
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
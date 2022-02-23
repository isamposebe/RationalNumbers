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
        ButtonPlus.Click += ButtonPlus_Click;
        ButtonDivision.Click += ButtonDivision_Click;
        ButtonMinus.Click += ButtonMinus_Click;
        ButtonMultiplication.Click += ButtonMultiplication_Click;


    }

    private void ButtonMultiplication_Click(object sender, RoutedEventArgs e)
    {
        Rational rationalOne = new Rational();
        Rational rationalTwo = new Rational();
        UpData(out rationalOne, out rationalTwo);

        Rational rational = rationalOne * rationalTwo;
        loadData(rational);

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
    /// Отображение данных на форме
    /// </summary>
    /// <param name="rational"> Результат который нужно отобразить</param>
    private void loadData(Rational rational)
    {
        TextBoxOrd.Text = rational.AsDouble().ToString();
        TextBoxDecimalsForm.Text = rational.ToString();
    }

    /// <summary>
    /// Запись в переменые <param name="rationalOne"> и <param name="rationalTwo">
    /// Получая переменые заполняются из формы
    /// </summary>
    /// <param name="rationalOne">Первое число</param>
    /// <param name="rationalTwo">Второе число</param>
    /// <exception cref="NotImplementedException"></exception>
    private void UpData(out Rational rationalOne, out Rational rationalTwo)
    {
        //Ввод данных из TexBox в переменые
        rationalOne = AssemblyNumber(ConvertStrIsInt(TextBoxInputInteger1.Text), ConvertStrIsInt(TextBoxInputNumerator1.Text), ConvertStrIsIntDenominator(TextBoxInputDenominator1.Text));
        rationalTwo = AssemblyNumber(ConvertStrIsIntDenominator(TextBoxInputInteger2.Text), ConvertStrIsIntDenominator(TextBoxInputNumerator2.Text), ConvertStrIsIntDenominator(TextBoxInputDenominator2.Text));
    }

    /// <summary>
    /// Преобразую из стоки в число
    /// Еслои пустая строка то вывожу "0"
    /// </summary>
    /// <param name="str">Число ввиде строки</param>
    /// <returns>число в int</returns>
    private int ConvertStrIsInt(string str)
    {
        int num = 0;
        if (str != "")
        {
            num = Convert.ToInt32(str);
        }
        return num;
    }

    /// <summary>
    /// Преобразую из стоки в число
    /// Еслои пустая строка то вывожу "0"
    /// + Проверка Denominator
    /// </summary>
    /// <param name="str">Число ввиде строки</param>
    /// <returns>число в int</returns>
    private int ConvertStrIsIntDenominator(string str)
    {
        int num = 0;
        if (str != "")
        {
            num = Convert.ToInt32(str);
        }
        if (str == "0")
        {
            MessageBox.Show("Деление на ноль");
            return 1;
        }
        return num;
    }

    /// <summary>
    /// Сборка рационального числа из числителя дроби, знаменателя и целого числителями
    /// </summary>
    /// <param name="InputInteger">целый числитель</param>
    /// <param name="InputNumerator">числитель дроби</param>
    /// <param name="InputDenominator">знаменатель</param>
    /// <returns>Рациональное число</returns>
    private static Rational AssemblyNumber(int InputInteger, int InputNumerator, int InputDenominator)
    {
        Rational rational = new Rational();
        Rational Integer1 = new Rational(InputInteger);
        Rational Fractional = new Rational(InputNumerator, InputDenominator);
        rational = Integer1 + Fractional;
        return rational;
    }



}
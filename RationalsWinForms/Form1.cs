using System;
using System.Windows.Forms;
using Rationals;

namespace RationalsWinForms;

public partial class Rationals : Form
{
    private static Operation state = Operation.Plus;

    public Rationals()
    {
        InitializeComponent();
    }

    private void evaluate_Click(object sender, EventArgs e)
    {
        var inputFirst = firstRational.Text.Split('/');
        var inputSecond = secondRational.Text.Split('/');

        var first = new string[2];
        var second = new string[2];

        if (inputFirst.Length == 1)
        {
            first[0] = inputFirst[0];
            first[1] = "1";
        }
        else
        {
            first[0] = inputFirst[0];
            first[1] = inputFirst[1];
        }

        if (inputSecond.Length == 1)
        {
            second[0] = inputSecond[0];
            second[1] = "1";
        }
        else
        {
            second[0] = inputSecond[0];
            second[1] = inputSecond[1];
        }

        switch (state)
        {
            case Operation.Plus:
                result.Text = (new Rational(int.Parse(first[0]), int.Parse(first[1])) +
                               new Rational(int.Parse(second[0]), int.Parse(second[1]))).ToString();
                break;
            case Operation.Minus:
                result.Text = (new Rational(int.Parse(first[0]), int.Parse(first[1])) -
                               new Rational(int.Parse(second[0]), int.Parse(second[1]))).ToString();
                break;
            case Operation.Multiply:
                result.Text = (new Rational(int.Parse(first[0]), int.Parse(first[1])) *
                               new Rational(int.Parse(second[0]), int.Parse(second[1]))).ToString();
                break;
            case Operation.Divide:
                result.Text = (new Rational(int.Parse(first[0]), int.Parse(first[1])) /
                               new Rational(int.Parse(second[0]), int.Parse(second[1]))).ToString();
                break;
        }
    }

    private void firstRational_TextChanged(object sender, EventArgs e)
    {
    }

    private void secondRational_TextChanged(object sender, EventArgs e)
    {
    }

    private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
    {
    }

    private void plus_CheckedChanged(object sender, EventArgs e)
    {
        state = Operation.Plus;
    }

    private void minus_CheckedChanged(object sender, EventArgs e)
    {
        state = Operation.Minus;
    }

    private void multiply_CheckedChanged(object sender, EventArgs e)
    {
        state = Operation.Multiply;
    }

    private void divide_CheckedChanged(object sender, EventArgs e)
    {
        state = Operation.Divide;
    }

    private enum Operation
    {
        Plus,
        Minus,
        Multiply,
        Divide
    }
}
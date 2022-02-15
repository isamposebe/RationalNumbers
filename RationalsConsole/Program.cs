using Rationals;

Rational[] rationals = { new(0.75), new(0.51851, Math.Pow(10, 5)), new(0.9054054),
    new(0.142857143), new(Math.PI),
    new(2.718281828), new(-0.423310825), new(Math.PI*10), new(2.0/3) };

foreach (var r in rationals)
{
    Console.WriteLine($"{r.AsDouble()} is {r}");
}

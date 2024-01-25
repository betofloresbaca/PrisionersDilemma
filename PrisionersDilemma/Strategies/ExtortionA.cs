namespace PrisionersDilemma.Strategies;

internal class ExtortionA : Probabilistic
{
    public ExtortionA()
        : base(
            new Dictionary<(bool, bool), double>()
            {
                { (true, true), 8.0 / 9.0 },
                { (true, false), 2.0 / 9.0 },
                { (false, true), 11.0 / 18.0 },
                { (false, false), 0.0 },
            }
        ) { }
}

namespace PrisionersDilemma.Strategies;

internal class ExtortionF : Probabilistic
{
    public ExtortionF()
        : base(
            new Dictionary<(bool, bool), double>()
            {
                { (true, true), 11.0 / 15.0 },
                { (true, false), 2.0 / 15.0 },
                { (false, true), 7.0 / 15.0 },
                { (false, false), 0.0 },
            }
        ) { }
}

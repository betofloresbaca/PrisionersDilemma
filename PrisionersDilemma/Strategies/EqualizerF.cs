namespace PrisionersDilemma.Strategies;

internal class EqualizerF : Probabilistic
{
    public EqualizerF()
        : base(
            new Dictionary<(bool, bool), double>()
            {
                { (true, true), 1.0 },
                { (true, false), 13.0 / 15.0 },
                { (false, true), 1.0 / 5.0 },
                { (false, false), 2.0 / 5.0 },
            }
        ) { }
}

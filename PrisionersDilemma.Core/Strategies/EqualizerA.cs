namespace PrisionersDilemma.Core.Strategies;

internal class EqualizerA : Probabilistic
{
    public EqualizerA()
        : base(
            new Dictionary<(bool, bool), double>()
            {
                { (true, true), 3.0 / 4.0 },
                { (true, false), 1.0 / 4.0 },
                { (false, true), 1.0 / 2.0 },
                { (false, false), 1.0 / 4.0 },
            }
        ) { }
}



public enum VitalName
{
    Health,
    Energy,
    Mana
}

public class Vital : ModifiedStat
{
    private int currentValue;

    public Vital()
    {
        CurrentValue = 0;
        ExpToLevel = 50;
        LevelModifier = 1.1f;
    }

    public int CurrentValue
    {
        get
        {
            if (currentValue > AdjustedBaseValue)
            {
                currentValue = AdjustedBaseValue;
            }

            return currentValue;
        }
        set
        {
            currentValue = value;
        }
    }
}

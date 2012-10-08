
public class BaseStat
{
    public BaseStat()
    {
        //baseValue = 0;
        //buffValue = 0;
        //levelModifier = 1.10f;
        //expToLevel = 100;

        BaseValue = 0;
        BuffValue = 0;
        LevelModifier = 1.10f;
        ExpToLevel = 100;
    }

    /// <summary>
    /// the base value of this stat
    /// </summary>
    public int BaseValue
    {
        get;
        set;
    }
    //private int baseValue;

    /// <summary>
    /// the amount of the buff to this stat
    /// </summary>
    public int BuffValue
    {
        get;
        set;
    }
    //private int buffValue;

    /// <summary>
    /// the modifier applied to the epc needed to raise the skill
    /// </summary>
    public float LevelModifier
    {
        get;
        set;
    }
    //private float levelModifier;

    /// <summary>
    /// the total amount of exp nedded to raise this skill
    /// </summary>
    public int ExpToLevel
    {
        get;
        set;
    }
    //private int expToLevel;

    private int CalculateExpToLevel()
    {
        return (int)(ExpToLevel * LevelModifier);
    }

    public void LevelUp()
    {
        ExpToLevel = CalculateExpToLevel();
        BaseValue++;
    }

    public int AdjustedBaseValue
    {
        get
        {
            return BaseValue + BuffValue;
        }
    }
}

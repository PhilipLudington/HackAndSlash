
public enum AttributeName
{
    Might,
    Constitution,
    Nimbleness,
    Speed,
    Concentration,
    Willpower,
    Charisma
}

public class Attribute : BaseStat
{
    public Attribute()
    {
        ExpToLevel = 50;
        LevelModifier = 1.05f;
    }
}

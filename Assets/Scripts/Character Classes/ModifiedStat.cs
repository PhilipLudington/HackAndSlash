using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ModifiedStat : BaseStat
{
    // a List of Attributes that modify this stat
    private List<ModifyingAttribute> mods;
    // The amount added to the baseValue
    private int modValue;

    public ModifiedStat()
    {
        mods = new List<ModifyingAttribute>();
        modValue = 0;
    }

    public void AddModifier(ModifyingAttribute mod)
    {
        mods.Add(mod);
    }

    private void CalculateModValue()
    {
        modValue = 0;

        if (mods.Count > 0)
        {
            foreach (ModifyingAttribute modifyingAttribute in mods)
            {
                modValue += (int)(modifyingAttribute.attribute.AdjustedValue() * modifyingAttribute.ratio);
            }
        }
    }
}

public struct ModifyingAttribute
{
    public Attribute attribute;
    public float ratio;
}
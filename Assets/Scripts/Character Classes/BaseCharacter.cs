using System;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    Attribute[] primaryAttributes;
    Vital[] vitals;
    Skill[] skills;

    public string Name
    {
        get;
        set;
    }

    public int Level
    {
        get;
        set;
    }

    public uint FreeExp
    {
        get;
        set;
    }


    public void Awake()
    {
        Name = string.Empty;
        Level = 0;
        FreeExp = 0;

        int attributesCount = Enum.GetValues(typeof(AttributeName)).Length;
        primaryAttributes = new Attribute[attributesCount];
        SetupPrimaryAttributes();

        int vitalsCount = Enum.GetValues(typeof(VitalName)).Length;
        vitals = new Vital[vitalsCount];
        SetupVitals();

        int skillsCount = Enum.GetValues(typeof(SkillName)).Length;
        skills = new Skill[skillsCount];
        SetupSkills();
    }

    public void StatUpdate()
    {
        for (int i = 0; i < vitals.Length; i++)
        {
            vitals[i].Update();
        }

        for (int i = 0; i < skills.Length; i++)
        {
            skills[i].Update();
        }
    }

    public void AddExp(uint exp)
    {
        FreeExp += exp;

        CalculateLevel();
    }

    /// <summary>
    /// Not Finished: Take teh average of all the players skills
    /// and assign that as the player level
    /// </summary>
    public void CalculateLevel()
    {

    }

    public Attribute GetPrimaryAttribute(AttributeName attributeName)
    {
        return GetPrimaryAttribute((int)attributeName);
    }

    public Attribute GetPrimaryAttribute(int attributeIndex)
    {
        return primaryAttributes[attributeIndex];
    }

    public Skill GetSkill(SkillName skillName)
    {
        return GetSkill((int)skillName);
    }

    public Skill GetSkill(int index)
    {
        return skills[index];
    }

    public Vital GetVital(VitalName vitalName)
    {
        return GetVital((int)vitalName);
    }

    public Vital GetVital(int index)
    {
        return vitals[index];
    }

    private void SetupPrimaryAttributes()
    {
        for (int i = 0; i < primaryAttributes.Length; i++)
        {
            primaryAttributes[i] = new Attribute();
        }
    }

    private void SetupVitals()
    {
        for (int i = 0; i < vitals.Length; i++)
        {
            vitals[i] = new Vital();
        }
    }

    private void SetupSkills()
    {
        for (int i = 0; i < skills.Length; i++)
        {
            skills[i] = new Skill();
        }
    }

    private void SetupVitalModifiers()
    {
        // Health
        ModifyingAttribute health = new ModifyingAttribute();
        health.attribute = GetPrimaryAttribute(AttributeName.Constitution);
        health.ratio = 0.5f;

        GetVital(VitalName.Health).AddModifier(health);

        // Enery
        ModifyingAttribute energy = new ModifyingAttribute();
        energy.attribute = GetPrimaryAttribute(AttributeName.Constitution);
        energy.ratio = 1;

        GetVital(VitalName.Energy).AddModifier(energy);

        // Mana
        ModifyingAttribute mana = new ModifyingAttribute();
        mana.attribute = GetPrimaryAttribute(AttributeName.Constitution);
        mana.ratio = 1;

        GetVital(VitalName.Mana).AddModifier(mana);
    }

    private void SetupSkillModifiers()
    {
        // Melee Offence
        AddSkillModifier(SkillName.Melee_Offence, AttributeName.Might, 0.33f);
        AddSkillModifier(SkillName.Melee_Offence, AttributeName.Nimbleness, 0.33f);

        // Melee Defence
        AddSkillModifier(SkillName.Melee_Defence, AttributeName.Speed, 0.33f);
        AddSkillModifier(SkillName.Melee_Defence, AttributeName.Constitution, 0.33f);

        // Magic Offence
        AddSkillModifier(SkillName.Magic_Offence, AttributeName.Concentration, 0.33f);
        AddSkillModifier(SkillName.Magic_Offence, AttributeName.Willpower, 0.33f);

        // Magic Defense
        AddSkillModifier(SkillName.Magic_Defence, AttributeName.Concentration, 0.33f);
        AddSkillModifier(SkillName.Magic_Defence, AttributeName.Willpower, 0.33f);

        // Ranged Offence
        AddSkillModifier(SkillName.Ranged_Office, AttributeName.Speed, 0.33f);
        AddSkillModifier(SkillName.Ranged_Office, AttributeName.Concentration, 0.33f);

        // Ranged Defense
        AddSkillModifier(SkillName.Ranged_Defence, AttributeName.Speed, 0.33f);
        AddSkillModifier(SkillName.Ranged_Defence, AttributeName.Nimbleness, 0.33f);
    }

    private void AddSkillModifier(SkillName skillName, AttributeName attributeName,
        float ratio)
    {
        ModifyingAttribute modifyingAttribute = new ModifyingAttribute();
        modifyingAttribute.attribute = GetPrimaryAttribute(attributeName);
        modifyingAttribute.ratio = ratio;
        GetSkill(skillName).AddModifier(modifyingAttribute);
    }
}

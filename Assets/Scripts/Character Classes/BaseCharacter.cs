using UnityEngine;
using System.Collections;
using System;

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


    void Awake()
    {
        Name = string.Empty;
        Level = 0;
        FreeExp = 0;

        int attributesCount = Enum.GetValues(typeof(AttributeName)).Length;
        primaryAttributes = new Attribute[attributesCount];

        int vitalsCount = Enum.GetValues(typeof(Vital)).Length;
        vitals = new Vital[vitalsCount];

        int skillsCount = Enum.GetValues(typeof(Skill)).Length;
        skills = new Skill[skillsCount];
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
}

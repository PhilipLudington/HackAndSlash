using UnityEngine;
using System.Collections;
using System;

public class CharacterGenerator : MonoBehaviour
{
    private const int StartingPoints = 350;
    private const int MinimumStartingValue = 10;
    private const int StartingValue = 50;

    private int pointsLeft;

    private PlayerCharacter toon;

    // Use this for initialization
    void Start()
    {
        toon = new PlayerCharacter();
        toon.Awake();

        pointsLeft = StartingPoints;

        for (int i = 0; i < Enum.GetValues(typeof(AttributeName)).Length; i++)
        {
            toon.GetPrimaryAttribute(i).BaseValue = StartingValue;
            pointsLeft -= (StartingValue - MinimumStartingValue);
        }

        toon.StatUpdate();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnGUI()
    {
        DisplayName();

        DisplayAttributes();

        DisplaySkills();

        DisplayVitals();

        DisplayPointsLeft();
    }

    private void DisplayName()
    {
        GUI.Label(new Rect(10, 10, 50, 25), "Name: ");
        toon.Name = GUI.TextField(new Rect(65, 10, 100, 25), toon.Name);
    }

    private void DisplayAttribute(int index)
    {
        int y = 40 + (index * 25);

        GUI.Label(new Rect(10, y, 100, 25), ((AttributeName)index).ToString());
        GUI.Label(new Rect(115, y, 30, 25), toon.GetPrimaryAttribute(index).AdjustedBaseValue.ToString());

        if (GUI.Button(new Rect(135, y, 25, 25), "-"))
        {
            if (toon.GetPrimaryAttribute(index).BaseValue > MinimumStartingValue)
            {
                toon.GetPrimaryAttribute(index).BaseValue--;
                pointsLeft++;
            }
            toon.StatUpdate();
        }

        if (GUI.Button(new Rect(160, y, 25, 25), "+"))
        {
            if (pointsLeft > 0)
            {
                toon.GetPrimaryAttribute(index).BaseValue++;
                pointsLeft--;
            }
            toon.StatUpdate();
        }
    }

    private void DisplayAttributes()
    {
        for (int i = 0; i < Enum.GetValues(typeof(AttributeName)).Length; i++)
        {
            DisplayAttribute(i);
        }
    }

    private void DisplaySkill(int index)
    {
        GUI.Label(new Rect(190, 40 + (index * 25), 100, 25), ((SkillName)index).ToString());

        GUI.Label(new Rect(290, 40 + (index * 25), 30, 25), toon.GetSkill(index).AdjustedBaseValue.ToString());
    }

    private void DisplaySkills()
    {
        for (int i = 0; i < Enum.GetValues(typeof(SkillName)).Length; i++)
        {
            DisplaySkill(i);
        }
    }

    private void DisplayVital(int index)
    {
        GUI.Label(new Rect(340, 40 + (index * 25), 100, 25), ((VitalName)index).ToString());

        GUI.Label(new Rect(440, 40 + (index * 25), 30, 25), toon.GetVital(index).AdjustedBaseValue.ToString());
    }

    private void DisplayVitals()
    {
        for (int i = 0; i < Enum.GetValues(typeof(VitalName)).Length; i++)
        {
            DisplayVital(i);
        }
    }

    private void DisplayPointsLeft()
    {
        GUI.Label(new Rect(200, 10, 150, 25),
            string.Format("Points Remaining: {0}", pointsLeft));
    }
}

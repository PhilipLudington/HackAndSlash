using UnityEngine;
using System.Collections;
using System;

public class CharacterGenerator : MonoBehaviour
{
    // Attribute Constants
    private const int StartingPoints = 350;
    private const int MinimumStartingValue = 10;
    private const int StartingValue = 50;

    // display constants
    private const int Offset = 5;
    private const int LineHeight = 23;
    private const int StatLabelWidth = 100;
    private const int BaseValueLabelWidth = 30;
    private const int ButtonWidth = 20;
    private const int ButtonHeight = 20;
    private const int StatStartingPoss = 40;

    // GUI Style vars
    public GUIStyle guiStyle;
    public GUISkin guiSkin;

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
        GUI.skin = guiSkin;

        DisplayName();

        DisplayAttributes();

        DisplaySkills();

        GUI.skin = null;

        DisplayVitals();

        GUI.skin = guiSkin;

        DisplayPointsLeft();
    }

    private void DisplayName()
    {
        GUI.Label(new Rect(10, 10, 50, 25), "Name: ");
        toon.Name = GUI.TextField(new Rect(65, 10, 100, 25), toon.Name);
    }

    private void DisplayAttribute(int index)
    {
        int y = StatStartingPoss + (index * LineHeight);

        GUI.Label(new Rect(Offset, y, StatLabelWidth, LineHeight),
            ((AttributeName)index).ToString());

        GUI.Label(new Rect(StatLabelWidth + Offset, y, BaseValueLabelWidth, LineHeight),
            toon.GetPrimaryAttribute(index).AdjustedBaseValue.ToString());

        if (GUI.Button(new Rect(Offset + StatLabelWidth + BaseValueLabelWidth,
            y, ButtonWidth, ButtonHeight), "-"))
        {
            if (toon.GetPrimaryAttribute(index).BaseValue > MinimumStartingValue)
            {
                toon.GetPrimaryAttribute(index).BaseValue--;
                pointsLeft++;
            }
            toon.StatUpdate();
        }

        if (GUI.Button(new Rect(Offset + StatLabelWidth + BaseValueLabelWidth + ButtonWidth,
            y, ButtonWidth, ButtonHeight), "+", guiStyle))
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
        int y = StatStartingPoss + (index * LineHeight);
        int xAnchor = Offset + StatLabelWidth + Offset + BaseValueLabelWidth
            + ButtonWidth + ButtonHeight;

        GUI.Label(new Rect(xAnchor + Offset, y, StatLabelWidth, LineHeight),
            ((SkillName)index).ToString());

        GUI.Label(new Rect(xAnchor + Offset + StatLabelWidth, y,
            BaseValueLabelWidth, LineHeight), toon.GetSkill(index).AdjustedBaseValue.ToString());
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
        int y = StatStartingPoss + (index * LineHeight);
        int xAnchor = Offset + StatLabelWidth + Offset + BaseValueLabelWidth
            + ButtonWidth + ButtonHeight
            + Offset + StatLabelWidth + BaseValueLabelWidth;

        GUI.Label(new Rect(xAnchor + Offset, y, StatLabelWidth, LineHeight),
            ((VitalName)index).ToString());

        GUI.Label(new Rect(xAnchor + Offset + StatLabelWidth, y, BaseValueLabelWidth, LineHeight),
            toon.GetVital(index).AdjustedBaseValue.ToString());
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

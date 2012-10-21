using UnityEngine;
using System.Collections;
using System;

public class CharacterGenerator : MonoBehaviour
{
    private const int StartingPoints = 350;
    private const int MinimumStartingValue = 10;
    private int pointsLeft;

    private PlayerCharacter toon;

    // Use this for initialization
    void Start()
    {
        toon = new PlayerCharacter();
        toon.Awake();

        for (int i = 0; i < Enum.GetValues(typeof(AttributeName)).Length; i++)
        {
            toon.GetPrimaryAttribute(i).BaseValue = MinimumStartingValue;
        }

        pointsLeft = StartingPoints;
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
        toon.Name = GUI.TextArea(new Rect(65, 10, 100, 25), toon.Name);
    }

    private void DisplayAttribute(int index)
    {
        int y = 40 + (index * 25);

        GUI.Label(new Rect(10, y, 100, 25), ((AttributeName)index).ToString());

        GUI.Label(new Rect(115, y, 30, 25), toon.GetPrimaryAttribute(index).AdjustedBaseValue.ToString());
        GUI.Button(new Rect(145, y, 25, 25), "-");
        GUI.Button(new Rect(170, y, 25, 25), "+");
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
        GUI.Label(new Rect(200, 40 + (index * 25), 100, 25), ((SkillName)index).ToString());

        GUI.Label(new Rect(300, 40 + (index * 25), 30, 25), toon.GetSkill(index).AdjustedBaseValue.ToString());
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

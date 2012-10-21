using UnityEngine;
using System.Collections;
using System;

public class CharacterGenerator : MonoBehaviour
{

    private PlayerCharacter toon;

    // Use this for initialization
    void Start()
    {
        toon = new PlayerCharacter();
        toon.Awake();
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
    }

    private void DisplayName()
    {
        GUI.Label(new Rect(10, 10, 50, 25), "Name: ");
        toon.Name = GUI.TextArea(new Rect(65, 10, 100, 25), toon.Name);
    }

    private void DisplayAttribute(int index)
    {
        GUI.Label(new Rect(10, 40 + (index * 25), 100, 25), ((AttributeName)index).ToString());

        GUI.Label(new Rect(115, 40 + (index * 25), 30, 25), toon.GetPrimaryAttribute(index).AdjustedBaseValue.ToString());
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
        GUI.Label(new Rect(150, 40 + (index * 25), 100, 25), ((SkillName)index).ToString());

        GUI.Label(new Rect(250, 40 + (index * 25), 30, 25), toon.GetSkill(index).AdjustedBaseValue.ToString());
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
        GUI.Label(new Rect(290, 40 + (index * 25), 100, 25), ((VitalName)index).ToString());

        GUI.Label(new Rect(390, 40 + (index * 25), 30, 25), toon.GetVital(index).AdjustedBaseValue.ToString());
    }

    private void DisplayVitals()
    {
        for (int i = 0; i < Enum.GetValues(typeof(VitalName)).Length; i++)
        {
            DisplayVital(i);
        }
    }
}

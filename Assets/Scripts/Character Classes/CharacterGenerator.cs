using UnityEngine;
using System.Collections;

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
        GUI.Label(new Rect(10, 10, 50, 25), "Name: ");
        toon.Name = GUI.TextArea(new Rect(65, 10, 100, 25), toon.Name);
    }
}

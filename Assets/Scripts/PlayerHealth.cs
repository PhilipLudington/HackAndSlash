using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        if (currentHealth == 0)
        {
            // Do not draw
        }
        else
        {
            GUI.Box(new Rect(10, 10, Screen.width / 2 / (maxHealth / currentHealth), 20),
                string.Format("{0} / {1}", currentHealth, maxHealth));
        }
    }
}

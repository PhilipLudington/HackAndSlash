using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;

    public float healthBarLength;

    // Use this for initialization
    void Start()
    {
        healthBarLength = Screen.width / 2;
    }

    // Update is called once per frame
    void Update()
    {
        AdjustHealth(0);
    }

    void OnGUI()
    {
        if (currentHealth == 0)
        {
            // Do not draw
        }
        else
        {
            GUI.Box(new Rect(10, 10, healthBarLength, 20),
                string.Format("{0} / {1}", currentHealth, maxHealth));
        }
    }

    public void AdjustHealth(int adjustment)
    {
        currentHealth += adjustment;

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (maxHealth < 1)
        {
            maxHealth = 1;
        }

        healthBarLength = Screen.width / 2 * (currentHealth / (float)maxHealth);
    }
}

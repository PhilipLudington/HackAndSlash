using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    public GameObject target;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Check for attack key
        if (Input.GetKeyUp(KeyCode.F))
        {
            Attack();
        }
    }

    private void Attack()
    {
        float distance = Vector3.Distance(target.transform.position,
            transform.position);

        Debug.Log(distance);

        if (distance < 2)
        {
            EnemyHealth enemyHealth = (EnemyHealth)target.GetComponent("EnemyHealth");

            enemyHealth.AdjustHealth(-10);
        }
    }
}

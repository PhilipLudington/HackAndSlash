using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Targetting : MonoBehaviour
{
    public List<Transform> targets;

    public Transform selectedTarget;

    // Use this for initialization
    void Start()
    {
        targets = new List<Transform>();
        AddAllEnemies();

        selectedTarget = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TargetEnemy();
        }
    }

    public void AddAllEnemies()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in gameObjects)
        {
            AddTarget(enemy.transform);
        }
    }

    public void AddTarget(Transform enemy)
    {
        targets.Add(enemy);
    }

    private void TargetEnemy()
    {
        selectedTarget = targets[0];
    }
}

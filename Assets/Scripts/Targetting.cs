using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Targetting : MonoBehaviour
{
    public List<Transform> targets;

    public Transform selectedTarget;

    private Transform myTransform;

    // Use this for initialization
    void Start()
    {
        targets = new List<Transform>();
        selectedTarget = null;
        myTransform = transform;

        AddAllEnemies();
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

    private void SortTargetsByDistance()
    {
        targets.Sort(delegate(Transform t1, Transform t2)
        {
            return Vector3.Distance(t1.position, myTransform.position)
                .CompareTo(Vector3.Distance(t2.position, myTransform.position));
        });
    }

    private void TargetEnemy()
    {
        if (selectedTarget == null)
        {
            SortTargetsByDistance();
            selectedTarget = targets[0];
        }
        else
        {
            int index = targets.IndexOf(selectedTarget);

            if (index < targets.Count - 1)
            {
                index++;
            }
            else
            {
                index = 0;
            }

            selectedTarget = targets[index];
            SelectTarget();
        }
    }

    private void SelectTarget()
    {
        selectedTarget.renderer.material.color = Color.red;
    }
}

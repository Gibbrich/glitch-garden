using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    public GameObject[] Attackers;

    void Update()
    {
        foreach (GameObject attacker in Attackers)
        {
            if (IsTimeToSpawn(attacker))
            {
                Spawn(attacker);
            }
        }
    }

    private bool IsTimeToSpawn(GameObject attacker)
    {
        // todo change algorithm for more clear
        float spawnsPerSecond = 1 / attacker.GetComponent<Attacker>().SeenEverySeconds;
        float threshold = spawnsPerSecond * Time.deltaTime / 5;
        return Random.value < threshold;
    }

    private void Spawn(GameObject attaker)
    {
        GameObject obj = Instantiate(attaker, transform.position, Quaternion.identity);
        obj.transform.parent = transform;
    }
}
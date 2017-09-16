using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    public GameObject[] Attackers;
//    private float[] lastSpawnTime;
//    private Attacker attackerComponent;
    
    // Use this for initialization
    void Start()
    {
//        lastSpawnTime = new float[Attackers.Length];
    }

    // Update is called once per frame
    void Update()
    {
//        if (lastSpawnTime == 0 || 
//            Time.timeSinceLevelLoad - lastSpawnTime >= attackerComponent.SeenEverySeconds)
//        {
//            Spawn(Attacker);
//        }

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
//        lastSpawnTime = Time.timeSinceLevelLoad;
    }
}
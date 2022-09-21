using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] EnemiesReference;
    private GameObject spawnedMonster;
    [SerializeField]
    private Transform DogePos, BirdPos, PoopPos;
    public int randomSide;

    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        yield return new WaitForSeconds(3);

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 3));

            randomSide = Random.Range(0, 3);
            spawnedMonster = Instantiate(EnemiesReference[randomSide]);

            // DogePos
            if (randomSide == 0) spawnedMonster.transform.position = DogePos.position;

            // BirdPos
            if (randomSide == 1) spawnedMonster.transform.position = BirdPos.position;
            
            // Poop
            if (randomSide == 2) spawnedMonster.transform.position = PoopPos.position;
        }
    }
}

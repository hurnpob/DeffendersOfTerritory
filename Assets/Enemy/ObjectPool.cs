using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject enemyPrefab2;
    [SerializeField] [Range(0, 50)] int poolSize = 5;
    [SerializeField] [Range(0.1f, 30f)] float spawnTimer = 1f;
    
    GameObject[] pool;

    void Awake()
    {
        PopulatePool();
    }

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void PopulatePool()
    {        
        pool = new GameObject[poolSize];

        for(int i = 0; i < pool.Length; i++)
        {
            int randomNumber = Random.Range(0, 2);
            if (randomNumber == 0)
            {
                pool[i] = Instantiate(enemyPrefab, transform);
                pool[i].SetActive(false);   
            }
            if (randomNumber == 1)
            {
                pool[i] = Instantiate(enemyPrefab2, transform);
                pool[i].SetActive(false);   
            }

        }
    }

    void EnableObjectInPool()
    {
        for(int i = 0; i < pool.Length; i++)
        {
            if(pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }

    IEnumerator SpawnEnemy()
    {
        while(true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}

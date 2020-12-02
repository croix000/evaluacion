using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] GameObject[] spawnPoints;

    [SerializeField] GameObject[] enemyPrefabs;
    // Start is called before the first frame update

    private void Start()
    {
        StartCoroutine(spawnEnemy());
    }

    IEnumerator spawnEnemy()
    {

        while (true)
        {

            GameObject.Instantiate(enemyPrefabs[Random.Range(0, 2)], spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity);
            yield return new WaitForSeconds(4f);
        }
    }
}

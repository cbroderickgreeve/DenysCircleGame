using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject smallEnemy;
    public GameObject normalEnemy;
    public GameObject bigEnemy;

    public GameObject enemyContainer;

    public float randomOffset = 1.5f;

    private IEnumerator SpawnSmallEnemy()
    {
        yield return new WaitForSeconds(Random.Range(0f, 28f));
        while (true)
        {
            Vector3 position = new(transform.position.x + Random.Range(-randomOffset, randomOffset), transform.position.y + Random.Range(-randomOffset, randomOffset), 0);
            var newEnemy = Instantiate(smallEnemy, position, Quaternion.identity).GetComponent<SmallEnemy>();
            newEnemy.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(28f);
        }
    }

    private IEnumerator SpawnNormalEnemy()
    {
        yield return new WaitForSeconds(Random.Range(0f, 22f));
        while (true)
        {
            Vector3 position = new(transform.position.x + Random.Range(-randomOffset, randomOffset), transform.position.y + Random.Range(-randomOffset, randomOffset), 0);
            var newEnemy = Instantiate(normalEnemy, position, Quaternion.identity).GetComponent<NormalEnemy>();
            newEnemy.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(22f);
        }
    }

    private IEnumerator SpawnBigEnemy()
    {
        yield return new WaitForSeconds(Random.Range(0f, 32f));
        while (true)
        {
            Vector3 position = new(transform.position.x + Random.Range(-randomOffset, randomOffset), transform.position.y + Random.Range(-randomOffset, randomOffset), 0);
            var newEnemy = Instantiate(bigEnemy, position, Quaternion.identity).GetComponent<BigEnemy>();
            newEnemy.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(32f);
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnSmallEnemy());
        StartCoroutine(SpawnNormalEnemy());
        StartCoroutine(SpawnBigEnemy());
    }
}

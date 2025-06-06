using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] Spawns;
    public static List<Transform> wayPoints;
    public List<Transform> ways;
    public GameObject enemyPrefab;
    int enemyCount = 0;
    void Awake()
    {
        wayPoints = ways;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SapwnEnemi());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator SapwnEnemi() {
        yield return new WaitForSeconds(20);
        int RandomNumber = Random.Range(0, Spawns.Length);
        GameObject newEnemy = Instantiate(enemyPrefab, Spawns[RandomNumber].transform.position, Quaternion.identity, Spawns[RandomNumber].transform);
    }
}

using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour

{
    private BoxCollider2D _boxCollider;

    public GameObject[] enemyPrefab;
    
    public Transform spawnPosition;

    public Transform spawnPosition2;

    public Transform[] spawnPoints;

    public int enemiesToSpawn = 5;


void Awake()
{
    _boxCollider = GetComponent<BoxCollider2D>();
}

    IEnumerator SpawnEnemy()
    {
        foreach (Transform item in spawnPoints)
            {
                Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], item.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(0.5f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            _boxCollider.enabled = false;
            StartCoroutine(SpawnEnemy());
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

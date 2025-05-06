using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemySpawnManagerController : MonoBehaviour
{
    public GameObject enemyA;
    public int colorPick;
    public int enemyPoolSize;
    public float spawnPositionX;
    public float spawnPositionZ;
    public int minEnemySpawn;
    public int maxEnemySpawn;
    private UIManager uiManager;

    [SerializeField] List<GameObject> enemyList = new List<GameObject>();

    void Start()
    {

        uiManager = FindFirstObjectByType<UIManager>();
        AddToPool(enemyPoolSize);
        StartCoroutine(SpawnLoop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            GameObject enemy = GetEnemyFree();
            if (enemy != null )
            {
                SpawnEnemies(enemy);

            }
            yield return new WaitForSeconds(2f);
        }
    }

    void SpawnEnemies(GameObject enemy)
    {
        int spawnAmmount = 1;
        for (int i = 0; i < spawnAmmount; i++)
        {
            int pickedColor = RandomColor();
            enemy.transform.position = StartPosition();
            enemy.SetActive(true);
            uiManager.enemiesOnScreen += 1;

            EnemyController enemyController = enemy.GetComponent<EnemyController>();
            if (enemyController != null )
            {
                enemyController.ChooseColor(pickedColor);
            }


        }
    }

    public int RandomColor()
    {
        return Random.Range(0, 3);
        
    }

    public Vector3 StartPosition()
    {
        float rangeX = Random.Range(-spawnPositionX, spawnPositionX);
        float rangeZ = Random.Range(-spawnPositionZ, spawnPositionZ);

        return new Vector3 (rangeX, 4f, rangeZ);

    }
    void AddToPool(int enemyPoolSize)
    {
        for (int i = 0; i < enemyPoolSize; i++)
        {
            GameObject spawnedEnemy;
            spawnedEnemy = Instantiate(enemyA, Vector3.zero, Quaternion.identity);
            spawnedEnemy.SetActive(false);

            enemyList.Add(spawnedEnemy);
        }
    }

    public GameObject GetEnemyFree()
    {
        for(int i = 0; i < enemyList.Count; i++)
        {
            if (!enemyList[i].activeInHierarchy)
                return enemyList[i];
        }

        return null;
    }
}

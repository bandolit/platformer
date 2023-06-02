using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattle : MonoBehaviour
{
    public enum Stage
    {
        WaitingToStart,
        Stage_1,
        Stage_2,
        Stage_3,
    }

    [SerializeField] private ColliderTrigger colliderTrigger;
    [SerializeField] private GameObject Boss;

    [SerializeField] private GameObject pfEnemyShooterSpawn;


    [SerializeField] private GameObject shield_1;
    [SerializeField] private GameObject shield_2;

    [SerializeField] private List<GameObject> enemySpawnList;
    [SerializeField] private List<Transform> spawnPositionList;
    List<Transform> PastspawnPosition;
    [SerializeField] private Stage stage;

    [SerializeField] private GameObject batt1;
    [SerializeField] private GameObject batt2;
    [SerializeField] private GameObject batt3;
    [SerializeField] private GameObject batt4;

    [SerializeField] private GameObject[] test;

    private int nbPerWave = 3;

    private void Awake()
    {
        enemySpawnList = new List<GameObject>();

        foreach (Transform spawnPosition in transform.Find("spawnPositions"))
        {
            //spawnPositionList.Add(spawnPosition.position);
        }

        stage = Stage.WaitingToStart;
    }

    private void Start()
    {
        //SpawnEnemy();
        StartBattle();
        shield_1.SetActive(false);
        shield_2.SetActive(false);

    }

    private void FixedUpdate()
    {
        foreach (GameObject Enemy in enemySpawnList)
        {
            if (false == Enemy.activeInHierarchy)
            {
                SpawnEnemy();
            }
        }
        BossBattle_OnDamaged();
       
       
    }

    private void Update()
    {
        test = GameObject.FindGameObjectsWithTag("mechant");

        if(test.Length < nbPerWave)
        {
            SpawnEnemy();
        }
    }

    private void BossBattle_OnDead()
    {
        // Boss dead! Boss battle over!
        Debug.Log("Boss Battle Over!");

        DestroyAllEnemies();
    }

    private void BossBattle_OnDamaged()
    {
        // Boss took damage
        switch (stage)
        {
            case Stage.Stage_1:
                if (Boss.GetComponent<BossHealth>().currentHealth <= 700)
                {
                    // Boss under 70% health

                    StartNextStage();
                }
                break;

            case Stage.Stage_2:

                if (Boss.GetComponent<BossHealth>().currentHealth <= 300)
                {
                    // Boss under 30% health
                    batt1.GetComponent<BattHealth>().currentHealth = 100;
                    batt2.GetComponent<BattHealth>().currentHealth = 100;
                    batt3.GetComponent<BattHealth>().currentHealth = 100;
                    batt4.GetComponent<BattHealth>().currentHealth = 100;
                    batt1.GetComponentInChildren<HealthBar>().SetHealth(100);
                    batt2.GetComponentInChildren<HealthBar>().SetHealth(100);
                    batt3.GetComponentInChildren<HealthBar>().SetHealth(100);
                    batt4.GetComponentInChildren<HealthBar>().SetHealth(100);
                    StartNextStage();
                }
                break;
        }
    }


    private void StartBattle()
    {
        Debug.Log("StartBattle");
        StartNextStage();
    }

    private void StartNextStage()
    {
        switch (stage)
        {
            case Stage.WaitingToStart:
                stage = Stage.Stage_1;

                nbPerWave = 0;

                break;

            case Stage.Stage_1:

                nbPerWave = 3;

                stage = Stage.Stage_2;
                shield_1.SetActive(true);


                break;

            case Stage.Stage_2:


                stage = Stage.Stage_3;
                Debug.Log("WTF");
                shield_2.SetActive(true);
                break;
        }
        Debug.Log("Starting next stage: " + stage);
    }

    private void SpawnEnemy()
    {
       /** int aliveCount = 0;
        foreach (GameObject Enemy in enemySpawnList)
        {
            // Enemy alive
            aliveCount++;
            if (aliveCount >= 3)
            {
                // Don't spawn more enemies
                return;
            }
        }*/

        Transform spawnPosition = spawnPositionList[UnityEngine.Random.Range(0, spawnPositionList.Count)];

        /**foreach (Transform Spawn in PastspawnPosition)
        {
            if (spawnPosition == Spawn)
            {
               spawnPosition = spawnPositionList[UnityEngine.Random.Range(0, spawnPositionList.Count)];
           }
        }*/
        

        GameObject enemySpawn = Instantiate(pfEnemyShooterSpawn, spawnPosition.position, Quaternion.identity);
        //enemySpawn.Spawn();

        //enemySpawnList.Add(enemySpawn);
    }



    private void DestroyAllEnemies()
    {
        foreach (GameObject Enemy in enemySpawnList)
        {
            if (Enemy.GetComponent<EnemySpawn>().IsAlive())
            {
                Enemy.GetComponent<EnemySpawn>().KillEnemy();
            }
        }
    }

}

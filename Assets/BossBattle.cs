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

    [SerializeField] private EnemySpawn pfEnemyShooterSpawn;


    [SerializeField] private GameObject shield_1;
    [SerializeField] private GameObject shield_2;

    [SerializeField] private List<EnemySpawn> enemySpawnList;
    [SerializeField] private List<Vector3> spawnPositionList;
    private Stage stage;

    private void Awake()
    {
        enemySpawnList = new List<EnemySpawn>();
        spawnPositionList = new List<Vector3>();

        foreach (Transform spawnPosition in transform.Find("spawnPositions"))
        {
            spawnPositionList.Add(spawnPosition.position);
        }

        stage = Stage.WaitingToStart;
    }

    private void Start()
    {
        StartBattle();
        shield_1.SetActive(false);
        shield_2.SetActive(false);
    }

    private void BossBattle_OnDead(object sender, System.EventArgs e)
    {
        // Boss dead! Boss battle over!
        Debug.Log("Boss Battle Over!");

        DestroyAllEnemies();
    }

    private void BossBattle_OnDamaged(object sender, System.EventArgs e)
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

                SpawnEnemy();
                SpawnEnemy();

                break;

            case Stage.Stage_1:
                stage = Stage.Stage_2;
                shield_1.SetActive(true);
                SpawnEnemy();
                SpawnEnemy();

                break;
            case Stage.Stage_2:
                stage = Stage.Stage_3;
                shield_2.SetActive(true);
                SpawnEnemy();
                SpawnEnemy();
                SpawnEnemy();
                break;
        }
        Debug.Log("Starting next stage: " + stage);
    }

    private void SpawnEnemy()
    {
        int aliveCount = 0;
        foreach (EnemySpawn enemySpawned in enemySpawnList)
        {
            if (enemySpawned.IsAlive())
            {
                // Enemy alive
                aliveCount++;
                if (aliveCount >= 10)
                {
                    // Don't spawn more enemies
                    return;
                }
            }
        }

        Vector3 spawnPosition = spawnPositionList[UnityEngine.Random.Range(0, spawnPositionList.Count)];

        EnemySpawn pfEnemySpawn;

        pfEnemySpawn = pfEnemyShooterSpawn;

        EnemySpawn enemySpawn = Instantiate(pfEnemySpawn, spawnPosition, Quaternion.identity);
        enemySpawn.Spawn();

        enemySpawnList.Add(enemySpawn);
    }



    private void DestroyAllEnemies()
    {
        foreach (EnemySpawn enemySpawn in enemySpawnList)
        {
            if (enemySpawn.IsAlive())
            {
                enemySpawn.KillEnemy();
            }
        }
    }
}

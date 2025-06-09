using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int enemiesAlive = 0;

    [Header("Static Waves")]
    public Wave[] waves;

    [Header("Enemies Types")]
    public GameObject[] enemies;
    //private bool isCustomEnd = false;
    //public int lastWaveNumber;

    public bool isCustomWave = true;

    [Header("Wave Stuff")]
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    private float countDown = 5f;
    public Text waveCountdownText;

    public GameManager gameManager;

    [HideInInspector]
    public static int waveIndex;
    public static float curEnemyHelth = 0;
    public static float curEnemySpeed = 0;
    public static float curEnemyWorth = 0;

    void Start()
    {
        waveIndex = 0;
    }

    void Update()
    {
        if (enemiesAlive > 0)
        {
            return;
        }

        if (waveIndex == waves.Length)
        {
            gameManager.winLevel();
            this.enabled = false;
        }

        if (countDown <= 0f) 
        {
            if (isCustomWave)
            {
                StartCoroutine(spawnWaveCustom_One());
            }
            else
            {
                StartCoroutine(spawnWaveStatic());
            }
            countDown = timeBetweenWaves;
            return;
        }

        countDown -= Time.deltaTime;

        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countDown); 
    }

    IEnumerator spawnWaveStatic()
    {
        PlayerStats.RoundsSurvived++;

        Wave _wave = waves[waveIndex];

        curEnemyHelth = _wave.enemy.GetComponent<Enemy>().startHealth;
        curEnemySpeed = _wave.enemy.GetComponent<Enemy>().speed;
        curEnemyWorth = _wave.enemy.GetComponent<Enemy>().worth;

        enemiesAlive = _wave.count;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        waveIndex++;
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }


    //===========================================================================

    IEnumerator spawnWaveCustom_One()
    {
        PlayerStats.RoundsSurvived++;

        switch (waveIndex)
        {
            case 0:
                for (int i = 0; i < 10; i++)
                {
                    SpawnEnemy(enemies[0]);
                    yield return new WaitForSeconds(0.5f);
                }
                break;
            case 1:
                for (int i = 0; i < 10; i++)
                {
                    SpawnEnemy(enemies[0]);
                    yield return new WaitForSeconds(0.4f);
                }
                break;
            case 2:
                for (int i = 0; i < 5; i++)
                {
                    SpawnEnemy(enemies[1]);
                    yield return new WaitForSeconds(0.5f);
                    SpawnEnemy(enemies[0]);
                    yield return new WaitForSeconds(0.3f);
                    SpawnEnemy(enemies[0]);
                    yield return new WaitForSeconds(0.3f);
                }
                break;
            case 3:
                for (int i = 0; i < 15; i++)
                {
                    SpawnEnemy(enemies[0]);
                    yield return new WaitForSeconds(0.2f);
                }
                break;
            case 4:
                for (int i = 0; i < 5; i++)
                {
                    SpawnEnemy(enemies[2]);
                    yield return new WaitForSeconds(0.5f);
                    SpawnEnemy(enemies[1]);
                    yield return new WaitForSeconds(0.3f);
                    SpawnEnemy(enemies[1]);
                    yield return new WaitForSeconds(0.3f);
                }
                break;
            case 5:
                for (int i = 0; i < 13; i++)
                {
                    SpawnEnemy(enemies[2]);
                    yield return new WaitForSeconds(0.5f);
                    SpawnEnemy(enemies[0]);
                    yield return new WaitForSeconds(0.3f);
                    SpawnEnemy(enemies[0]);
                    yield return new WaitForSeconds(0.3f);
                    SpawnEnemy(enemies[0]);
                    yield return new WaitForSeconds(0.3f);
                }
                break;
            case 6:
                for (int i = 0; i < 5; i++)
                {
                    SpawnEnemy(enemies[3]);
                    yield return new WaitForSeconds(0.5f);
                }
                break;
            default:
                break;

        }


        waveIndex++;

        //if (waveIndex == lastWaveNumber)
        //{
        //    Debug.Log("Level Won!");
        //    this.enabled = false;
        //}
    }
}

using UnityEngine;
using UnityEngine.UI;

public class EnemyHelthSpeedWorthUI : MonoBehaviour
{
    public Text currenEnemyStats;

    void Update()
    {
        currenEnemyStats.text = "Health: " + WaveSpawner.curEnemyHelth.ToString() + '\n' +
            "Speed: " + WaveSpawner.curEnemySpeed.ToString() + '\n' +
                        "Worth: " + WaveSpawner.curEnemyWorth.ToString();
    }
}

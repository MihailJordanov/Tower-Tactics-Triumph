using UnityEngine;
using UnityEngine.UI;

public class CurrentWaveTextUI : MonoBehaviour
{
    public Text currentWaveCountText;

    // Update is called once per frame
    void Update()
    {
        currentWaveCountText.text = WaveSpawner.waveIndex.ToString();
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public SceneFader SceneFader;

    public string menuSceneName;

    public void retry()
    {
        SceneFader.fadeTo(SceneManager.GetActiveScene().name);
    }

    public void menu() 
    {
        SceneFader.fadeTo(menuSceneName);
    }

}

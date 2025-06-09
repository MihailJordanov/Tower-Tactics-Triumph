using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "Levelselect";

    public SceneFader SceneFader;

    public void play()
    {
        SceneFader.fadeTo(levelToLoad);
    }

    public void quit()
    {
        Debug.Log("Exciting...");
        Application.Quit();
    }
}

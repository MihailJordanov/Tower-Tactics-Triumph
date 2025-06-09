using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedMenu : MonoBehaviour
{
    public GameObject ui;
    public SceneFader sceneFader;

    public string menuSceneName;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.P))
        {
            toggle();
        }
    }

    public void toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if(ui.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;    
        }
    }

    public void retry()
    {
        toggle();
        sceneFader.fadeTo(SceneManager.GetActiveScene().name);
    }

    public void menu()
    {
        toggle();
        sceneFader.fadeTo(menuSceneName);
    }
}

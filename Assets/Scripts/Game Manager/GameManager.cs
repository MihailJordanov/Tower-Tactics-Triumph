using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver;

    public GameObject gameOverUI;
    public GameObject compliteLevelUI;

    public SceneFader SceneFader;
     
    void Start()
    {
        gameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsOver)
            return;

        if (PlayerStats.Lives <= 0) 
        {
            endGame();
        }
    }

    void endGame()
    {
        gameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void winLevel()
    {
        gameIsOver = true;
        compliteLevelUI.SetActive(true);
    }
}

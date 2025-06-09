using UnityEngine;


public class LevelSelector : MonoBehaviour
{
    public SceneFader SceneFader;

    void Start()
    {
        
    }

    public void select(string levelName)
    {
        SceneFader.fadeTo(levelName);
    }
}

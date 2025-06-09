using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompliteLevel : MonoBehaviour
{
    public string menuSceneName = "Main Menu";

    public SceneFader SceneFader;

    public void menu()
    {
        SceneFader.fadeTo(menuSceneName);
    }
}

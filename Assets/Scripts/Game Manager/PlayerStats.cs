using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static float Money;
    public float startMoney = 400;

    public static int Lives;
    public int startLives = 20;

    public static int RoundsSurvived;

    void Start()
    {
        Money = startMoney;
        Lives = startLives;

        RoundsSurvived = 0;
    }


}

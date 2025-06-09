using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBluePrint
{
    public GameObject prefab;
    public int cost;

    public GameObject upgrade_One_Prefab;
    public int upgrade_One_Cost;

    public GameObject upgrade_Two_Prefab;
    public int upgrade_Two_Cost;

    public GameObject upgrade_Three_Prefab;
    public int upgrade_Three_Cost;

    public float getSellAmount()
    {
        return cost / 2;
    }

}

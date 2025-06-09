using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color hasNoMoneyColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBluePrint turretBluePrint;
    [HideInInspector]
    public int upgraded_Level = 0;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;


    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 getBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if(turret != null)
        {
            buildManager.selectNode(this);
            return;
        }

        if (!buildManager.canBuild)
            return;

        buildTurret(buildManager.getTurretToBuild());
    }


    void buildTurret(TurretBluePrint bluePrint)
    {
        if (PlayerStats.Money < bluePrint.cost)
        {
            Debug.Log("Not enought money to build!");
            return;
        }

        PlayerStats.Money -= bluePrint.cost;

        GameObject _turret = (GameObject)Instantiate(bluePrint.prefab, getBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBluePrint = bluePrint;

        //effect
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, getBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret Build!");
    }


    public void upgrade_One_Turret()
    {
        if (PlayerStats.Money < turretBluePrint.upgrade_One_Cost)
        {
            Debug.Log("Not enought money to upgrade!");
            return;
        }

        PlayerStats.Money -= turretBluePrint.upgrade_One_Cost;

        //Get rid of the old turret
        Destroy(turret);

        //Build a new one
        GameObject _turret = (GameObject)Instantiate(turretBluePrint.upgrade_One_Prefab, getBuildPosition(), Quaternion.identity);
        turret = _turret;

        //effect
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, getBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        upgraded_Level = 1;

        Debug.Log("Turret Upgraded To Level One!");
    }

    public void upgrade_Two_Turret()
    {
        if (PlayerStats.Money < turretBluePrint.upgrade_Two_Cost)
        {
            Debug.Log("Not enought money to upgrade!");
            return;
        }

        PlayerStats.Money -= turretBluePrint.upgrade_Two_Cost;

        //Get rid of the old turret
        Destroy(turret);

        //Build a new one
        GameObject _turret = (GameObject)Instantiate(turretBluePrint.upgrade_Two_Prefab, getBuildPosition(), Quaternion.identity);
        turret = _turret;

        //effect
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, getBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        upgraded_Level = 2;

        Debug.Log("Turret Upgraded To Level Two!");
    }

    public void upgrade_Three_Turret()
    {
        if (PlayerStats.Money < turretBluePrint.upgrade_Three_Cost)
        {
            Debug.Log("Not enought money to upgrade!");
            return;
        }

        PlayerStats.Money -= turretBluePrint.upgrade_Three_Cost;

        //Get rid of the old turret
        Destroy(turret);

        //Build a new one
        GameObject _turret = (GameObject)Instantiate(turretBluePrint.upgrade_Three_Prefab, getBuildPosition(), Quaternion.identity);
        turret = _turret;

        //effect
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, getBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        upgraded_Level = 3;

        Debug.Log("Turret Upgraded To Level Three!");
    }

    public void upgateTurret()
    {
        if (upgraded_Level == 0) 
        {
            upgrade_One_Turret();
        }
        else if(upgraded_Level == 1)
        {
            upgrade_Two_Turret();
        }
        else 
        {
            upgrade_Three_Turret();
        }
    }

    public void sellTurret()
    {
        PlayerStats.Money += turretBluePrint.getSellAmount();

        //effect
        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, getBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(turret);
        turretBluePrint = null;
        upgraded_Level = 0;
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return; 

        if (!buildManager.canBuild)
            return;
        if (buildManager.hasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = hasNoMoneyColor;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}

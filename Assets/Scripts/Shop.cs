using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBluePrint standrtTurret;
    public TurretBluePrint freezeTurret;
    public TurretBluePrint fastShootingTurret;
    public TurretBluePrint missileLauncher;
    public TurretBluePrint SlowlaserBeamer;
    public TurretBluePrint laserBeamer;
    public TurretBluePrint worthUpTurret;
    public TurretBluePrint inferno;
    public TurretBluePrint radar;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void selectStandartTurret()
    {
        Debug.Log("Standart Build Selected");
        buildManager.selectTurretToBuild(standrtTurret);
    }

    public void selectFreezeTurret()
    {
        Debug.Log("Freeze Build Selected");
        buildManager.selectTurretToBuild(freezeTurret);
    }

    public void selectMissileLauncher()
    {
        Debug.Log("Missile Launcher Build Selected");
        buildManager.selectTurretToBuild(missileLauncher);
    }

    public void selectFastShootingTurret()
    {
        Debug.Log("Fast Shooting Turret Build Selected");
        buildManager.selectTurretToBuild(fastShootingTurret);
    }

    public void selectLaserBeamer()
    {
        Debug.Log("Laser Beamer Build Selected");
        buildManager.selectTurretToBuild(laserBeamer);
    }

    public void selectSlowLaserBeamer()
    {
        Debug.Log("Slow Laser Beamer Build Selected");
        buildManager.selectTurretToBuild(SlowlaserBeamer);
    }

    public void selectWorthUpTurret()
    {
        Debug.Log("WorthUp Turret Build Selected");
        buildManager.selectTurretToBuild(worthUpTurret);
    }

    public void selectInfernoTurret()
    {
        Debug.Log("Inferno Build Selected");
        buildManager.selectTurretToBuild(inferno);
    }

    public void selectRadarTurret()
    {
        Debug.Log("Radar Build Selected");
        buildManager.selectTurretToBuild(radar);
    }
}

using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if(instance!=null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
            
        instance = this;
    }

    public GameObject buildEffect;
    public GameObject sellEffect;

    private TurretBluePrint turretToBuild;
    private Node selectedNode;

    public NodeUI nodeUI;

    public bool canBuild
    {
        get
        {
            return turretToBuild != null;
        }
    }

    public bool hasMoney
    {
        get
        {
            return PlayerStats.Money >= turretToBuild.cost;
        }
    }

    public void selectNode(Node node)
    {
        if(selectedNode == node)
        {
            deselctNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.setTarget(node);
    }

    public void deselctNode()
    {
        selectedNode = null;
        nodeUI.hide();
    }


    public void selectTurretToBuild(TurretBluePrint turret)
    {
        turretToBuild = turret;

        deselctNode(); 
    }

    public TurretBluePrint getTurretToBuild()
    {
        return turretToBuild;
    }
}

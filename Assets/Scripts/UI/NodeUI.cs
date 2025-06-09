using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;

    public Text upgradeCostText;
    public Button upgradeButton;

    public Text sellAmount;

    private Node target;

    public void setTarget(Node _target)
    {
        target = _target;

        transform.position = target.getBuildPosition();

        if(target.upgraded_Level == 0)
        {
            upgradeCostText.text = "$: " + target.turretBluePrint.upgrade_One_Cost;
            upgradeButton.interactable = true;
        }
        else if(target.upgraded_Level == 1)
        {
            upgradeCostText.text = "$: " + target.turretBluePrint.upgrade_Two_Cost;
            upgradeButton.interactable = true;
        }
        else if(target.upgraded_Level == 2)
        {
            upgradeCostText.text = "$: " + target.turretBluePrint.upgrade_Three_Cost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCostText.text = "Done!";
            upgradeButton.interactable = false;
        }

        sellAmount.text = "$: " + target.turretBluePrint.getSellAmount();

        ui.SetActive(true);
    }

    public void hide()
    {
        ui.SetActive(false);
    }

    public void upgrade()
    {
        target.upgateTurret();
        BuildManager.instance.deselctNode();  
    }

    public void sell()
    {
        target.sellTurret();
        BuildManager.instance.deselctNode();    
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgrader : MonoBehaviour
{
    public GameObject tower = null;

    public void UpgradeTower(){
        if (tower == null){
            Debug.Log("No Tower to Upgrade!");
        }
        else if(PlayerController.curMoney < tower.GetComponent<Tower>().upgradeCost){
            Debug.Log("Not enough money to upgrade!");
        }
        else{
            PlayerController.curMoney -= tower.GetComponent<Tower>().upgradeCost;
            tower.GetComponent<Tower>().UpgradeTower();
        }
        gameObject.SetActive(false);
    }

    public void SellTower(){
        gameObject.SetActive(false);
    }
}

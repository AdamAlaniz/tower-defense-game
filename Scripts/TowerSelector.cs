using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelector : MonoBehaviour
{
    public GameObject towerLocation;
    //[SerializeField] GameObject towerPrefab;

    public void AddTower(GameObject towerPrefab){
        if (PlayerController.curMoney < towerPrefab.GetComponent<Tower>().purchaseCost){
            Debug.Log("Not enough money to add tower!");
        }
        else{
            PlayerController.curMoney -= towerPrefab.GetComponent<Tower>().purchaseCost;
            towerLocation.GetComponent<TowerGenerator>().tower = Instantiate(towerPrefab, towerLocation.transform.position, Quaternion.identity);
            towerLocation.GetComponent<TowerGenerator>().hasTower = true;
        }
        gameObject.SetActive(false);
    }
}

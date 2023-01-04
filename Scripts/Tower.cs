using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TOWER_TYPE { LASER, GUN, MISSILE, TOWER_COUNT };
public class Tower : MonoBehaviour
{
    public TOWER_TYPE towerType = TOWER_TYPE.LASER;
    public float shootRate = 50f;
    public float towerDamage = 10f;
    public float towerRange = 5f;
    public int purchaseCost = 50;
    public int upgradeCost = 25;

    public void UpgradeTower(){
        Debug.Log("Tower upgraded");
        PlayerController.curPrice *= 2;
        towerDamage += 10;
        shootRate += 10;
    }
}
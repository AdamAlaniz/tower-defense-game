using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Tower))]
public class TowerShooting : MonoBehaviour
{
    [SerializeField] private LineRenderer laser;
    [SerializeField] private Transform fireLocation;
    [SerializeField] private GameObject towerHead;
    private Tower tower;
    public GameObject target;
    private float nextShootTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        tower = GetComponent<Tower>();
        InvokeRepeating("SelectTarget", 0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null){
            laser.enabled = false;
            return;
        }
        LockOnTarget();
        ShootTarget();
    }

    private void LockOnTarget(){
        towerHead.transform.rotation = Quaternion.LookRotation(target.transform.position - fireLocation.position);
    }

    private void SelectTarget(){
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        float minDist = Mathf.Infinity;
        int selectedEnemy = -1;
        for (int i = 0; i < allEnemies.Length; i++){
            float dist = Vector3.Distance(transform.position, allEnemies[i].transform.position);
            if(dist < minDist){
                minDist = dist;
                selectedEnemy = i;
            }
        }
        if (selectedEnemy != -1 && minDist <= tower.towerRange)
            target = allEnemies[selectedEnemy];
        else
            target = null;
    }

    private void ShootTarget(){
        if(Time.time > nextShootTime){
            switch (tower.towerType){
                case TOWER_TYPE.LASER:
                    ShootLaser();
                    break;
                case TOWER_TYPE.GUN:
                    laser.enabled = false;
                    ShootGun();
                    break;
                case TOWER_TYPE.MISSILE:
                    laser.enabled = false;
                    ShootMissile();
                    break;
                default:
                    break;
            }
            nextShootTime = Time.time + 1 / tower.shootRate;
        }
    }

    private void ShootLaser(){
        // visual laser effect
        laser.enabled = true;
        laser.SetPosition(0, fireLocation.position);
        laser.SetPosition(1, target.transform.position);
        // apply damage
        target.GetComponent<Enemy>().TakeDamage(tower.towerDamage);
    }

    private void ShootGun(){
        throw new NotImplementedException();
    }

    private void ShootMissile(){
        throw new NotImplementedException();
    }
}

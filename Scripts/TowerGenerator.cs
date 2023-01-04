using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGenerator : MonoBehaviour
{
    [SerializeField] private GameObject towerSelectionPanel;
    [SerializeField] private GameObject towerUpgradePanel;
    public GameObject tower;
    public bool hasTower = false;

    // Start is called before the first frame update
    void Awake()
    {
        towerSelectionPanel = GameObject.Find("TowerSelectionPanel");
        towerUpgradePanel = GameObject.Find("TowerUpgradePanel");
    }

    private void Start()
    {
        towerSelectionPanel.SetActive(false);
        towerUpgradePanel.SetActive(false);
    }
    // Update is called once per frame
    public void SelectTower()
    {
        if (hasTower)
        {
            // tower upgrade / sell
            towerSelectionPanel.SetActive(false);
            towerUpgradePanel.SetActive(true);
            towerUpgradePanel.GetComponent<TowerUpgrader>().tower = tower;
        }
        else
        {
            // tower adding
            towerUpgradePanel.SetActive(false);
            towerSelectionPanel.SetActive(true);
            towerSelectionPanel.GetComponent<TowerSelector>().towerLocation = gameObject;
        }
    }
}

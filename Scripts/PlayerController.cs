using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int startMoney = 100;
    [SerializeField] private int startHealth = 100;
    [SerializeField] private int price = 25;
    public static int curMoney;
    [SerializeField] private int curHealth;
    public static int curPrice;
    [SerializeField] private Text healthText;
    [SerializeField] private Text moneyText;
    [SerializeField] private Text priceText;

    // Start is called before the first frame update
    void Start()
    {
        curPrice = price;
        curMoney = startMoney;
        curHealth = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        priceText.text = "$" + curPrice.ToString();
        healthText.text = "Health: " + curHealth.ToString();
        moneyText.text = "Money: $" + curMoney.ToString();
    }

    public void TakeDamage(int dmg){
        curHealth -= dmg;
        if(curHealth <= 0)
            Debug.Log("GameOver!!");
    }
}

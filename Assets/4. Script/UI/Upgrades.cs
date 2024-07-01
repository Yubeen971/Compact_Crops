using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{   
    public Text UpgradeOneText;
    public Text UpgradeDiceText;
    public Text resultText;
    public Text levelTextLand;
    public Text levelTextDice;


    
    private System.Random random = new System.Random();

    public int level = 1;
    public int upgradeCost = 100; // 업그레이드 비용


    public int DiceCoin = 50;

    public int Dicelevel = 1;
    public int DiceCost = 20;
    public GameObject objectToMoveBoat; // 이동시킬 오브젝트를 저장하는 변수

    //Land

    public GameObject Land_2;
    public GameObject Land_3;
    public GameObject Land_4;
    public GameObject Land_5;

    //여기다가 When you choose one of three, it upgrade one of three, consume the gold. 
    //if you don't have enough money, print("You don't have enough money");
    public void SelectOne ()
    {   
        if (GameManager.instance.SpendCoins(upgradeCost))
        {
            level++;
            upgradeCost += 500; // 업그레이드 비용 증가
            UpdateLandCoinDisplay(upgradeCost);
            UpdateLandLVDisplay(level);
            if(level == 2)
            {
                Upgrade_2();
            }
            else if(level == 3)
            {
                Upgrade_3();
            }
            else if(level == 4)
            {
                Upgrade_4();
            }
        }
        else
        {
            Debug.Log("Not enough coins to upgrade.");
        }
   
    }
    public void SelectTwo ()
    {   
        if (GameManager.instance.SpendCoins(10000))
        {
            objectToMoveBoat.transform.position = new Vector3(1f, -0.622f, -5f);
        }
        else
        {
            Debug.Log("Not enough coins to upgrade.");
        }
        
    }
    public void SelectThree ()
    {   
        if (GameManager.instance.SpendCoins(DiceCost))
        {
            int diceResult = random.Next(1, 7); // 1부터 6까지의 랜덤 숫자 생성
            resultText.text = "Dice Result: " + diceResult;
        if (diceResult == 6)
        {
            GameManager.instance.AddCoins(DiceCoin);
            Dicelevel++;
            DiceCost = 2*DiceCost;
            DiceCoin = 5*DiceCost;
            UpdateDiceLVDisplay(Dicelevel);
            UpdateDiceCoinDisplay(DiceCost);
        }
        }
    }

    public void QuitGame ()
    {
        Debug.Log ("GOT BACK");
        Application.Quit();
    }


    void Upgrade_2() 
    {
    Land_3.transform.position = new Vector3(0, 0, 0);
    Destroy(Land_2);
    }

    void Upgrade_3() 
    {
    Land_4.transform.position = new Vector3(0, 0, 0);
    Destroy(Land_3);
    }

    void Upgrade_4() 
    {
    Land_5.transform.position = new Vector3(0, 0, 0);
    Destroy(Land_4);
    }

    public void UpdateLandCoinDisplay(int amount)
    {
        UpgradeOneText.text = "Land: $" + amount;
    }

    public void UpdateDiceCoinDisplay(int amount)
    {
        UpgradeDiceText.text = "Dice: $" + amount;
    }

        public void UpdateLandLVDisplay(int amount)
    {
        levelTextLand.text = "Level " + amount;
    }

    public void UpdateDiceLVDisplay(int amount)
    {
        levelTextDice.text = "Level " + amount;
    }


    void rollDice()
    {
        int diceResult = random.Next(1, 7); // 1부터 6까지의 랜덤 숫자 생성
        resultText.text = "Dice Result: " + diceResult;
        if (diceResult == 6)
        {
            GameManager.instance.AddCoins(DiceCoin);
            Dicelevel++;
            DiceCost *= 2;
            DiceCoin *= 5;
            UpdateDiceLVDisplay(Dicelevel);
            UpdateDiceCoinDisplay(DiceCost);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{   
    public Text coinText;
    public Text coinText2;

    public int level = 1;
    public int upgradeCost = 100; // 업그레이드 비용
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
        //if (true)//GameManager.coins >= upgradeCost)
        //{
            GameManager.instance.SpendCoins(upgradeCost);
            level++;
            upgradeCost += 500; // 업그레이드 비용 증가
            Debug.Log("Land upgraded to level " + level);
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
        //}
        //else
        //{
        //    Debug.Log("Not enough coins to upgrade.");
        //}
    }
    public void SelectTwo ()
    {   
        objectToMoveBoat.transform.position = new Vector3(1f, -0.622f, -5f);
    }
    public void SelectThree ()
    {   

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

    public void UpdateCoinDisplay(int amount)
    {
        coinText.text = "" + amount;
        coinText2.text = "" + amount;
    }
}

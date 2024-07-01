using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{   
    //여기다가 When you choose one of three, it upgrade one of three, consume the gold. 
    //if you don't have enough money, print("You don't have enough money");
    public void SelectOne ()
    {   
        //delete this later
        Debug.Log ("UPGRADED @__!!");
    }

    public void QuitGame ()
    {
        Debug.Log ("GOT BACK");
        Application.Quit();
    }

}

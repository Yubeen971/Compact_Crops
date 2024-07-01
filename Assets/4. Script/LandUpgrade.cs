using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandUpgrade : MonoBehaviour
{
    public GameObject Land_1;
    public GameObject Land_2;
    public GameObject Land_3;
    public GameObject Land_4;
    public GameObject Land_5;


    // Start is called before the first frame update
    void Start()
    {
        Upgrade();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Upgrade() 
    {
    Land_2.transform.position = new Vector3(0, 0, 0);
    Destroy(Land_1);
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
}

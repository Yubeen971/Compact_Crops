using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasSFX : MonoBehaviour
{
    public AudioSource purchase;
    public AudioClip sfx1;

    public void button1()
    {
        purchase.clip = sfx1;
        purchase.Play();
    }

}

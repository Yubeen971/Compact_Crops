using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSfx : MonoBehaviour
{
    public AudioSource purchase;
    public AudioClip sfx1;

    public void Button1()
    {
        purchase.clip = sfx1;
        purchase.Play();
    }

}

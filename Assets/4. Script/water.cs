using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{
    public AudioSource waterAudio;

    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 객체가 플레이어인지 확인
        if (other.CompareTag("Player"))
        {
            waterAudio.Play();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToHome : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 객체가 플레이어인지 확인
        if (other.CompareTag("Player"))
        {
            // 플레이어의 위치를 (0, 0, 0)으로 변경
            other.transform.position = new Vector3(0, 0, 0);
        }
    }
}

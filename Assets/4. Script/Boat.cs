using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    public float maxSpeed = 5.0f;  // 최대 속도
    private float currentSpeed = 0.0f;  // 현재 속도
    public float acceleration = 0.5f;  // 가속도 (속도 증가량)
    private bool move = false;  // 움직임 상태

    void Update()
    {
        // 'J' 키를 눌렀을 때 움직임 시작
        if (Input.GetKeyDown(KeyCode.J))
        {
            move = true;
        }

        // 움직임 상태가 true이고, 현재 속도가 최대 속도보다 작은 경우
        if (move && currentSpeed < maxSpeed)
        {
            currentSpeed += acceleration * Time.deltaTime;  // 시간에 따라 속도 증가
            currentSpeed = Mathf.Min(currentSpeed, maxSpeed);  // 속도가 최대 속도를 초과하지 않도록 조정
        }

        // 움직임 상태이면 오브젝트를 왼쪽으로 이동
        if (move)
        {
            transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        }
    }
}

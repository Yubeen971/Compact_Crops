using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateAround : MonoBehaviour
{
    public Transform target; // 카메라가 바라볼 블록
    public float distance = 5.0f; // 블록과 카메라 사이의 거리
    public float rotationSpeed = 20.0f; // 회전 속도
    public float verticalAngle = 0.0f; // 수직 각도 조절
    public float initialHorizontalAngle = 85f; // 초기 수평 각도
    public float angleChangeSpeed = 30.0f; // 각도 변경 속도

    private float currentAngle;

    void Start()
    {
        // 초기 수평 각도를 설정
        currentAngle = initialHorizontalAngle;
    }

    void Update()
    {
        // 시계 방향으로 회전
        currentAngle += rotationSpeed * Time.deltaTime;

        // 수직 각도 조절 (위/아래 화살표 키로 조절)
        if (Input.GetKey(KeyCode.UpArrow))
        {
            verticalAngle += angleChangeSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            verticalAngle -= angleChangeSpeed * Time.deltaTime;
        }

        // 각도를 라디안으로 변환
        float horizontalRad = currentAngle * Mathf.Deg2Rad;
        float verticalRad = verticalAngle * Mathf.Deg2Rad;

        // 새로운 카메라 위치 계산
        float x = Mathf.Cos(horizontalRad) * distance;
        float z = Mathf.Sin(horizontalRad) * distance;
        float y = Mathf.Sin(verticalRad) * distance;
        Vector3 newPosition = new Vector3(x, y, z);

        // 카메라 위치 업데이트
        transform.position = newPosition + target.position;

        // 카메라가 항상 타겟을 바라보도록 설정
        transform.LookAt(target);
    }
}

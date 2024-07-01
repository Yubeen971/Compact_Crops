using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public GameObject textPanel; // UI 텍스트 패널을 할당하기 위한 변수
    public AudioSource audioSource; // 오디오 소스 컴포넌트를 할당하기 위한 변수

    void Start()
    {
        textPanel.SetActive(false); // 초기에 텍스트 패널을 숨깁니다.
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭 시
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == this.transform) // 표지판 클릭 검사
                {
                    textPanel.SetActive(!textPanel.activeSelf); // 텍스트 패널의 활성 상태를 토글
                    audioSource.Play(); // 오디오 재생
                }
            }
        }
    }
}

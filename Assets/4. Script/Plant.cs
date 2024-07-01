using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public int stage = 0; // 성장 단계
    public float[] stageDurations = new float[5]; // 각 단계별 필요 시간
    public GameObject[] models; // 각 성장 단계의 모델

    private float growthTimer = 0f;

    void Start() {
        ResetCrop(); // 초기 모델 설정
    }

    void Update() {
        growthTimer += Time.deltaTime;
        if (growthTimer >= stageDurations[stage]) {
            NextStage();
        }
    }

    void NextStage() {
        if (stage < 4) {
            stage++;
            growthTimer = 0;
            UpdateCropAppearance();
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && stage == 4) { // 최종 단계에서만 작동
            ResetCrop(); // 작물을 초기 단계로 리셋
        }   
    }


    void ResetCrop() {
        stage = 0;
        growthTimer = 0;
        UpdateCropAppearance();
    }

    void UpdateCropAppearance() {
        for (int i = 0; i < models.Length; i++) {
            models[i].SetActive(i == stage);
        }
    }
}


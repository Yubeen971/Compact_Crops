using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
public enum GrowthStage { Seed, Sprout, Growing, Mature, Harvestable }
    public GrowthStage stage = GrowthStage.Seed;
    public float[] stageDurations = new float[5]; // 각 단계별 필요 시간
    public GameObject[] models; // 각 성장 단계에 해당하는 모델 배열

    private float growthTimer = 0f;

    void Start() {
        UpdateCropAppearance(); // 초기 모델 설정
    }

    void Update() {
        growthTimer += Time.deltaTime;

        if (growthTimer >= stageDurations[(int)stage]) {
            NextStage();
        }
    }

    void NextStage() {
        if (stage < GrowthStage.Harvestable) {
            stage++;
            growthTimer = 0; // 타이머 초기화
            UpdateCropAppearance(); // 모델 업데이트
        }
    }

    void UpdateCropAppearance() {
        for (int i = 0; i < models.Length; i++) {
            // 모든 모델을 숨기고 현재 단계의 모델만 보이도록 설정
            models[i].SetActive(i == (int)stage);
        }
    }
}

using UnityEngine;

public class PlantableBlock : MonoBehaviour
{
    public GameObject[] cropStages;
    public float growthTime;
    private int currentStage = 0;
    private float timer = 0;
    private bool isPlanted = false;

    void Update()
    {
        if (isPlanted)
        {
            timer += Time.deltaTime;
            if (timer >= growthTime)
            {
                Grow();
            }
        }
    }

    public void PlantCrop(GameObject[] stages, float growthDuration)
    {
        cropStages = stages;
        growthTime = growthDuration;
        isPlanted = true;
        timer = 0;
        currentStage = 0;
        Instantiate(cropStages[currentStage], transform.position, Quaternion.identity, transform);
    }

    void Grow()
    {
        if (currentStage < cropStages.Length - 1)
        {
            currentStage++;
            timer = 0;
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            Instantiate(cropStages[currentStage], transform.position, Quaternion.identity, transform);
        }
    }

    public void Harvest()
    {
        if (currentStage == cropStages.Length - 1)
        {
            // Add coin logic here
            GameManager.instance.AddCoins(10); // Example coin amount
            isPlanted = false;
            currentStage = 0;
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }
    }

    private void OnMouseDown()
    {
        if (isPlanted && currentStage == cropStages.Length - 1)
        {
            Harvest();
        }
        else if (!isPlanted)
        {
            UIManager.instance.ShowPlantingUI(this);
        }
    }
}

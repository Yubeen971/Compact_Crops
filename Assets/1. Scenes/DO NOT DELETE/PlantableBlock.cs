using UnityEngine;

public class PlantableBlock : MonoBehaviour
{
    public GameObject[] cropStages;  // Prefabs for each growth stage of the crop
    public float growthTime;  // Time to grow from one stage to the next
    private int currentStage = 0;  // Current stage of growth
    private float timer = 0;  // Timer to track growth time
    private bool isPlanted = false;  // Whether the block has a planted crop
    public float plantOffsetY = 1f;  // The Y-axis offset for the planted crop

    public AudioSource harvest;
<<<<<<< Updated upstream
=======
    public AudioClip sfx2;
>>>>>>> Stashed changes

    void Update()
    {
        if (isPlanted)
        {
            timer += Time.deltaTime;
            if (timer >= growthTime && currentStage < cropStages.Length - 1)
            {
                Grow();
            }
        }
    }

    public void PlantCrop(GameObject[] stages, float growthDuration)
    {
        if (stages.Length == 0)
        {
            Debug.LogWarning("No crop stages provided!");
            return;
        }

        cropStages = stages;
        growthTime = growthDuration / (stages.Length - 1);  // Calculate time per stage
        isPlanted = true;
        timer = 0;
        currentStage = 0;

        Vector3 position = transform.position + new Vector3(0, plantOffsetY, 0);
        Instantiate(cropStages[currentStage], position, Quaternion.identity, transform);
    }

    void Grow()
    {
        currentStage++;
        timer = 0;

        // Destroy the current crop stage
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // Instantiate the next crop stage
        if (currentStage < cropStages.Length)
        {
            Vector3 position = transform.position + new Vector3(0, plantOffsetY, 0);
            Instantiate(cropStages[currentStage], position, Quaternion.identity, transform);
        }
    }

    public void Harvest()
    {
        if (currentStage == cropStages.Length - 1)
        {
            int coinAmount = 0;

            // Determine coin amount based on the crop type
            switch (cropStages[0].name)
            {
                case "tomStage1":
                    coinAmount = 14;  // Example coin amount for Tom crop   
                    break;
                case "leafStage1":
                    coinAmount = 3;  // Adjusted coin amount for Leaf crop
                    break;
                case "treeStage1":
                    coinAmount = 50;  // Adjusted coin amount for Tree crop
                    break;
                default:
                    coinAmount = 0;   // Default coin amount if not specified
                    break;
            }

            GameManager.instance.AddCoins(coinAmount);
            isPlanted = false;
            currentStage = 0;

            harvestsfx();

            // Destroy the crop
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
            harvest.Play();
            Harvest();
        }
        else if (!isPlanted)
        {
            UIManager.instance.ShowPlantingUI(this);
        }
    }

    public void harvestsfx()
    {
        harvest.clip = sfx2;
        harvest.Play();
    }
}

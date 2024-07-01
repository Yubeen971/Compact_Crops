using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject plantingPanel;
    public Text coinText;

    private PlantableBlock currentBlock;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowPlantingUI(PlantableBlock block)
    {
        currentBlock = block;
        plantingPanel.SetActive(true);
    }

    public void HidePlantingUI()
    {
        plantingPanel.SetActive(false);
    }

    public void PlantTom()
    {
        if (GameManager.instance.SpendCoins(6))  // Example cost
        {
            GameObject[] tomStages = Resources.LoadAll<GameObject>("tomStages");
            currentBlock.PlantCrop(tomStages, 5f);  // Example growth time
            HidePlantingUI();
        }
    }

    public void PlantLeaf()
    {
        if (GameManager.instance.SpendCoins(2))  // Example cost
        {
            GameObject[] leafStages = Resources.LoadAll<GameObject>("leafStages");
            currentBlock.PlantCrop(leafStages, 1f);  // Example growth time
            HidePlantingUI();
        }
    }

    public void UpdateCoinDisplay(int amount)
    {
        coinText.text = "Coins: " + amount;
    }
}

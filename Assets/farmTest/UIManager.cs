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

    public void PlantWheat()
    {
        if (GameManager.instance.SpendCoins(5)) // Example cost
        {
            currentBlock.PlantCrop(Resources.LoadAll<GameObject>("WheatStages"), 10f); // Example growth time
            HidePlantingUI();
        }
    }

    public void PlantCorn()
    {
        if (GameManager.instance.SpendCoins(10)) // Example cost
        {
            currentBlock.PlantCrop(Resources.LoadAll<GameObject>("CornStages"), 15f); // Example growth time
            HidePlantingUI();
        }
    }

    public void UpdateCoinDisplay(int amount)
    {
        coinText.text = "Coins: " + amount;
    }
}

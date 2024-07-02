using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject plantingPanel;
    public Text coinText;
    public Text coinText2;

    private PlantableBlock currentBlock;
    public AudioSource fail;
    public AudioSource plant;

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

    public void PlantTree()
    {
        if (GameManager.instance.SpendCoins(20))  // Example cost
        {
            plant.Play();
            GameObject[] treeStages = Resources.LoadAll<GameObject>("treeStages");
            currentBlock.PlantCrop(treeStages, 25f);  // Example growth time
            HidePlantingUI();
        }
        else
        {
            fail.Play();
        }
    }

    public void PlantTom()
    {
        if (GameManager.instance.SpendCoins(6))  // Example cost
        {
            plant.Play();
            GameObject[] tomStages = Resources.LoadAll<GameObject>("tomStages");
            currentBlock.PlantCrop(tomStages, 5f);  // Example growth time
            HidePlantingUI();
        }
        else
        {
            fail.Play();
        }
    }

    public void PlantLeaf()
    {
        if (GameManager.instance.SpendCoins(2))  // Example cost
        {
            plant.Play();
            GameObject[] leafStages = Resources.LoadAll<GameObject>("leafStages");
            currentBlock.PlantCrop(leafStages, 1f);  // Example growth time
            HidePlantingUI();
        }
        else
        {
            fail.Play();
        }
    }

    public void UpdateCoinDisplay(int amount)
    {
        coinText.text = "" + amount;
        coinText2.text = "" + amount;
    }
}

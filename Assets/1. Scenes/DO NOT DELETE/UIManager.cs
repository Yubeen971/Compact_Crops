using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //UI
    public static UIManager instance;
    public GameObject plantingPanel;

    //Outline
    public GameObject toma; // public으로 toma 오브젝트를 선언합니다.
    public GameObject leaf; // public으로 leaf 오브젝트를 선언합니다.
    public GameObject tree; // public으로 tree 오브젝트를 선언합니다.

    private Outline tomaOutline;
    private Outline leafOutline;
    private Outline treeOutline;




    //Coin
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
        DisableOutline(toma);
        DisableOutline(leaf);
        DisableOutline(tree);
        
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
    void Start()
    {
        // toma 오브젝트에서 Outline 컴포넌트를 가져옵니다.
        if (toma != null)
        {
            tomaOutline = toma.GetComponent<Outline>();
            if (tomaOutline == null)
            {
                Debug.LogError("toma 오브젝트에서 Outline 컴포넌트를 찾을 수 없습니다!");
            }
        }
        else
        {
            Debug.LogError("toma 오브젝트가 할당되지 않았습니다!");
        }

        // leaf 오브젝트에서 Outline 컴포넌트를 가져옵니다.
        if (leaf != null)
        {
            leafOutline = leaf.GetComponent<Outline>();
            if (leafOutline == null)
            {
                Debug.LogError("leaf 오브젝트에서 Outline 컴포넌트를 찾을 수 없습니다!");
            }
        }
        else
        {
            Debug.LogError("leaf 오브젝트가 할당되지 않았습니다!");
        }

        // tree 오브젝트에서 Outline 컴포넌트를 가져옵니다.
        if (tree != null)
        {
            treeOutline = tree.GetComponent<Outline>();
            if (treeOutline == null)
            {
                Debug.LogError("tree 오브젝트에서 Outline 컴포넌트를 찾을 수 없습니다!");
            }
        }
        else
        {
            Debug.LogError("tree 오브젝트가 할당되지 않았습니다!");
        }
    }

    // Outline을 활성화하는 메서드
    public void EnableOutline(GameObject obj)
    {
        Outline outline = obj.GetComponent<Outline>();
        if (outline != null)
        {
            outline.enabled = true;
        }
    }

    // Outline을 비활성화하는 메서드
    public void DisableOutline(GameObject obj)
    {
        Outline outline = obj.GetComponent<Outline>();
        if (outline != null)
        {
            outline.enabled = false;
        }
    }
}

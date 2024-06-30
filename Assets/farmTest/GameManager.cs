using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int coins = 100;

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

    public void AddCoins(int amount)
    {
        coins += amount;
        UIManager.instance.UpdateCoinDisplay(coins);
    }

    public bool SpendCoins(int amount)
    {
        if (coins >= amount)
        {
            coins -= amount;
            UIManager.instance.UpdateCoinDisplay(coins);
            return true;
        }
        return false;
    }
}

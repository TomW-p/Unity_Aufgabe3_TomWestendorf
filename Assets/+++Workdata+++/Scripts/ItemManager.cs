using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private int coinCount = 0;
    [SerializeField] private UIManager uIManager;
    private int bigCoinValue = 5;

    private void Start()
    {
        coinCount = 0;
        uIManager.UpdateCoinText(coinCount);
    }

    public void AddBigCoin()
    {
        coinCount+=bigCoinValue;
        uIManager.UpdateCoinText(coinCount);
    }

    public void AddCoin()
    {
        coinCount++;
        
        uIManager.UpdateCoinText(coinCount);
    }
}

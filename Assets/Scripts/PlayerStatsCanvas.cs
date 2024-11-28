using TMPro;
using UnityEngine;

public class PlayerStatsCanvas : MonoBehaviour
{
    public TextMeshProUGUI PlayerTowerHealthCount;

    public void UpdateTowerHealthText(int newHealth)
    {
        PlayerTowerHealthCount.text = newHealth.ToString();
    }
}

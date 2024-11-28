using UnityEngine;
using UnityEngine.UI;

public class EndGameCanvas : MonoBehaviour
{
    public GameObject WinScreen;
    public GameObject LoseScreen;
    public Button TryAgainButton;
    public LevelChanger levelChanger;

    private void Start()
    {
        levelChanger = FindObjectOfType<LevelChanger>();
        TryAgainButton.onClick.AddListener(levelChanger.ReloadLevel);
        TryAgainButton.gameObject.SetActive(false);
    }

    public void TurnOnWinScreen()
    {
        WinScreen.SetActive(true);
        TryAgainButton.gameObject.SetActive(true);
    }

    public void TurnOnLoseScreen()
    {
        LoseScreen.SetActive(true);
        TryAgainButton.gameObject.SetActive(true);
    }
}

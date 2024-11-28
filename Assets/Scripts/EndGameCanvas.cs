using UnityEngine;

public class EndGameCanvas : MonoBehaviour
{
    public GameObject WinScreen;
    public GameObject LoseScreen;

    public void TurnOnWinScreen()
    {
        WinScreen.SetActive(true);
    }

    public void TurnOnLoseScreen()
    {
        LoseScreen.SetActive(true);
    }
}

using UnityEngine;
using UnityEngine.UI;

public class CanvasChanger : MonoBehaviour
{
    public GameObject CanvasOn;
    public GameObject CanvasOff;

    public Button Button;

    private void Start()
    {
        Button.onClick.AddListener(ChangeCanvas);
    }

    public void ChangeCanvas()
    {
        CanvasOff.SetActive(false);
        CanvasOn.SetActive(true);
    }
}

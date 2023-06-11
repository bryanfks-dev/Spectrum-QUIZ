using UnityEngine;

public class SwitchCanvas : MonoBehaviour
{
    private GameObject fromCanvas;
    public GameObject targetCanvas;

    // Start is called before the first frame update
    public void Start()
    {
        // Get attached canvas
        fromCanvas = transform.parent.gameObject;
    }

    // Method to switch canvas
    public void doSwitchCanvas()
    {
        // Toggle canvas active status
        targetCanvas.SetActive(!targetCanvas.activeSelf);
        fromCanvas.SetActive(!fromCanvas.activeSelf);
    }
}

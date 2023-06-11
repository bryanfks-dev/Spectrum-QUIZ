using UnityEngine;

public class PlayButton : MonoBehaviour
{
    private GameObject fromCanvas;
    public GameObject targetCanvas;

    public GameManager gameManager;

    // Start is called before the first frame update
    public void Start()
    {
        // Get attached canvas
        fromCanvas = transform.parent.gameObject;
    }

    public void startGame()
    {
        // Generate a question after swapping to in game canvas
        gameManager.generateQuestion();

        gameManager.modelRenderer.object_spawned = false;

        // Toggle canvas active status
        targetCanvas.SetActive(!targetCanvas.activeSelf);
        fromCanvas.SetActive(!fromCanvas.activeSelf);
    }
}

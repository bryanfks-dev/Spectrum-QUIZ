using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    public Button pauseButton;
    public GameObject lightPanel;

    private GameObject inGameSection;
    public GameObject SettingInGameSection;

    // Start is called before the first frame update
    public void Start()
    {
        // Get attached canvas
        inGameSection = transform.parent.gameObject;
        inGameSection = transform.parent.gameObject;
        inGameSection = transform.parent.gameObject;
    }

    // Exit to main menu method
    public void toMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Switch canvas to in game setting method
    public void toInGameSetting()
    {
        // Show in game setting canvas
        SettingInGameSection.SetActive(true);

        // Hide in game canvas
        inGameSection.SetActive(false);
    }

    // Toggle active panel method
    public void togglePanel()
    {
        // Toggle active panel gameobject property
        lightPanel.SetActive(!lightPanel.activeSelf);

        // Toggle interactable button property
        pauseButton.interactable = !pauseButton.interactable;
    }
}

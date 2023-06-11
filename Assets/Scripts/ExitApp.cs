using UnityEngine;
using UnityEngine.UI;

public class ExitApp : MonoBehaviour
{
    public Button playButton;
    public Button exitButton;
    public Button settingButton;
    public GameObject dimPanel;

    // Toggle active panel method
    public void togglePanel()
    {
        // Toggle active panel gameobject property
        dimPanel.SetActive(!dimPanel.activeSelf);

        // Toggle interactable button property
        playButton.interactable = !playButton.interactable;
        exitButton.interactable = !exitButton.interactable;
        settingButton.interactable = !settingButton.interactable;
    }

    // Close application method
    public void QuitApp()
    {
        // Quit application
        Application.Quit();
    }
}

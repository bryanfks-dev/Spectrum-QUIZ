using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SettingController : MonoBehaviour
{
    public Toggle sfxToggle;

    // Update is called once per frame
    void Update()
    {
        // Fetch old data from config file
        string json = File.ReadAllText(Application.persistentDataPath + "/config.json");
        ConfigData old_data = JsonUtility.FromJson<ConfigData>(json);

        // Set toggle value depends on saved value
        sfxToggle.isOn = old_data.sfx_audio_is_on;
    }

    // Method to save new value to config file
    public void saveToConfig()
    {
        // Create config data object
        ConfigData new_data = new ConfigData();

        // Set sfx_audio_is_on and audio_volume value depends on current value
        new_data.sfx_audio_is_on = sfxToggle.isOn;

        // Save new value to config file
        string json = JsonUtility.ToJson(new_data, true);
        File.WriteAllText(Application.persistentDataPath + "/config.json", json);
    }
}

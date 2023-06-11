using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    public GameObject score;

    // Update is called once per frame
    void Update()
    {
        // Fetch old data from player file
        string json = File.ReadAllText(Application.persistentDataPath + "/player.json");
        Player old_data = JsonUtility.FromJson<Player>(json);

        // Set highest score title depends on fetched data
        score.GetComponent<Text>().text = old_data.highestScore.ToString();
    }
}

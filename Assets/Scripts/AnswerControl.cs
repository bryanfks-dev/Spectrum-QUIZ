using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class AnswerControl : MonoBehaviour
{
    public GameObject correctImg;
    public GameObject incorrectImg;

    public AudioSource audioSource;
    public AudioClip correctAudio;
    public AudioClip incorrectAudio;

    public bool isCorrect = false;
    public GameManager gameManager;
    public Raycast modelRenderer;

    public GameObject point;

    private ConfigData config;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        // Make a config and player object
        config = new ConfigData();

        player = new Player();
    }

    // Update is called once per frame
    void Update()
    {
        // Fetch old data from config and player file
        string configJson = File.ReadAllText(Application.persistentDataPath + "/config.json");
        config = JsonUtility.FromJson<ConfigData>(configJson);

        string playerJson = File.ReadAllText(Application.persistentDataPath + "/player.json");
        player = JsonUtility.FromJson<Player>(playerJson);
    }

    private void hideCorrectMark()
    {
        correctImg.SetActive(false);
    }
    private void hideIncorrectMark()
    {
        incorrectImg.SetActive(false);
    }

    // Method to handle answer input
    public void answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct"); // Correct indicator <<Only appears in unity editor>>>

            // Show mark image
            correctImg.SetActive(true);

            // Check if sfx audio is allowed, if yes play sound
            if (config.sfx_audio_is_on) audioSource.PlayOneShot(correctAudio);

            // Add player point
            int currentScore = int.Parse(point.GetComponent<Text>().text) + 1;

            point.GetComponent<Text>().text = currentScore.ToString();

            // Check the highest player score
            if (currentScore > player.highestScore)
            {
                player.highestScore = currentScore;

                // Update highest score to current score
                string json = JsonUtility.ToJson(player, true);
                File.WriteAllText(Application.persistentDataPath + "/player.json", json);
            }

            // Hide mark image
            Invoke("hideCorrectMark", 1);

            // Roll to a new question
            gameManager.generateQuestion();
        }
        else
        {
            Debug.Log("Incorrect"); // Incorrect indicator <<Only appears in unity editor>>>

            // Show mark image
            incorrectImg.SetActive(true);

            // Check if sfx audio is allowed, if yes play sound
            if (config.sfx_audio_is_on) audioSource.PlayOneShot(incorrectAudio);

            // Hide mark image
            Invoke("hideIncorrectMark", 1);
        }
    }
}

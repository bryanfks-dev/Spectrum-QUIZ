using UnityEngine;

[System.Serializable] // Player class
public class Player
{
    public int highestScore = 0;
}

[System.Serializable] // Config data class
public class ConfigData
{
    public bool sfx_audio_is_on = true;
}

[System.Serializable]
public class Questions // Question class
{
    public string[] answer;
    public int correctAnswer;
    public GameObject model3D;
}
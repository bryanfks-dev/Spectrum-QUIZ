using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Raycast modelRenderer;

    public GameObject alertText;

    public List<Questions> QnA;
    public GameObject[] options;
    public int currentQuestion;

    // Method to generate random question and model
    public void generateQuestion()
    {
        // Pick a random number between 0 to question count
        currentQuestion = Random.Range(0, QnA.Count);

        // Render 3D model
        modelRenderer.spawn_prefabs = QnA[currentQuestion].model3D;

        if (modelRenderer.spawned_object != null)
        {
            Destroy(modelRenderer.spawned_object);

            modelRenderer.spawned_object = Instantiate(modelRenderer.spawn_prefabs, modelRenderer.fixedPose.position, modelRenderer.fixedPose.rotation);

            modelRenderer.spawned_object.transform.LookAt(new Vector3(modelRenderer.cam.transform.position.x, modelRenderer.fixedPose.position.y, modelRenderer.cam.transform.position.z));
        }

        // Set options for current question
        setAnswers();
    }

    // Method for generate answers for a question
    void setAnswers()
    {
        for (int counter = 0; counter < options.Length; counter++)
        {
            // Set current option to false
            options[counter].GetComponent<AnswerControl>().isCorrect = false;

            // Set current option text
            options[counter].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].answer[counter];

            // Set current option to true
            if (QnA[currentQuestion].correctAnswer == counter)
            {
                options[counter].GetComponent<AnswerControl>().isCorrect = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        alertText.SetActive(!modelRenderer.object_spawned);

        for (int counter = 0; counter < options.Length; counter++)
        {
            options[counter].transform.GetComponent<Button>().interactable = modelRenderer.object_spawned;
        }
    }
}

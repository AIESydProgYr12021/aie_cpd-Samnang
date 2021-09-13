using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoringSystem : MonoBehaviour
{
    public GameObject scoreText;
    public GameObject winTexrt;

    public static int theScore = 0;

    void Start()
    {
        winTexrt.SetActive(false);
        theScore = 0;
    }

    void Update()
    {
        scoreText.GetComponent<Text>().text = "SCORE: " + theScore;

        if(theScore >= 200)
        {
            winTexrt.SetActive(true);
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Bomberman");
    }
}

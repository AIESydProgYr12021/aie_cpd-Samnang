using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    public GameObject scoreText;
    public GameObject winTexrt;

    public static int theScore;

    void Start()
    {
        winTexrt.SetActive(false);
    }

    void Update()
    {
        scoreText.GetComponent<Text>().text = "SCORE: " + theScore;

        if(theScore >= 200)
        {
            winTexrt.SetActive(true);
        }
    }
}

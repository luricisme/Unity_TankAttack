using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int ScoreScene = 0;
    Text score;

    private void Start()
    {
        ScoreScene = 0;
        score = GetComponent<Text>();
    }

    void Update()
    {
        score.text = "Score: " + ScoreScene;
    }


    public void SaveScore()
    {
        PlayerPrefs.SetInt("ScoreScene", ScoreScene);
        PlayerPrefs.Save();
    }


    public void LoadScore()
    {
        if (PlayerPrefs.HasKey("ScoreScene"))
        {
            ScoreScene = PlayerPrefs.GetInt("ScoreScene");
        }
    }
}

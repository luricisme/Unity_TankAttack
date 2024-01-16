using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TImeOut : MonoBehaviour
{
    public string leveltoLoad;
    private float timer = 300f;
    private Text timerSeconds;

     void Start()
    {
        timerSeconds=GetComponent<Text>();
    }
    private void Update()
    {
        timer-= Time.deltaTime;
        timerSeconds.text = timer.ToString("f2");
        if(timer <=0)
        {
            ScoreScript scoreScript = FindObjectOfType<ScoreScript>();
            scoreScript.SaveScore();
            Destroy(gameObject);
            SceneManager.LoadScene(4);
        }
    }

}

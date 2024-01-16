using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseBehavior : MonoBehaviour
{
    public void DestroyHelper()
    {
        ScoreScript scoreScript = FindObjectOfType<ScoreScript>();
        scoreScript.SaveScore();
        Destroy(gameObject);
        SceneManager.LoadScene(7);
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{
    public void LV1()
    {

        SceneManager.LoadScene(4);

    }

    public void LV2()
    {
        SceneManager.LoadScene(5);

    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void Ranking()
    {
        SceneManager.LoadScene(8);
    }

    public void GameMode()
    {
        SceneManager.LoadScene(2);
    }

    public void AboutUs() 
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
    public void Instruction()
    {
        SceneManager.LoadScene(3);
    }

    public void Quit()
    {
        Application.Quit();
    }
}





using UnityEngine.SceneManagement;
using UnityEngine;

public class mainmenu : MonoBehaviour
{
 public void GoToScene()
    {

        string str = "Level0_" + 0;//Random.Range(0, 3);
        print("Scene: " + str);
        SceneManager.LoadScene(str);
    }
    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }
    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("Application Quit");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main");
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus_Logic : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}

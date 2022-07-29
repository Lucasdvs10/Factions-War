using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunctions : MonoBehaviour
{
    [SerializeField] int mainSceneIndex = 0;

    //Loads the scene on the indexed location set on mainSceneIndex from the build.
    public void SceneLoader()
    {
        SceneManager.LoadScene(mainSceneIndex);
    }

    //Closes the application.
    public void QuitGame()
    {
        Debug.Log("Quitted game!");
        Application.Quit();
    }
}

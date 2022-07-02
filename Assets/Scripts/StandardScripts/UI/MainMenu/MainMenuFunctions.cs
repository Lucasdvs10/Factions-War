using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunctions : MonoBehaviour
{
    [SerializeField] int mainSceneIndex = 0;
    [SerializeField] Component playSound;

    //Loads the scene on the indexed location set on mainSceneIndex from the build.
    public void MainSceneLoader()
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

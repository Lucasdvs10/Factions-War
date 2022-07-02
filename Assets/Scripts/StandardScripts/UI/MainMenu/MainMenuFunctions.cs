using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunctions : MonoBehaviour
{
    [SerializeField] int _mainSceneIndex = 0;

    //Loads the scene on the indexed location set on mainSceneIndex from the build.
    public void MainSceneLoader()
    {
        SceneManager.LoadScene(_mainSceneIndex);
    }

    //Closes the application.
    public void QuitGame()
    {
        Debug.Log("Quitted game!");
        Application.Quit();
    }
}

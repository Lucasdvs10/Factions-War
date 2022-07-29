using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadSceneAfterDelay : MonoBehaviour
{
    [SerializeField] int mainSceneIndex = 0;

    //Loads the scene on the indexed location set on mainSceneIndex from the build.

    private IEnumerator SceneLoader()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(mainSceneIndex);
    }

    public void CallSceneLoader()
    {
        StartCoroutine(SceneLoader());

    }

}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingleSceneLoader : MonoBehaviour
{
    private float dotTimeTracker = 0f;
    private int _dotCounter = 0; 

    private void Start()
    {
        StartCoroutine(MainSceneLoader(AppGlobals.PRIMARY_PLATFORM));
    }

    private IEnumerator MainSceneLoader(string nameScene)
    {
        AsyncOperation asyncTask = SceneManager.LoadSceneAsync(nameScene);

        asyncTask.allowSceneActivation = false;

        while (!asyncTask.isDone)
        {
            if (asyncTask.progress >= 0.9f)
            {
                asyncTask.allowSceneActivation = true;
            }

            yield return null;
        }
    }

        
}
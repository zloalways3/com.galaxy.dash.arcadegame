using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    public void BootSplashScreen()
    {
        SceneManager.LoadScene(AppGlobals.INITIALIZATION_PHASE);
    }
    public void GameSceneLoader()
    {
        SceneManager.LoadScene(AppGlobals.ADVENTURE_ARENA);
    }
        
}
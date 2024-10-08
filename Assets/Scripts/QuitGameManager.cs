using UnityEngine;

public class QuitGameManager : MonoBehaviour
{ 
    public void QuitApplication()
    {
#if UNITY_EDITOR
        
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
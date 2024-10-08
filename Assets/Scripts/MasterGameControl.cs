using UnityEngine;

public class MasterGameControl : MonoBehaviour
{
    public static MasterGameControl singletonInstance;

    private int _livesCount = 3;
        
    [SerializeField]
    private GameObject _audioPlayer;
    [SerializeField]
    private GameObject _defeatMenu;
    [SerializeField]
    private GameObject _menuScreen;
    
    private void Awake()
    {
        singletonInstance = this;
    }

    public void DeductLife()
    {
        _livesCount--;

        if (_livesCount <= 0)
        {
            TerminateGame();
        }
    }
    
    private void TerminateGame()
    {
        _audioPlayer.GetComponent<CharacterControl>().enabled = false;
        _defeatMenu.SetActive(true);
        _menuScreen.SetActive(false);
        Time.timeScale = 0;
    }
}
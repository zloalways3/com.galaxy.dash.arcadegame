using TMPro;
using UnityEngine;

public class GameplaySceneManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _levelDisplayText;
        
    private int _activeLevel;
        
    private void Start()
    {
        _activeLevel = PlayerPrefs.GetInt(AppGlobals.ACTIVE_STAGE_INDEX, 0);
            
        for (int indexCounter = 0; indexCounter < _levelDisplayText.Length; indexCounter++)
        {
            _levelDisplayText[indexCounter].text = $"Level {_activeLevel+1}";
        }
    }

    public void CompleteGame()
    {
        PlayerPrefs.SetInt(AppGlobals.ACTIVE_STAGE_INDEX, _activeLevel+1);
        PlayerPrefs.Save();
        StageSupervisor stageManager = FindObjectOfType<StageSupervisor>();
        stageManager.LevelVictory(_activeLevel);
    }
        
    public void TimeFlowEnable()
    {
        Time.timeScale = 1f;
    }
    
    public void TimeFlowDisable()
    {
        Time.timeScale = 0f;
    }
}
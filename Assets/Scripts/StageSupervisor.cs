using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSupervisor : MonoBehaviour
{
    public static StageSupervisor globalInstance;

    [SerializeField] private GameObject[] _stageButtons;
    [SerializeField] private TextMeshProUGUI[] _levelTexts;
    [SerializeField] private Image[] _levelStars;
    [SerializeField] private Button _selectButton;
    [SerializeField] private Sprite _openLevelSprite;
    [SerializeField] private Sprite _closedLevelSprite;
    [SerializeField] private Sprite _completedStarSprite;
    [SerializeField] private Sprite _selectedButton;     
    [SerializeField] private Color _selectedColor;       
    [SerializeField] private Color _defaultColor;        
    private int _levelsTotalCount = 24;
    private int _selectedLevelIndex;

    void Start()
    {
        if (globalInstance == null)
        {
            globalInstance = this;
            DontDestroyOnLoad(gameObject);
        }

        SetupGameLevels();
        RefreshLevelButtons();
        _selectButton.interactable = false;
    }
        
    private void SetupGameLevels()
    {
        for (int counterIndex = 0; counterIndex < _levelsTotalCount; counterIndex++)
        {
            if (!PlayerPrefs.HasKey(AppGlobals.PROGRESSION_TIER + counterIndex))
            {
                PlayerPrefs.SetInt(AppGlobals.PROGRESSION_TIER + counterIndex, counterIndex == 0 ? 1 : 0);
            }
        }
        PlayerPrefs.Save();
    }
        
    private void RefreshLevelButtons()
    {
        for (int counterIndex = 0; counterIndex < _levelsTotalCount; counterIndex++)
        {
            if (_stageButtons[counterIndex] != null && _stageButtons[counterIndex].GetComponent<Image>() != null)
            {
                if (PlayerPrefs.GetInt(AppGlobals.PROGRESSION_TIER + counterIndex, 0) == 1)
                {
                    if (_stageButtons[counterIndex].GetComponent<Button>() != null)
                    {
                        _stageButtons[counterIndex].GetComponent<Button>().interactable = true;
                    }
                    _stageButtons[counterIndex].GetComponent<Image>().sprite = _openLevelSprite;
                        
                    if (_levelStars[counterIndex] != null && PlayerPrefs.GetInt("LevelCompleted" + counterIndex, 0) == 1)
                    {
                        _levelStars[counterIndex].sprite = _completedStarSprite;
                    }
                }
                else
                {
                    _stageButtons[counterIndex].GetComponent<Image>().sprite = _closedLevelSprite;
                    if (_levelTexts[counterIndex] != null)
                    {
                        _levelTexts[counterIndex].text = "";
                    }
                        
                    if (_stageButtons[counterIndex].GetComponent<Button>() != null)
                    {
                        Destroy(_stageButtons[counterIndex].GetComponent<Button>());
                    }
                }
            }
        }
    }
        
    public void SelectLevel(int levelIndex)
    {
        if (_selectedLevelIndex != -1)
        {
            if (_stageButtons[_selectedLevelIndex] != null && _stageButtons[_selectedLevelIndex].GetComponent<Image>() != null)
            {
                _stageButtons[_selectedLevelIndex].GetComponent<Image>().sprite = _openLevelSprite;
            }

            if (_levelTexts[_selectedLevelIndex] != null)
            {
                _levelTexts[_selectedLevelIndex].color = new Color(_defaultColor.r,_defaultColor.g,_defaultColor.b);
            }
        }
            
        _selectedLevelIndex = levelIndex;
            
        if (_stageButtons[_selectedLevelIndex] != null && _stageButtons[_selectedLevelIndex].GetComponent<Image>() != null)
        {
            _stageButtons[_selectedLevelIndex].GetComponent<Image>().sprite = _selectedButton;
        }

        if (_levelTexts[_selectedLevelIndex] != null)
        {
            _levelTexts[_selectedLevelIndex].color = new Color(_selectedColor.r,_selectedColor.g,_selectedColor.b);
        }

        _selectButton.interactable = true;
    }
        
    public void StartSelectedLevel()
    {
        if (_selectedLevelIndex != -1)
        {
            PlayerPrefs.SetInt(AppGlobals.ACTIVE_STAGE_INDEX, _selectedLevelIndex);
            PlayerPrefs.Save();
            SceneManager.LoadScene(AppGlobals.ADVENTURE_ARENA);
        }
    }
        
    public void LevelVictory(int levelIndex)
    {
        PlayerPrefs.SetInt("LevelCompleted" + levelIndex, 1);
            
        if (levelIndex < _levelsTotalCount - 1)
        {
            PlayerPrefs.SetInt(AppGlobals.PROGRESSION_TIER + (levelIndex + 1), 1);
        }

        PlayerPrefs.Save();
            
        if (_levelStars[levelIndex] != null)
        {
            _levelStars[levelIndex].sprite = _completedStarSprite;
        }
            
        RefreshLevelButtons();
    }
}
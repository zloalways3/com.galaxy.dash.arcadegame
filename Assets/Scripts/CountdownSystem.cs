using UnityEngine;
using UnityEngine.UI;

public class CountdownSystem : MonoBehaviour
{
    [SerializeField] private Image _imageFill;
    [SerializeField] private GameObject _complete;
    [SerializeField] private GameObject _entityObject;
    
    private float _remainingTime = 60f;
    private bool _timerIsActive = false;

    private void Start()
    {
        _timerIsActive = true;
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (_timerIsActive)
        {
            if (_remainingTime > 0)
            {
                _remainingTime -= Time.deltaTime;
                _imageFill.fillAmount = _remainingTime / 60f;
            }
            else
            {
                _remainingTime = 0;
                _timerIsActive = false;
                _complete.SetActive(true);
                _entityObject.SetActive(false);
                Time.timeScale = 0f;
            }
        }
    }
}
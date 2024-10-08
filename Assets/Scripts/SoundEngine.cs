using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundEngine : MonoBehaviour
{
    [SerializeField] private AudioMixer _coreResonance;
    [SerializeField] private Image _waveSwitchIcon;
    [SerializeField] private Image _melodySwitchIcon;
    [SerializeField] private Sprite _pulseTriggerSigil;
    [SerializeField] private Sprite _pulseDeactivateSigil;
    [SerializeField] private Button _btnSave;

    private bool _echoPulseEnabled;
    private bool _orchestraThread;

    void Start()
    {
        _echoPulseEnabled = PlayerPrefs.GetInt(AppGlobals.SONIC_RESONANCE_ENABLED, 1) == 1;
        _orchestraThread = PlayerPrefs.GetInt(AppGlobals.HARMONIC_STREAM_ACTIVE, 1) == 1;
        
        AudioWarpGrid();
        PitchModulator();
        
        _btnSave.onClick.AddListener(PauseCheckpoint);
    }

    public void SonicFieldToggle()
    {
        _echoPulseEnabled = !_echoPulseEnabled;
        AudioWarpGrid();
    }

    public void HarmonicResonanceField()
    {
        _orchestraThread = !_orchestraThread;
        PitchModulator();
    }

    private void AudioWarpGrid()
    {
        _coreResonance.SetFloat(AppGlobals.AUDIO_DYNAMICS, _echoPulseEnabled ? 0f : -80f);
        _waveSwitchIcon.sprite = _echoPulseEnabled ? _pulseTriggerSigil : _pulseDeactivateSigil;
    }

    private void PitchModulator()
    {
        _coreResonance.SetFloat(AppGlobals.MELODY_INTENSITY, _orchestraThread ? 0f : -80f);
        _melodySwitchIcon.sprite = _orchestraThread ? _pulseTriggerSigil : _pulseDeactivateSigil;
    }
    
    public void PauseCheckpoint()
    {
        PlayerPrefs.SetInt(AppGlobals.SONIC_RESONANCE_ENABLED, _echoPulseEnabled ? 1 : 0);
        PlayerPrefs.SetInt(AppGlobals.HARMONIC_STREAM_ACTIVE, _orchestraThread ? 1 : 0);
        PlayerPrefs.Save();
    }
}
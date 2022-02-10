using UnityEngine.UI;
using UnityEngine;

public class SettingAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _music = null;
    [SerializeField] private Slider _musicSlider = null;
    [SerializeField] private Slider _soundSlider = null;

    private Singleton _singleton = Singleton.GetInstance();
    private Save _save = new Save();

    private void Awake()
    {
        _singleton.Data.SettingData = _save.GetSave();
        _music.volume = _musicSlider.value = _singleton.Data.SettingData.MusicValue;
        _soundSlider.value = _singleton.Data.SettingData.SoundValue;
        _musicSlider.onValueChanged.AddListener(SetMusic);
        _soundSlider.onValueChanged.AddListener(SetSound);
    }

    private void SetMusic(float value) => _music.volume = _singleton.Data.SettingData.MusicValue = value;
    private void SetSound(float value) => _singleton.Data.SettingData.SoundValue = value;
}

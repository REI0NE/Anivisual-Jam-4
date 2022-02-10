using UnityEngine;

[System.Serializable]
public class SettingData
{
    [SerializeField] private float _musicValue = .5f;
    [SerializeField] private float _soundValue = .5f;
    [SerializeField] private int _countUnclockAct = 0;

    public float MusicValue { get => _musicValue; set => _musicValue = value; }
    public float SoundValue { get => _soundValue; set => _soundValue = value; }
    public int CountUnlockAct { get => _countUnclockAct; set => _countUnclockAct = value; }

}

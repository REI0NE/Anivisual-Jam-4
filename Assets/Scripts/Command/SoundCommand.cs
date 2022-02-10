using UnityEngine;
using Fungus;

[CommandInfo("MyScript","Sound Play","")]
public class SoundCommand : Command
{
    [SerializeField] private string _nameSound = null;
    [SerializeField] private float _time = 3f;

    private Audio _audio = null;

    private void Awake() => _audio ??= FindObjectOfType<Audio>();

    public override void OnEnter()
    {
        if (!string.IsNullOrEmpty(_nameSound))
            _audio.SwitchSound(_nameSound, _time);

        Continue();
    }
}

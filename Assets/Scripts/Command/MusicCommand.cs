using UnityEngine;
using Fungus;

[CommandInfo("MyScript", "Music Play", "")]
public class MusicCommand : Command
{
    [SerializeField] private string _nameMusic = null;
    [SerializeField] private float _speed = 3f;

    private Audio _audio = null;

    private void Awake() => _audio ??= FindObjectOfType<Audio>();

    public override string GetSummary() => "Play " + _nameMusic;

    public override void OnEnter()
    {
        if (!string.IsNullOrEmpty(_nameMusic))
            _audio.SwitchMusic(_nameMusic, _speed);

        Continue();
    }
}

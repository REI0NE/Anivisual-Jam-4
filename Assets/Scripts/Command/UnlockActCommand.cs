using UnityEngine.SceneManagement;
using UnityEngine;
using Fungus;

[CommandInfo("MyScript", "Unlock act", "")]
public class UnlockActCommand : Command
{
    [SerializeField] private int _unlockAct = 0;
    private Singleton _singleton = Singleton.GetInstance();
    private Save _save = new Save();

    public override void OnEnter()
    {
        _singleton.Data.SettingData.CountUnlockAct = _unlockAct;
        _save.SetSave(_singleton.Data.SettingData);
        SceneManager.LoadScene(0);
        Continue();
    }

}

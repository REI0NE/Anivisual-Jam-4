using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UnlockButtonAct : MonoBehaviour
{
    [SerializeField] private List<Sprite> _spriteUnlock = null;

    private List<Button> _buttons = null;
    private Singleton _singleton = Singleton.GetInstance();
    private Save _save = new Save();

    private void Awake() => _buttons ??= new List<Button>(GetComponentsInChildren<Button>());

    private void Start()
    {
        _buttons.Remove(_buttons[_buttons.Count - 1]);
        for (int i = 0; i < _buttons.Count; i++)
        {
            _buttons[i].interactable = i <= _singleton.Data.SettingData.CountUnlockAct;
            _buttons[i].GetComponentsInChildren<Image>()[2].sprite = _spriteUnlock[System.Convert.ToInt32(i <= _singleton.Data.SettingData.CountUnlockAct)];
            int index = i;
            _buttons[i].onClick.AddListener(() => OnButtonClick(index));
        }
    }

    private void OnButtonClick(int act)
    {
        _singleton.Data.SelectAct = act;
        _save.SetSave(_singleton.Data.SettingData);
        SceneManager.LoadScene(1);
    }

    public void Save() => _save.SetSave(_singleton.Data.SettingData);
}

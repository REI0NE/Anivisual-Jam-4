using UnityEngine;

public class Save
{
    private string _FileName = "The_question_of_death";
    
    public void SetSave(SettingData settingData)
    {
        PlayerPrefs.SetString(_FileName, JsonUtility.ToJson(settingData));
        PlayerPrefs.Save();
    }

    public SettingData GetSave()
    {
        if (PlayerPrefs.HasKey(_FileName))
        {
            string tmp = PlayerPrefs.GetString(_FileName);
            return JsonUtility.FromJson<SettingData>(tmp);
        }

        return new SettingData();
    }
}

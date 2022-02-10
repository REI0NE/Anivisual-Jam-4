
public class Data
{
    private int _selectAct = 0;
    public int SelectAct { get => _selectAct; set => _selectAct = value; }

    private SettingData _settingData = new SettingData();
    public SettingData SettingData { get => _settingData; set => _settingData = value; }
}
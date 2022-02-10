using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class MessageControl : MonoBehaviour
{
    [SerializeField] private Message _message;
    [SerializeField] private Transform _content;
    [SerializeField] private int _messageLimit = 50;
    [SerializeField] private string _nameSound = null;

    private HorizontalLayoutGroup _horizontalLayoutGroup = null;
    private List<Message> _messList = null;
    private Audio _audio = null;

    private void Awake()
    {
        _horizontalLayoutGroup = _message.GetComponent<HorizontalLayoutGroup>();
        _messList ??= new List<Message>(_messageLimit);
        _audio ??= FindObjectOfType<Audio>();
    }

    public void Show(string str = null, Side side = Side.AI)
    {
        _horizontalLayoutGroup.childAlignment = side == Side.AI ? TextAnchor.UpperRight : TextAnchor.UpperLeft;
        if (side == Side.End)
            _horizontalLayoutGroup.childAlignment = TextAnchor.UpperCenter;

        Message message = Instantiate(_message, _content);
        TextMeshProUGUI textMeshProUGUI = message.GetComponentInChildren<TextMeshProUGUI>();
        textMeshProUGUI.text = str;
        textMeshProUGUI.alignment = side == Side.AI ? TextAlignmentOptions.TopRight : TextAlignmentOptions.TopLeft;
        if (side == Side.End)
            textMeshProUGUI.alignment = TextAlignmentOptions.Top;
        message.gameObject.SetActive(true);

        if (!string.IsNullOrEmpty(_nameSound))
            if (_audio != null)
                if (side == Side.User)
                    _audio.OneShot(_nameSound);

        if (_messList.Count >= _messageLimit)
        {
            Message messageFirst = _messList[0];
            _messList.Remove(messageFirst);
            Destroy(messageFirst.gameObject);
        }
        _messList.Add(message);
    }
}

using UnityEngine;
using Fungus;

[CommandInfo("MyScript", "Message", "")]
public class MessageCommand : Command
{
    [SerializeField] private Side _side = Side.AI;
    [TextArea(5, 10)]
    [SerializeField] private string _text = null;

    private MessageControl _messageControl = null;

    private void Awake() => _messageControl ??= FindObjectOfType<MessageControl>();
    public override void OnEnter() => _messageControl.Show(_text, _side);

    public override string GetSummary() => _side + " : " + _text;

    private void LateUpdate()
    {
        if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space))
            Continue();
    }
}
public enum Side
{
    User,
    AI,
    End
}

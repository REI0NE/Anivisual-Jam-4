using System.Collections;
using UnityEngine;
using Fungus;

[CommandInfo("MyScript", "CanvasGroup", "")]
public class CanvasGroupAlpfa : Command
{
    [SerializeField] private CanvasGroup _canvasGroup = null;
    [SerializeField]
    [Range(.1f, 1)] private float _speed = 1f;
    [SerializeField] private bool _visible = true;

    public override void OnEnter()
    {
        if (_canvasGroup != null) StartCoroutine(Coroutine());
        else Continue();
    }

    public override string GetSummary() => ((_canvasGroup != null) ? _canvasGroup.name : "None") + " visible for time " + _speed;

    private IEnumerator Coroutine()
    {
        while (_canvasGroup.alpha != System.Convert.ToInt32(_visible))
        {
            _canvasGroup.alpha = (float)System.Math.Round(Mathf.Lerp(_canvasGroup.alpha, System.Convert.ToInt32(_visible), _speed),2);
            if (_canvasGroup.alpha >= .9f)
                _canvasGroup.alpha = 1;
            yield return null;
        }
        Continue();
    }
}

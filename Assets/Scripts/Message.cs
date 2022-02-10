using DG.Tweening;
using UnityEngine;

public class Message : MonoBehaviour
{
    [SerializeField] private float _time = 3;
    Sequence _sequence = null;

    private void Awake() => transform.localScale = new Vector3(1, 0, 1);

    private void OnEnable()
    {
        _sequence ??= DOTween.Sequence();
        _sequence.Append(transform.DOScale(Vector3.one, _time));
        _sequence.Play();
    }

    private void OnDestroy() => _sequence.Kill();
}

using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class FadeSelectButton : MonoBehaviour
{
    [SerializeField] private Image _imageButton;
    [SerializeField] private TextMeshProUGUI _text;

    private bool _firstTime = false;
    private void OnEnable()
    {
        if (gameObject.activeSelf && _firstTime)
        {
            _imageButton.DOFade(1f, 0.5f);
            _text.DOFade(1f, 0.5f);
        }
        else
            _firstTime = true;
    }
    private void OnDisable()
    {
        _imageButton.DOFade(0f, 0f);
        _text.DOFade(0f, 0f);
    }
}

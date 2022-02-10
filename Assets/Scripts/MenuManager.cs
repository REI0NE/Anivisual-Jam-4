using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Transform _windowTransform = null;
    [SerializeField] private CanvasGroup _windowCanvasGroup = null;
    [SerializeField] private CanvasGroup _sideMenuCanvasGroup = null;
    [SerializeField] private Image _vignette = null;

    private Sequence _sequence;
    private Vector3 _startWindowPosition;
    private void Start() => _startWindowPosition = _windowTransform.position;
    public void StartAct(int actIndex) => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + actIndex);

    public void WindowAppearancing(float timeAppearancing)
    {
        _sequence = DOTween.Sequence();
        _sequence.AppendCallback(() =>
        {
            _windowCanvasGroup.DOFade(1f, timeAppearancing);
            _vignette.raycastTarget = true;
            _sideMenuCanvasGroup.interactable = false;
            _windowTransform.DOMove(new Vector3(0f, 0f, _windowTransform.position.z), timeAppearancing, false);
        });
        _sequence.AppendInterval(timeAppearancing);
        _sequence.AppendCallback(() => _sequence.Kill());
    }

    public void WindowDisappearancing(float timeDisappearancing)
    {
        _sequence = DOTween.Sequence();
        _sequence.AppendCallback(() =>
        {
            _windowCanvasGroup.DOFade(0f, timeDisappearancing);
            _vignette.raycastTarget = false;
            _sideMenuCanvasGroup.interactable = true;
            _windowTransform.DOMove(_startWindowPosition, timeDisappearancing, false);
        });
        for (int i = 0; i < _windowTransform.childCount; i++)
        {
            if (_windowTransform.GetChild(i).gameObject.activeSelf == true)
            {
                _sequence.AppendInterval(timeDisappearancing);
                _sequence.AppendCallback(() => { _windowTransform.GetChild(i).gameObject.SetActive(false); });
                break;
            }
        }
    }

    public void EndGame() => Application.Quit();
}

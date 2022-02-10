using UnityEngine.SceneManagement;
using UnityEngine;
using DG.Tweening;

public class isExitMenu : MonoBehaviour
{
    [SerializeField] private CanvasGroup _warningcanvasGroup = null;
    [SerializeField] private GameObject _panel = null;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (_panel.activeSelf)
            {
                Sequence _sequence = DOTween.Sequence();
                _warningcanvasGroup.DOFade(0f, 0.5f);
                _sequence.AppendInterval(0.5f);
                _sequence.AppendCallback(() => { _panel.SetActive(!_panel.activeSelf); });
            }
            else
            {
                _warningcanvasGroup.DOFade(1f, 0.5f);
                _panel.SetActive(!_panel.activeSelf);
            }
        }
    }

    public void CallMenu() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
}

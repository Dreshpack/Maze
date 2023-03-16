using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private GameObject _continueButton;
    [SerializeField] private Image _dimmingPanel;
    [SerializeField] private PlayerCollision _playerCollision;

    public static Action IsPaused;
    public static Action IsContinued;

    private void OnEnable()
    {
        _playerCollision.finishCellTouched += DimmingScreen;
    }

    private void OnDisable()
    {
        _playerCollision.finishCellTouched -= DimmingScreen;
    }

    private IEnumerator DarkScreen()
    {
        float t = 0;
        Color startColor = _dimmingPanel.color;
        Debug.Log("start dim");
        while (t < 1)
        {
            t += Time.deltaTime;
            _dimmingPanel.color = Color.Lerp(startColor, Color.black, t);
            Debug.Log(t);
            yield return null;
        }
    }

    public void DimmingScreen()
    {
        _dimmingPanel.gameObject.SetActive(true);
        StartCoroutine(DarkScreen());
    }

    public void Pause()
    {
        _pausePanel.SetActive(true);
        _pauseButton.SetActive(false);
        IsPaused?.Invoke();
    }

    public void Continue()
    {
        _pauseButton.SetActive(true);
        _pausePanel.SetActive(false);
        IsContinued?.Invoke();
    }

    public void Exit()
    {
        Application.Quit();
    }
}

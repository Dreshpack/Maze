using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Retry : MonoBehaviour
{
    [SerializeField] Button _retryButton;
    [SerializeField] GameObject _panel;
    [SerializeField] PlayerCollision _playerCollision;

    private void OnEnable()
    {
        _playerCollision.finishCellTouched += NextLvl;
        _playerCollision.deadCellTouched += Lose;
    }

    private void Awake()
    {
        _panel.SetActive(false);
        _retryButton.enabled = false;
    }

    private IEnumerator ReloadButton()
    {
        yield return new WaitForSeconds(0.1f);
        _panel.SetActive(true);
        _retryButton.enabled = true;
    }

    private void Lose()
    {
        StartCoroutine(ReloadButton());
    }

    public void ReloadLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLvl()
    {
        StartCoroutine(NextLvlCoroutine());
    }
    private IEnumerator NextLvlCoroutine()
    {
        yield return new WaitForSeconds(1.7f);
        ReloadLvl();
    }

}


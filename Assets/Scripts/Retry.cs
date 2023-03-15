using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Retry : MonoBehaviour
{
    [SerializeField] Button _retryButton;

    private void Awake()
    {
        _retryButton.enabled = false;
    }

    private void OnEnable()
    {
        PlayerCollision.finishCellTouched += ReloadLvl;
        PlayerCollision.deadCellTouched += Lose;
    }

    private void OnDisable()
    {
        PlayerCollision.finishCellTouched -= ReloadLvl;
        PlayerCollision.deadCellTouched -= Lose;
    }

    private IEnumerator ReloadButton()
    {
        yield return new WaitForSeconds(2);
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

}


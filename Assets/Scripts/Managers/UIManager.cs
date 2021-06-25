using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager uiManager;

#pragma warning disable 0649
    [Header("UI Elements")]
    [SerializeField] private GameObject _levelEndCanvas;
    public GameObject _startButton;
    [SerializeField] private GameObject _tryAgainButton;
    [SerializeField] private GameObject _nextLevelButton;
    [SerializeField] private TextMeshProUGUI counterText;
#pragma warning restore 0649

    private void Awake()
    {
        uiManager = this;
    }

    public void TriggerLevelEndCanvas()
    {
        _levelEndCanvas.SetActive(true);
    }

    public void UpdateScoreText(int i)
    {
        counterText.text = i.ToString();
    }
    public void TryAgainButtonPressed()
    {
        GameManager.gameManager.TryAgainButtonPressed();
    }

    public void NextLevelButtonPressed()
    {
        GameManager.gameManager.NextLevelButtonPressed();
    }

    public void TriggerLevelFailed()
    {
        _tryAgainButton.SetActive(true);
    }

    public void StartButtonPressed()
    {
        GameManager.gameManager.StartButtonPressed();
        _startButton.SetActive(false);
    }
}

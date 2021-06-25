using System.Security;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [Header("General Variables")]
    public bool start = false;
    public bool finish = false;
    public bool fail = false;
    public GameObject vfx;
    public Animator anim;

#pragma warning disable 0649
    [SerializeField] private bool clearCurrentLvl;
    [SerializeField] private LevelScriptableObject _lvl;
    [SerializeField] private ScoreScriptableObject _score;
#pragma warning restore 0649

    private void Awake()
    {
        gameManager = this;
    }

    private void Start()
    {
        InitValues();

    }

    void InitValues()
    {
        if (clearCurrentLvl)
            _lvl.currentLevel = 0;
        UIManager.uiManager.UpdateScoreText(_score.currentScore);
    }

    void GameStart()
    {
        PlayerController.playerController.TriggerGameStarted();
    }

    public void LevelFail()
    {
        AudioManager.audioManager.PlayFailSFX();
        UIManager.uiManager.TriggerLevelFailed();
        fail = true;
    }

    public void LevelSuccess()
    {
        AudioManager.audioManager.PlayFinishSFX();
        vfx.SetActive(true);
        finish = true;
        UIManager.uiManager.TriggerLevelEndCanvas();
        anim.SetTrigger("dance");
        _lvl.currentLevel++;
        _score.currentScore++;
        UIManager.uiManager.UpdateScoreText(_score.currentScore);
    }

    public void TryAgainButtonPressed()
    {
        switch (_lvl.currentLevel)
        {
            case 1:
                SceneManager.LoadScene("NextLevel");
                break;
            case 2:
                SceneManager.LoadScene("NextLevel2");
                break;
            case 3:
                SceneManager.LoadScene("NextLevel3");
                break;
            case 4:
                SceneManager.LoadScene("NextLevel4");
                break;
            default:
                SceneManager.LoadScene("CoolGoal");
                break;
        }
    }

    public void NextLevelButtonPressed()
    {
        switch (_lvl.currentLevel)
        {
            case 1:
                SceneManager.LoadScene("NextLevel");
                break;
            case 2:
                SceneManager.LoadScene("NextLevel2");
                break;
            case 3:
                SceneManager.LoadScene("NextLevel3");
                break;
            case 4:
                SceneManager.LoadScene("NextLevel4");
                break;
            default:
                SceneManager.LoadScene("CoolGoal");
                break;
        }
    }

    public void StartButtonPressed()
    {
        start = true;
        GameStart();
    }
}
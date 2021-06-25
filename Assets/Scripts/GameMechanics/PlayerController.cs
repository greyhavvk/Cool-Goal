using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private Rigidbody _ballRigidbody;
    [SerializeField] private Transform _destinationBall;
    [SerializeField] private Transform _ball;
    [SerializeField] private GameObject aim;
#pragma warning restore 0649
    public bool isShot;
    public bool isFinish;
    public bool isTouch;

    public static PlayerController playerController;

    void Awake()
    {
        playerController = this;
    }
    void Start()
    {
        isShot = false;
        isFinish = false;
    }

    void Update()
    {
        if (isShot)
        {
            Debug.Log("içerdeyim");
            Vector3 _vector = (_destinationBall.position - _ball.position).normalized;
            _ballRigidbody.AddForce(_vector * 120000 * Time.deltaTime);
            Debug.Log("denedim");
            isShot = false;
            StartCoroutine(WaitFail());
        }

        if (isFinish)
        {
            isShot = false;
            GameManager.gameManager.LevelSuccess();
        }
    }

    private IEnumerator WaitStart()
    {
        yield return new WaitForSeconds(1);
        AimController.aimController.isStart = true;
    }

    private IEnumerator WaitFail()
    {
        yield return new WaitForSeconds(3);
        if (!GameManager.gameManager.finish)
            GameManager.gameManager.LevelFail();
    }
    public void TriggerGameStarted()
    {
        StartCoroutine(WaitStart());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("engel"))
        {
            Debug.Log("degdim");
            //_ballRigidbody.velocity = Vector3.zero;
            other.GetComponent<Animator>().SetTrigger("fall");
            other.GetComponent<BlokeController>().isMove = false;
            aim.SetActive(false);
        }
        else if (other.CompareTag("cevre"))
        {
            Debug.Log("degdim");
            // _ballRigidbody.velocity = Vector3.zero;
            aim.SetActive(false);
        }

    }
}

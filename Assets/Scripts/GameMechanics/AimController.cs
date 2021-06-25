using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
#pragma warning disable 0649

    [Header("Variables")]
    [SerializeField] private float _sensitivity;
    [SerializeField] private float _deltaThreshold;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;
    public Animator anim;

    [Header("References")]

    [SerializeField] private float _finalX;

#pragma warning restore 0649

    public static AimController aimController;
    public PlayerController player;
    private Vector2 _currentTouchPosition;

    private Vector2 _firstPosition;
    private Vector3[] _aimBallArray = new Vector3[9];
    public Rigidbody[] aimBallList = new Rigidbody[9];
    public bool isStart;
    public bool canShot;

    public float MaxX;
    public float MinX;
    private void Awake()
    {
        aimController = this;
    }
    void Start()
    {
        ResetValues();
    }
    void Update()
    {
        if (isStart)
        {
            if (canShot)
                MovementWithSlide();
        }
    }

    void ResetValues()
    {
        canShot = true;
        isStart = false;
        _firstPosition = Vector2.zero;
        _finalX = 0f;
        _currentTouchPosition = Vector2.zero;
        for (int i = 0; i < 9; i++)
        {
            aimBallList[i].velocity = new Vector3(0f, aimBallList[i].velocity.y, aimBallList[i].velocity.z);
        }
    }

    void MovementWithSlide()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _firstPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            _currentTouchPosition = Input.mousePosition;
            Vector2 touchDelta = (_currentTouchPosition - _firstPosition);

            if (_firstPosition == _currentTouchPosition)
            {
                for (int i = 0; i < 9; i++)
                {
                    aimBallList[i].velocity = new Vector3(0f, aimBallList[i].velocity.y, aimBallList[i].velocity.z);
                }
            }

            _finalX = transform.position.x;

            if (Mathf.Abs(touchDelta.x) >= _deltaThreshold)
            {
                _finalX = (transform.position.x + (touchDelta.x * _sensitivity));
            }

            if (_finalX >= MaxX)
            {
                float[] added = new float[9];
                for (int i = 0; i < 9; i++)
                {
                    added[i] = MaxX * i / 3;
                    aimBallList[i].position = new Vector3((added[i]) * (-1) + 1, aimBallList[i].transform.position.y, aimBallList[i].transform.position.z);
                }
            }
            else if (_finalX <= MinX)
            {
                float[] added = new float[9];
                for (int i = 0; i < 9; i++)
                {
                    added[i] = MinX * i / 3;
                    aimBallList[i].position = new Vector3((added[i]) * (-1) + 1, aimBallList[i].transform.position.y, aimBallList[i].transform.position.z);
                }
            }
            else
            {
                float[] added = new float[6];
                for (int i = 0; i < 6; i++)
                {
                    added[i] = _finalX * Mathf.Sqrt(0.5f * i);
                    aimBallList[i].position = new Vector3(_finalX + added[i], aimBallList[i].transform.position.y, aimBallList[i].transform.position.z);
                }
                aimBallList[6].position = new Vector3(aimBallList[5].position.x, aimBallList[6].transform.position.y, aimBallList[6].transform.position.z);
                aimBallList[7].position = new Vector3(aimBallList[4].position.x, aimBallList[7].transform.position.y, aimBallList[7].transform.position.z);
                aimBallList[8].position = new Vector3(aimBallList[3].position.x, aimBallList[8].transform.position.y, aimBallList[8].transform.position.z);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            anim.SetTrigger("shoot");
            AudioManager.audioManager.PlayShotSFX();
            canShot = false;
        }
    }
}

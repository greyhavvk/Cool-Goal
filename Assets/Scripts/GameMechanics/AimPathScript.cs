using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimPathScript : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private Transform _nextBall;
    [SerializeField] private Transform _thisBall;
    [SerializeField] private Rigidbody _ball;
#pragma warning restore 0649

    public bool isTouch;
    void Start()
    {
        PlayerController.playerController.isTouch = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            PlayerController.playerController.isTouch = true;
            Debug.Log("degdim");
            _ball.velocity = Vector3.zero;
            Vector3 _vector = (_nextBall.position - _ball.transform.position).normalized;
            _ball.AddForce(_vector * 120000 * Time.deltaTime);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PlayerController.playerController.isTouch = false;
    }
}
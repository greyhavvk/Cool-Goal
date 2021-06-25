using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalDetector : MonoBehaviour
{
    [SerializeField] private Rigidbody _ball;

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            _ball.velocity = Vector3.zero;
            GameManager.gameManager.LevelSuccess();
        }
    }
}

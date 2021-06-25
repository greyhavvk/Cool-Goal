using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlokeController : MonoBehaviour
{
    public Rigidbody bloke;
    public int revorse;
    public Animator anim;
    public bool isMove;
    public bool oneTime = true;
    void Update()
    {
        if (GameManager.gameManager.fail && oneTime)
        {
            oneTime = false;
            isMove = false;
            anim.SetTrigger("dance");
            Debug.Log("lets dance");
        }
        else if (isMove)
        {
            float x = (Mathf.PingPong(Time.time, 6) - 3) * revorse;
            bloke.position = new Vector3(x, bloke.transform.position.y, bloke.transform.position.z);
        }
    }
}

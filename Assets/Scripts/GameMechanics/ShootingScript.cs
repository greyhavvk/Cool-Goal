using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public PlayerController player;

    public void shoot()
    {
        player.isShot = true;
    }
}

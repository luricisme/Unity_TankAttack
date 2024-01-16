using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPowerUp : MonoBehaviour
{
    public PowerUpEffect tank;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("HaveOnTrigger");
        Destroy(gameObject);
        tank.Apply(collision.gameObject);
    }
}

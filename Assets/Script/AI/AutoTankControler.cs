using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTankControler : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public TankMovementData movementData;
    public Turret[] turrets;

    private Vector2 movementVector;

    private void Update()
    {
        //Gọi hàm tự động bắn ở đây
        AutoShoot();
    }

    private void AutoShoot()
    {
        foreach (var turret in turrets)
        {
            turret.Shoot();
            Debug.Log("TankController - Auto Shoot");
        }
    }

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        if (turrets == null || turrets.Length == 0)
        {
            turrets = GetComponentsInChildren<Turret>();
        }
    }

    public void HandleShoot()
    {
        foreach (var turret in turrets)
        {
            turret.Shoot();
        }
    }

    public void HandleMove(Vector2 movementVector)
    {
        this.movementVector = movementVector;
    }

    private void FixedUpdate()
    {
        rb2d.velocity = (Vector2)transform.right * movementVector.y * movementData.maxSpeed * Time.fixedDeltaTime;
        rb2d.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movementVector.x * movementData.rotationSpeed * Time.fixedDeltaTime));

    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    public BulletData bulletData;

    private Vector2 startPosition;
    private float conquareDistance = 0;
    private Rigidbody2D rb2d;

    public UnityEvent OnHit = new UnityEvent();
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    public void Initialize(BulletData bulletData)
    {
        this.bulletData = bulletData;
        startPosition = transform.position;
        rb2d.velocity = transform.right * this.bulletData.speed;
    }

    public void Update()
    {
        conquareDistance = Vector2.Distance(transform.position, startPosition);
        if (conquareDistance >= bulletData.maxDistance)
        {
            DisableObject();
        }
    }

    private void DisableObject()
    {
        rb2d.velocity = Vector2.zero;
        gameObject.SetActive(false);

        //Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        //if (rb2d != null)
        //{
        //    rb2d.velocity = Vector2.zero;
        //    // Additional logic to disable or destroy the object
        //}
        //else
        //{
        //    Debug.LogWarning("Rigidbody2D component not found on Bullet2 GameObject.");
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collidered" + collision.name);
        OnHit?.Invoke();
        bool check = true;

        var damagable = collision.GetComponent<Damagable>();
        if (damagable != null)
        {
            check = false;
            damagable.Hit(bulletData.damage);
        }

        if (check)
        {
            var damagableTank = collision.GetComponent<DamagableTank>();
            if (damagableTank != null)
            {
                damagableTank.Hit(bulletData.damage);
            }
        }



        DisableObject();
    }
}
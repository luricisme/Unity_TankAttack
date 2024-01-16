using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamagableTank : MonoBehaviour
{
    public PatrolPathMove patrolPathMove;
    public int MaxHealth = 100;
    public int ScoreGet = 0; // New variable for individual score
    public int PenaltyValue = -100;
    [SerializeField]
    private int health = 0;

    bool EnableShoot = false;

    Vector2 startport;
    Quaternion startRotation;
    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            OnHealthChange?.Invoke((float)Health / MaxHealth);
        }
    }

    public UnityEvent OnDead;
    public UnityEvent<float> OnHealthChange;
    public UnityEvent OnHit, OnHeal;

    private void Start()
    {
        if (health == 0)
            Health = MaxHealth;
        startRotation = transform.rotation;
        startport = transform.position;
    }

    internal void Hit(int damagePoints)
    {
        if (!EnableShoot)
        {
            Health -= damagePoints;

        }
        else
        {
            EnableShoot = false;
        }

        if (Health <= 0)
        {

            ScoreScript.ScoreScene += PenaltyValue;
            ScoreScript.ScoreScene += ScoreGet;
            //if (ScoreScript.ScoreValue < 0) ScoreScript.ScoreValue = 0;
            //OnDead?.Invoke();
            //Reset lại trạng thái 
            transform.rotation = startRotation;
            transform.position = startport;
            Health = MaxHealth;
            //PlayerPrefs.SetInt("PlayerScore", ScoreGet);
            //PlayerPrefs.Save();

            if (patrolPathMove != null)
            {
                //FindObjectOfType<PatrolPathMove>()?.SetStartPatrolPoint();
                patrolPathMove.SetStartPatrolPoint();

                EnableShoot = true;
            }

        }
        else
        {

            OnHit?.Invoke();
        }
    }

    public void Heal(int healthBoost)
    {
        Health += healthBoost;
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        OnHeal?.Invoke();
    }
}
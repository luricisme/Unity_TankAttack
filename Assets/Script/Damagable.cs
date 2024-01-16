using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damagable : MonoBehaviour
{
    public int MaxHealth = 50;
    public int ScoreGet = 0; // New variable for individual score
    public int PenaltyValue = -100;
    [SerializeField]
    private int health = 0;

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
    }

    internal void Hit(int damagePoints)
    {
        Health -= damagePoints;
        if (Health <= 0)
        {


            //if (ScoreScript.ScoreValue < 0) ScoreScript.ScoreValue = 0;
            OnDead?.Invoke();
            //PlayerPrefs.SetInt("PlayerScore", ScoreGet);
            //PlayerPrefs.Save();
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

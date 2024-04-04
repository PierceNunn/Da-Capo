using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    private float currentHealth = 1;
    private uint maxHealth;

    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }

    private void Start()
    {
        maxHealth = RhythmController.instance.CurrentDifficulty.MaxHealth;
        CurrentHealth = maxHealth;
    }

    public void loseHealth(uint quantity)
    {
        currentHealth = (currentHealth - quantity <= 0) ? 0.1f : currentHealth - quantity;
    }
}

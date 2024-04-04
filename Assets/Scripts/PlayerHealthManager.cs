using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    private uint currentHealth = 1;
    private uint maxHealth;

    public uint CurrentHealth { get => currentHealth; set => currentHealth = value; }

    private void Start()
    {
        maxHealth = RhythmController.instance.CurrentDifficulty.MaxHealth;
        CurrentHealth = maxHealth;
    }

    public void loseHealth(uint quantity)
    {
        currentHealth -= quantity;
    }
}

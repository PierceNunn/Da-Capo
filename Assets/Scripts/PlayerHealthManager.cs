/*****************************************************************************
// File Name : PlayerHealthManager.cs
// Author : Pierce Nunnelley
// Creation Date : April 13, 2024
//
// Brief Description : This script keeps track of player health during a song.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    private float currentHealth = 1;
    private uint maxHealth;

    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }

    /// <summary>
    /// sets the values of maxHealth and currentHealth.
    /// </summary>
    private void Start()
    {
        maxHealth = RhythmController.instance.CurrentDifficulty.MaxHealth;
        CurrentHealth = maxHealth;
    }

    /// <summary>
    /// Lowers health by given amount, keeping it above 0 for the sake of the UI.
    /// </summary>
    /// <param name="quantity">Amount to reduce health.</param>
    public void loseHealth(uint quantity)
    {
        currentHealth = (currentHealth - quantity <= 0) ? 0.1f : currentHealth - quantity;
    }

    /// <summary>
    /// Increases health by a given amount, keeping it above the value of maxHealth.
    /// </summary>
    /// <param name="quantity">Amount to increase health.</param>
    public void gainHealth(float quantity)
    {
        currentHealth = (currentHealth + quantity >= maxHealth) ? maxHealth : (currentHealth + quantity);
    }
}

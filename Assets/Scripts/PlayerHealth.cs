using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public UI canvas;
    public Slider healthBar;
    public int health = 100;

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            health = 0;
            canvas.End(false);
        }
        healthBar.value = health;
    }
}

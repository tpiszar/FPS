using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;

    public enum shooter
    {
        player,
        enemy
    }

    public shooter shotBy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (shotBy == shooter.player)
        {
            print(collision.gameObject.name + " " + Time.time);
            Enemy enemy = collision.gameObject.GetComponentInParent<Enemy>();
            if (enemy)
            {
                enemy.TakeDamage(damage);
            }   
        }
        else
        {
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            if (player)
            {
                player.TakeDamage(damage);
            }
        }
        Destroy(this.gameObject);
    }
}

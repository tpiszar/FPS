using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Bullet playerBullet = other.GetComponent<Bullet>();
        if (playerBullet && playerBullet.shotBy == Bullet.shooter.player)
        {
            player.position = transform.position;
            player.GetComponent<Movement>().enabled = false;
            Invoke("enableMove", .1f);
            Destroy(playerBullet.gameObject);
        }
    }

    void enableMove()
    {
        player.GetComponent<Movement>().enabled = true;
    }
}

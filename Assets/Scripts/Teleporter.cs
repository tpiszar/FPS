using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform player;
    public float rotationSpeed = 10f;
    public Transform box;

    bool wait = false;
    float delay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (delay >= 5)
        {
            wait = false;
        }
        else
        {
            delay += Time.deltaTime;
        }
        Vector3 rot = box.localEulerAngles;
        rot.y += rotationSpeed * Time.deltaTime;
        box.localEulerAngles = rot;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!wait)
        {
            Bullet playerBullet = other.GetComponent<Bullet>();
            if (playerBullet && playerBullet.shotBy == Bullet.shooter.player)
            {
                player.position = transform.position;
                player.GetComponent<Movement>().enabled = false;
                Invoke("enableMove", .1f);
                Destroy(playerBullet.gameObject);
            }
            delay = 0;
            wait = true;
        }
    }

    void enableMove()
    {
        player.GetComponent<Movement>().enabled = true;
    }
}

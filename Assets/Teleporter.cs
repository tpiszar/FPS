using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform player;
    public float rotationSpeed = 10f;
    public Transform box;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rot = box.localEulerAngles;
        rot.y += rotationSpeed * Time.deltaTime;
        box.localEulerAngles = rot;
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

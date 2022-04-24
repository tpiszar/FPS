using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform body;
    public Transform head;
    public Transform gun;
    public Transform gunCenter;

    public float rotationSpeed;

    public NavMeshAgent agent;
    public Transform target;


    public Transform shootPoint;
    public GameObject bullet;

    public int damage = 10;
    public float fireRate = 15f;
    public float bulletSpeed = 20f;

    private float nextTimeToFire = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //agent.SetDestination(target.position);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 bodyLookPoint = target.position;
        bodyLookPoint.y = body.position.y;
        //head.LookAt(target.position);
        //body.LookAt(bodyLookPoint);
        //gun.LookAt(target.position);

        Vector3 bodyDir = bodyLookPoint - body.position;
        Vector3 headDir = target.position - head.position;
        Vector3 gunDir = target.position - gun.position;

        body.rotation = Quaternion.Slerp(body.rotation, Quaternion.LookRotation(bodyDir), rotationSpeed * Time.deltaTime);
        head.rotation = Quaternion.Slerp(head.rotation, Quaternion.LookRotation(headDir), rotationSpeed * Time.deltaTime);
        gun.rotation = Quaternion.Slerp(gun.rotation, Quaternion.LookRotation(gunDir), rotationSpeed * Time.deltaTime);

        Vector3 gunRot = gun.localEulerAngles;
        gunRot.z = 0;
        gun.localEulerAngles = gunRot;

        if (Time.time >= nextTimeToFire)
        {
            Shoot();

            nextTimeToFire = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        Vector3 dir = shootPoint.forward;//target.position - shootPoint.position;

        GameObject newBullet = Instantiate(bullet, shootPoint.position, Quaternion.identity);
        newBullet.GetComponent<Bullet>().damage = damage;
        newBullet.GetComponent<Rigidbody>().AddForce(dir.normalized * bulletSpeed, ForceMode.Impulse);
        newBullet.transform.forward = dir.normalized;
        newBullet.transform.Rotate(new Vector3(90, 0, 0));
        Destroy(newBullet, 5f);
    }

    public int health = 100;

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
        print("HEALTH: " + health);
    }
}

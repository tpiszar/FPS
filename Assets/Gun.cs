using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Camera cam;
    public Transform shootPoint;
    public LayerMask shootMask;
    public GameObject bullet;

    public int damage = 10;
    public float range = 100f;
    public float fireRate = 15f;
    public float bulletSpeed = 20f;

    private float nextTimeToFire = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            Shoot();

            nextTimeToFire = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        Vector3 target;
        if (Physics.Raycast(ray, out hit, range, shootMask))
        {
            target = hit.point;
        }
        else
        {
            target = ray.GetPoint(75);
        }

        Vector3 dir = target - shootPoint.position;

        GameObject newBullet = Instantiate(bullet, shootPoint.position, Quaternion.identity);
        newBullet.GetComponent<Bullet>().damage = damage;
        newBullet.GetComponent<Rigidbody>().AddForce(dir.normalized * bulletSpeed, ForceMode.Impulse);
        newBullet.transform.forward = dir.normalized;
        newBullet.transform.Rotate(new Vector3(90, 0, 0));
        Destroy(newBullet, 5f);
    }
}

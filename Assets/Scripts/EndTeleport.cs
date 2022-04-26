using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTeleport : MonoBehaviour
{
    public MeshRenderer mesh;
    public Material mat;
    public GameObject pointLight;

    public Transform player;

    public float rotationSpeed;

    bool on = false;
    public int requiredKeys;
    int keys = 0;


    public UI canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            Vector3 rot = transform.localEulerAngles;
            rot.y += rotationSpeed * Time.deltaTime;
            transform.localEulerAngles = rot;
        }
    }

    public void Activate()
    {
        keys++;
        if (keys >= requiredKeys)
        {
            mesh.material = mat;
            pointLight.SetActive(true);
            on = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (on)
        {
            canvas.End(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    EndTeleport end;

    // Start is called before the first frame update
    void Start()
    {
        end = GameObject.FindGameObjectWithTag("End").GetComponent<EndTeleport>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Movement player = other.gameObject.GetComponent<Movement>();
        if (player)
        {
            end.Activate();
            Destroy(this.gameObject);
        }

    }
}

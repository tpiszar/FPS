using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{

    public static Music music;
    public AudioSource pickUp;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (music == null)
        {
            music = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void PickUp()
    {
        pickUp.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

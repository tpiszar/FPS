using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Runner : MonoBehaviour
{
    public float detectDist;
    public float maxDetect;

    public float runSpeed;
    float walkSpeed;
    [SerializeField]
    Transform[] runPoints;

    public NavMeshAgent agent;

    public Transform player;
    public GameObject key;

    bool running = false;
    public float idleTime;
    float nextMove;
    public float patrolRange;

    public float checkTime;
    float nextCheck;

    public AudioSource detect;

    // Start is called before the first frame update
    void Start()
    {
        walkSpeed = agent.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!running)
        {
            Idle();
        }
        else
        {
            if (nextCheck > checkTime)
            {
                if (Vector3.Distance(transform.position, player.position) < maxDetect)
                {
                    Run();
                }
                else
                {
                    running = false;
                    agent.ResetPath();
                    agent.speed = walkSpeed;
                }
                nextCheck = 0;
            }
            else
            {
                nextCheck += Time.deltaTime;
            }
        }
    }

    void Idle()
    {
        if (Vector3.Distance(transform.position, player.position) < detectDist)
        {
            running = true;
            detect.Play();
            Run();
        }
        else
        {
            if (!agent.hasPath || Vector3.Distance(agent.destination, transform.position) < 1)
            {
                if (nextMove > idleTime)
                {
                    agent.SetDestination(this.transform.position +
                        new Vector3(Random.Range(-patrolRange, patrolRange), 0, Random.Range(-patrolRange, patrolRange)));
                    nextMove = 0;
                }
                else
                {
                    nextMove += Time.deltaTime;
                }
            }
        }
    }

    void Run()
    {
        float maxDist = Vector3.Distance(player.position, runPoints[0].position);
        Transform max = runPoints[0];
        for (int i = 1; i < runPoints.Length; i++)
        {
            float dist = Vector3.Distance(player.position, runPoints[i].position);
            if (dist > maxDist)
            {
                maxDist = dist;
                max = runPoints[i];
            }
        }

        agent.speed = runSpeed;
        agent.SetDestination(max.position);
    }

    public int health = 100;

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Instantiate(key, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else
        {
            detect.Play();
            Run();
        }
    }
}

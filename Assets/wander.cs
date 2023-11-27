using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wander : MonoBehaviour
{
    enum ghostState
    {
        WANDERING,
        FOUND_PLAYER,
        RETURN
    }

    ghostState state = ghostState.WANDERING;
    ghostState statetwo = ghostState.FOUND_PLAYER;
    ghostState statethree = ghostState.RETURN;
    GameObject Player;
    GameObject Cherry;
    // Start is called before the first frame update
    void Start()
    {
        // GameObject Cherry = GameObject.Find("Cherry");
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        if (agent.remainingDistance <= 1.0f)
        {
            float x = Random.Range(-20.0f, 20.0f);
            float z = Random.Range(-20.0f, 20.0f);

            agent.destination = new Vector3(x, 0.0f, z);
        }
        else if (state == ghostState.FOUND_PLAYER)
        {

            agent.destination = Player.transform.position;
        }
        else if (state == ghostState.RETURN)
        {

            agent.destination = new Vector3(0.0f, 5.93f, 0.0f);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            state = ghostState.FOUND_PLAYER;
            Player = other.gameObject;
        }
        if (other.gameObject.name == "Cherry")
        {
            state = ghostState.RETURN;
            Cherry = other.gameObject;
        }
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject characterToFollow;
    public string nameToFollow; 

    void Update()
    {
        characterToFollow = GameObject.FindGameObjectWithTag(nameToFollow);
        agent.SetDestination(characterToFollow.transform.position);
    }
}

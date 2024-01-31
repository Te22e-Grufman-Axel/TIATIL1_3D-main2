using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
 NavMeshAgent agent;

 [SerializeField]
 GameObject target;

 void Awake()
 {
    agent = GetComponent<NavMeshAgent>();
 }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       agent.destination = target.transform.position; 
    }
}

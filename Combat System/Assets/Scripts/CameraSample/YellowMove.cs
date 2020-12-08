using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class YellowMove : MonoBehaviour
{
    public Transform path;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.velocity == new Vector3())
        {
            int random = Random.Range(0, path.childCount);
            agent.SetDestination(path.GetChild(random).position);
        }
    }
}

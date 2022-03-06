using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Mouvement : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;

    private void move() {
        if(target != null) {
            Debug.DrawLine(transform.position, target.transform.position, Color.blue);
            agent.SetDestination(target.transform.position);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
}

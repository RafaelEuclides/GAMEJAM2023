using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNav : MonoBehaviour
{
    // Start is called before the first frame update
    private NavMeshAgent inimigo;
    private Transform point;
    public Animator an;
    void Start()
    {
        an = GetComponent<Animator>();
        inimigo = GetComponent<NavMeshAgent>();
        point = GameObject.Find("Poly").transform;
    }

    // Update is called once per frame
    void Update()
    {
        inimigo.SetDestination(point.position);
    }
}

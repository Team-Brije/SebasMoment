using System.Collections.Generic;
using BehaviorTrees;
using UnityEngine;
using UnityEngine.AI;

public class EnemyIa : MonoBehaviour
{
    public NavMeshAgent navnav;
    public Animator anims;
    public List<Transform> waypoints;
    BehaviorTree tree;
    void Awake()
    {
        navnav = GetComponent<NavMeshAgent>();
        anims = GetComponent<Animator>();

        tree = new BehaviorTree("Enemy");
        tree.AddChild(new Leaf("Patrol", new Moving(transform, navnav, waypoints)));
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tree.Process();
    }
}

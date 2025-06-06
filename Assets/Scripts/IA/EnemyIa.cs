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
    public Transform player;
    public bool isPlayerInView;
    void Awake()
    {
        waypoints = SpawnEnemy.wayPoints;

        navnav = GetComponent<NavMeshAgent>();
        anims = GetComponent<Animator>();

        tree = new BehaviorTree("Enemy");

        PrioritySelector actions = new PrioritySelector("EnemyLogic");


        Sequence movingEnemy = new Sequence("MovingEnemy", 50);
        bool CanEnemyMove()
        {
            if (isPlayerInView)
            {
                movingEnemy.Reset();
                return false;
            }
            return true;
        }
        movingEnemy.AddChild(new Leaf("CanMove", new Condition(CanEnemyMove)));
        movingEnemy.AddChild(new Leaf("Patrol", new Moving(transform, navnav, waypoints)));

        actions.AddChild(movingEnemy);

        Sequence atackPlayer = new Sequence("AtackPlayer", 100);
        bool IsPlayerOnView()
        {
            if (player == null)
            {
                atackPlayer.Reset();
                return false;
            }
            return true;
        }
        atackPlayer.AddChild(new Leaf("isinview", new Condition(IsPlayerOnView)));
        atackPlayer.AddChild(new Leaf("GettingClose", new GetCloseToPlayer(transform, navnav, player)));

        actions.AddChild(atackPlayer);

        tree.AddChild(actions);

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waypoints = SpawnEnemy.wayPoints;
    }

    // Update is called once per frame
    void Update()
    {
        tree.Process();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
            isPlayerInView = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInView = false;
            player = null;
        }
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
namespace BehaviorTrees
{
    public interface EnemyInterfae
    {
        Node.Status Process();
        void Reset()
        {
            //noop
        }
        void Repeat()
        {

        }
    }

    public class Condition : EnemyInterfae
    {
        readonly Func<bool> predicate;

        public Condition(Func<bool> predicate)
        {
            this.predicate = predicate;
        }

        public Node.Status Process() => predicate() ? Node.Status.Success : Node.Status.Failure;
    }
    public class Moving : EnemyInterfae
    {
        readonly Transform transformEnemy;
        readonly NavMeshAgent navnav;
        readonly List<Transform> NewPositions;
        readonly float patrolSpeed;
        int currentIndex;
        bool isPathCalculated;

        public Moving(Transform transformEnemy, NavMeshAgent navnav, List<Transform> NewPositions, float patrolSpeed = 20f)
        {
            this.transformEnemy = transformEnemy;
            this.navnav = navnav;
            this.NewPositions = NewPositions;
            this.patrolSpeed = patrolSpeed;
        }
        public Node.Status Process()
        {
            if (currentIndex == NewPositions.Count) return Node.Status.Success;
            var target = NewPositions[currentIndex];
            navnav.SetDestination(target.position);
            transformEnemy.LookAt(target);

            if (isPathCalculated && navnav.remainingDistance < 0.1f)
            {
                currentIndex = UnityEngine.Random.Range(0, NewPositions.Count);
                isPathCalculated = false;
            }

            if (navnav.pathPending)
            {
                isPathCalculated = true;
            }


            return Node.Status.Running;
        }

        public void Reset() => currentIndex = 0;
    }
    public class GetCloseToPlayer : EnemyInterfae
    {
        readonly Transform transformEnemy;
        readonly NavMeshAgent navnav;
        readonly Transform player;
        readonly float patrolSpeed;

        public GetCloseToPlayer(Transform transformEnemy, NavMeshAgent navnav, Transform player,float patrolSpeed = 20f)
        {
            this.transformEnemy = transformEnemy;
            this.navnav = navnav;
            this.player = player;
            this.patrolSpeed = patrolSpeed;
        }
        public Node.Status Process()
        {
            if (navnav.remainingDistance < 0.2f) return Node.Status.Success;
            
            navnav.SetDestination(player.position);
            

            return Node.Status.Running;
        }

    }
}

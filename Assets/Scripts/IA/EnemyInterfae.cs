using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
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
    public class Moving : EnemyInterfae
    {
        readonly Transform transformEnemy;
        readonly NavMeshAgent navnav;
        readonly List<Transform> NewPositions;
        readonly float patrolSpeed;
        int currentIndex;
        bool isPathCalculated;

        public Moving(Transform transformEnemy, NavMeshAgent navnav, List<Transform> NewPositions, float patrolSpeed = 2f)
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
                currentIndex++;
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
}

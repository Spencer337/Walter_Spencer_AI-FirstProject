using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class PatrolAT : ActionTask {
        public List<Transform> patrolPoints;


        private NavMeshAgent navAgent;
        private int currentPatrolPointIndex = 0;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			navAgent = agent.GetComponent<NavMeshAgent>();
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            currentPatrolPointIndex = 0;
            navAgent.SetDestination(patrolPoints[currentPatrolPointIndex].position);
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            if (navAgent.remainingDistance < 0.25f &&
                !navAgent.pathPending)
            {
                currentPatrolPointIndex++;

                //Another option for resetting when the count is reached
                //currentPatrolPointIndex %= patrolPoints.Count;

                if (currentPatrolPointIndex >= patrolPoints.Count)
                {
                    currentPatrolPointIndex = 0;
                }

                //Set destination to the next point
                Vector3 nextPosition = patrolPoints[currentPatrolPointIndex].position;

                navAgent.SetDestination(nextPosition);
            }
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}
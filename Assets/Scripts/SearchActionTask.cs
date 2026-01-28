using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions
{

	public class SearchActionTask : ActionTask
	{
		public BBParameter<NavMeshAgent> navAgent;
		public BBParameter<Vector3> startingPosition;
		public Vector3 targetPosition;
		protected override string OnInit()
		{
			return null;
		}

		protected override void OnExecute()
		{
			//Choose a random destination on the navmesh
			//Set the path to that position
			targetPosition = Random.insideUnitSphere * 3;
			targetPosition.y = startingPosition.value.y;

			NavMeshHit hit;
			if (NavMesh.SamplePosition(targetPosition, out hit, 3f, NavMesh.AllAreas) == false)
			{
				Debug.Log("Could not find location");
            }
			else
			{
                navAgent.value.SetDestination(targetPosition);
            }
				
        }

		protected override void OnUpdate()
		{
			//When they have arrived then end the task
			if(navAgent.value.remainingDistance <= 0.3)
			{
				EndAction();
			}
		}

		//Called when the task is disabled.
		protected override void OnStop()
		{
			
		}

		//Called when the task is paused.
		protected override void OnPause()
		{
			
		}
	}
}
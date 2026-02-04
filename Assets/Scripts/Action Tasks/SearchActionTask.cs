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
		public float stoppingDistance;
		public float searchRadius;
		protected override string OnInit()
		{
			return null;
		}

		protected override void OnExecute()
		{
			//Choose a random destination on the navmesh
			
			Vector3 randomPoint = Random.insideUnitSphere * searchRadius + agent.transform.position;

			NavMeshHit navHit;
			if (!NavMesh.SamplePosition(randomPoint, out navHit, searchRadius, NavMesh.AllAreas))
			{
				return;
			}

            //Set the path to that position
            navAgent.value.SetDestination(navHit.position);
				
        }

		protected override void OnUpdate()
		{
			//When they have arrived then end the task
			if(navAgent.value.pathPending && navAgent.value.remainingDistance <= stoppingDistance)
			{
				EndAction(true);
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
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.AI;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{

    public class ReturnActionTask : ActionTask
	{
        public BBParameter<Transform> startingPosition;
        public BBParameter<NavMeshAgent> navAgent;

        protected override string OnInit()
		{
            return null;
		}


		protected override void OnExecute()
		{
            //Tell the agent to return to the starting position
            navAgent.value.SetDestination(startingPosition.value.position);
        }


		protected override void OnUpdate()
		{
            //End the task when you have arrived
            if (navAgent.value.remainingDistance <= 0.3)
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
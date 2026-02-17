using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.AI;
using UnityEngine;
using static UnityEditor.U2D.ScriptablePacker;


namespace NodeCanvas.Tasks.Actions {

	public class MoveToFoodAT : ActionTask {

        public BBParameter<NavMeshAgent> navAgent;
		public Transform foodTransform;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
            // Start updating the transform to be synchronized with the nav agent
            navAgent.value.updatePosition = true;
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			// Set the parrot's destination to the food bowl's position
            navAgent.value.SetDestination(foodTransform.position);
            
		}

        //Called once per frame while the action is active.
		protected override void OnUpdate() {
            // If the path is not loading and there is no more distance on the path, end the action
            if (navAgent.value.pathPending == false && navAgent.value.remainingDistance <= 0)
			{
				EndAction(true);
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
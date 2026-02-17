using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.AI;
using UnityEngine;
using UnityEngine.InputSystem;


namespace NodeCanvas.Tasks.Actions {

	public class MoveToClickAT : ActionTask {
        public BBParameter<LayerMask> groundLayerMask;
        public BBParameter<NavMeshAgent> navAgent;
		public BBParameter<bool> isFlying;
		public Vector3 worldPosition;
		public Vector3 mousePosition;
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            bool leftMouseClicked = Mouse.current.leftButton.wasPressedThisFrame;
            if (leftMouseClicked)
            {
                mousePosition = Mouse.current.position.ReadValue();

                Ray mouseClickRay = Camera.main.ScreenPointToRay(mousePosition);
                RaycastHit mouseClickHit;
                var path = new NavMeshPath();

                if (Physics.Raycast(mouseClickRay, out mouseClickHit, 1000f, groundLayerMask.value))
				{
					// Set the parrot's destination to the point the player clicked
					navAgent.value.SetDestination(mouseClickHit.point);
                }
				//else
				//{
				//	Debug.Log("no destination");
				//	EndAction(true);
				//}
            }
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            if (navAgent.value.pathPending == false && navAgent.value.remainingDistance <= 0)
            {
                EndAction(true);
            }
			if (navAgent.value.pathStatus == NavMeshPathStatus.PathPartial)
			{
				navAgent.value.ResetPath();
                isFlying.value = true;
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
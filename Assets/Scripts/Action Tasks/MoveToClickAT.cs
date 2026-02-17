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
		public BBParameter<Vector3> destinationPoint;
        public BBParameter<bool> reachedMovementDestination;
        public float maxDistance;

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
            // Set the reachedMovementDestination boolean to false
            reachedMovementDestination.value = false;

            // Start updating the transform to be synchronized with the nav agent
            navAgent.value.updatePosition = true;

			// If the lest mouse button was pressed this frame
            bool leftMouseClicked = Mouse.current.leftButton.wasPressedThisFrame;
            if (leftMouseClicked)
            {
				// Get the mouse's position
                mousePosition = Mouse.current.position.ReadValue();

				// Cast a ray based on the mouse's position
                Ray mouseClickRay = Camera.main.ScreenPointToRay(mousePosition);
                RaycastHit mouseClickHit;

				// If the raycast hit the ground layer
                if (Physics.Raycast(mouseClickRay, out mouseClickHit, maxDistance, groundLayerMask.value))
				{
					// Set the destination point variable to the point the player clicked
					destinationPoint.value = mouseClickHit.point;
                    // Set the parrot's destination to the destination point
                    navAgent.value.SetDestination(destinationPoint.value);
                }
            }
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            // If the path is not full, reset the path and set is flying to true
            // Then, end the action
            if (navAgent.value.pathStatus != NavMeshPathStatus.PathComplete)
            {
                navAgent.value.ResetPath();
                isFlying.value = true;
                EndAction(true);
            }
            // If the path is not loading and there is no more distance on the path, end the action
            if (navAgent.value.pathPending == false && navAgent.value.remainingDistance <= 0.5)
            {
                // Set the reachedMovementDestination boolean to false
                reachedMovementDestination.value = true;
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
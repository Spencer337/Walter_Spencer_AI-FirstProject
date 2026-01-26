using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class WalkAT : ActionTask {
        public BBParameter<Vector3> velocity;
		public BBParameter<GameObject> astronautPivot;
		public Vector3 playerInput;
		private float acceleration;
		private float deceleration;
		public float maxSpeed;
		public float accelerationTime;
		public float decelerationTime;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			acceleration = maxSpeed / accelerationTime;
			deceleration = maxSpeed / decelerationTime;
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			if (Input.GetKey(KeyCode.RightArrow))
			{
				playerInput = Vector3.right;
			}
			else if (Input.GetKey(KeyCode.LeftArrow))
			{
				playerInput = Vector3.left;
			}
			else if (Input.GetKey(KeyCode.UpArrow))
			{
				playerInput = Vector3.forward;
			}
			else if (Input.GetKey(KeyCode.DownArrow))
			{
				playerInput = Vector3.back;
			}
			else
			{
				playerInput = Vector3.zero;
			}

			if (playerInput.magnitude > 0)
			{
                velocity.value += playerInput * acceleration * Time.deltaTime;
            }
			else
			{
                Vector3 changeInVelocity = velocity.value.normalized * deceleration * Time.deltaTime;
                // If the player is going to overshoot their deceleration, set horizontal velocity to zero
                if (changeInVelocity.magnitude > velocity.value.magnitude)
                {
                    velocity.value = Vector3.zero;
                }
                // Otherwise, decelerate normally
                else
                {
                    velocity.value -= changeInVelocity;
                }
            }

            if (velocity.value.magnitude > maxSpeed)
            {
                velocity = velocity.value.normalized * maxSpeed;
            }

            astronautPivot.value.transform.position += velocity.value * Time.deltaTime;
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}
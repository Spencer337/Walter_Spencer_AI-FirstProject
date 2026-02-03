using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class WalkAT : ActionTask {
        public BBParameter<Vector3> velocity;
		public Vector3 playerInput;
		private float acceleration;
		public BBParameter<float> maxSpeed;
		public float accelerationTime;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			// Calculate deceleration
            acceleration = maxSpeed.value / accelerationTime;
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			// Set the player input to zero
            playerInput = Vector3.zero;
			// If the player presses arrow keys, set player input to that direction's vector
            if (Input.GetKey(KeyCode.RightArrow))
			{
				playerInput += Vector3.right;
			}
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				playerInput += Vector3.left;
			}
			if (Input.GetKey(KeyCode.UpArrow))
			{
				playerInput += Vector3.forward;
			}
			if (Input.GetKey(KeyCode.DownArrow))
			{
				playerInput += Vector3.back;
			}

			// Increase velocity by playerInput multiplied by acceleration and time
            velocity.value += playerInput * acceleration * Time.deltaTime;

			// If velocity is greater than max speed, set velocity to the max speed
            if (velocity.value.magnitude > maxSpeed.value)
            {
                velocity.value = velocity.value.normalized * maxSpeed.value;
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
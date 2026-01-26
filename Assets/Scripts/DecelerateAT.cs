using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class DecelerateAT : ActionTask {
        public BBParameter<bool> astronautIsMoving;
        public BBParameter<Vector3> velocity;
        private float deceleration;
        public BBParameter<float> maxSpeed; 
        public float decelerationTime;


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
            deceleration = maxSpeed.value / decelerationTime;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

            // If the astronaut is not moving
            if (astronautIsMoving.value == false)
            {
                // Calculate the change in velocity
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
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}
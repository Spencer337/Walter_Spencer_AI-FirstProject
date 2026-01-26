using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class DecelerateAT : ActionTask {
        public BBParameter<bool> astronautIsMoving;
        public BBParameter<Vector3> velocity;
        public BBParameter<Transform> astronautPivot;
        private float deceleration;
        public BBParameter<float> maxSpeed; 
        public float decelerationTime;
        public BBParameter<Transform> astronautLeftSide;
        public BBParameter<Transform> astronautRightSide;


        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            deceleration = maxSpeed.value / decelerationTime;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

            if (astronautIsMoving.value == false)
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
            //astronautPivot.value.position += velocity.value * Time.deltaTime;

            //astronautLeftSide.value.position += velocity.value * Time.deltaTime;
            //astronautRightSide.value.position += velocity.value * Time.deltaTime;
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}
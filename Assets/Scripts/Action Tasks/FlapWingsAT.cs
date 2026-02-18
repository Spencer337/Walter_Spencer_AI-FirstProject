using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class FlapWingsAT : ActionTask {
		public BBParameter<Transform> leftWingPivot;
        public BBParameter<Transform> rightWingPivot;
		public BBParameter<bool> isFlying;
		public BBParameter<AudioClip> wingFlap; 
		public float maxRotation, minRotation;
		public float rotationSpeed;
		private float r;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            // Play the wing flap audio clip
			AudioSource.PlayClipAtPoint(wingFlap.value, agent.transform.position);
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			// Increase r by time multiplied by rotation speed
            r += Time.deltaTime * rotationSpeed;
			// Set the rotation of the left wing's pivot to r
			leftWingPivot.value.transform.localEulerAngles = new Vector3(0, 0, r);
            // Set the rotation of the left wing's pivot to negative r
            rightWingPivot.value.transform.localEulerAngles = new Vector3(0, 0, -r);

			// If r is greater than the maximum or less than the minimum, inverse the roation speed
			if (r > maxRotation || r < minRotation)
			{
				rotationSpeed = -rotationSpeed;
			}
			// If the parrot is not flying, end the action
			if (isFlying.value == false)
			{
				EndAction();
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
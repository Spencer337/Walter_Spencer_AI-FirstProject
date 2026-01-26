using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class MovementUpdateAT : ActionTask {
        public BBParameter<Transform> astronautPivot;
        public BBParameter<Transform> astronautLeftSide;
        public BBParameter<Transform> astronautRightSide;
        public BBParameter<Vector3> velocity; 

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            astronautPivot.value.position += velocity.value * Time.deltaTime;

            astronautLeftSide.value.position += velocity.value * Time.deltaTime;
            astronautRightSide.value.position += velocity.value * Time.deltaTime;
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}
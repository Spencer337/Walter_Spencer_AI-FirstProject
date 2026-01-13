using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class MoveCameraAT : ActionTask {
		public Vector3 velocity;
		public bool isMovingForward = true;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			velocity = Camera.main.transform.position;
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			if (isMovingForward == true)
			{
				velocity.z += Time.deltaTime;
				Camera.main.transform.position = velocity;
				if (velocity.z >= -5)
				{
					velocity.z = -5;
					isMovingForward = false;
				}
			}
			else if (isMovingForward == false)
			{
                velocity.z -= Time.deltaTime;
                Camera.main.transform.position = velocity;
                if (velocity.z <= -10)
                {
                    velocity.z = -10;
                    isMovingForward = true;
                    EndAction(true);
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
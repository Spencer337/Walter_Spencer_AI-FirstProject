using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class MoveToAstronautAT : ActionTask {
		public Transform leftSideTarget;
		public Transform rightSideTarget;
        public BBParameter<GameObject> astronautObject;
        public BBParameter<float> speed;
        Blackboard otherBlackboard;
		private bool astronautIsFallingLeft;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
            otherBlackboard = astronautObject.value.GetComponent<Blackboard>();
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            astronautIsFallingLeft = otherBlackboard.GetVariableValue<bool>("isFallingLeft");
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

			if (astronautIsFallingLeft == true)
			{
				Vector3 directionToMove = rightSideTarget.position - agent.transform.position;

				agent.transform.position += directionToMove.normalized * speed.value * Time.deltaTime;

				float distanceToTarget = Vector3.Magnitude(directionToMove);
				if (distanceToTarget < 0.5)
				{
					EndAction(true);
				}
			}
			else if (astronautIsFallingLeft == false)
			{
                Vector3 directionToMove = rightSideTarget.position - agent.transform.position;

                agent.transform.position += directionToMove.normalized * speed.value * Time.deltaTime;

                float distanceToTarget = Vector3.Magnitude(directionToMove);
                if (distanceToTarget < 0.5)
                {
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
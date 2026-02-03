using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class FallOverAT : ActionTask {
		public BBParameter<bool> isFallingLeft;
		public GameObject astronautPivot;
        Blackboard agentBlackboard;
		public float fallingSpeed;
		public float t;
		public BBParameter<bool> isStanding;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
            agentBlackboard = agent.GetComponent<Blackboard>();
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			// Set t to 0
			t = 0;
			// Set isStanding to false
			isStanding.value = false;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			// If the astronaut is falling left
			if (isFallingLeft.value == true)
			{
				// If the astronaut not done falling, increase t
				if (t <= 90)
				{
                    t += Time.deltaTime * fallingSpeed;
                }
				// If the astronaut is done falling, set the pivot's rotation to the end falling value and end the action
				else
				{
					//isFallingLeft.value = false;
                    astronautPivot.transform.eulerAngles = new Vector3(0, 0, 90);
                    EndAction(true);

                }
			}
			// If the astronaut is falling right
            else if (isFallingLeft.value == false)
            {
				// If the astronaut is not done falling ,decrease t
                if (t >= -90)
                {
                    t -= Time.deltaTime * fallingSpeed;
                }
                // If the astronaut is done falling, set the pivot's rotation to the end falling value and end the action
                else
                {
                    //isFallingLeft.value = true;
                    astronautPivot.transform.eulerAngles = new Vector3(0, 0, -90);
                    EndAction(true);
                }
            }
			// Set the astronaut's pivot's z rotation to t
			astronautPivot.transform.eulerAngles = new Vector3(0, 0, t);
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}
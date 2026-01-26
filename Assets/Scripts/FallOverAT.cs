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
			t = 0;
			isStanding.value = false;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			if (isFallingLeft.value == true)
			{
				if (t <= 90)
				{
                    t += Time.deltaTime * fallingSpeed;
                }
				else
				{
					//isFallingLeft.value = false;
                    astronautPivot.transform.eulerAngles = new Vector3(0, 0, 90);
                    EndAction(true);

                }
			}
            else if (isFallingLeft.value == false)
            {
                if (t >= -90)
                {
                    t -= Time.deltaTime * fallingSpeed;
                }
                else
                {
                    //isFallingLeft.value = true;
                    astronautPivot.transform.eulerAngles = new Vector3(0, 0, -90);
                    EndAction(true);
                }
            }
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
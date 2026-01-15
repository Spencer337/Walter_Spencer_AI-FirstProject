using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class BreatheAT : ActionTask {
        public BBParameter<float> breatheInterval;
        public float t;
		Blackboard agentBlackboard;
		public float currentOxygen;

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
			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			t += Time.deltaTime;
			if (t >= breatheInterval.value)
			{
                currentOxygen = agentBlackboard.GetVariableValue<float>("Oxygen");
				currentOxygen -= 5;
                agentBlackboard.SetVariableValue("Oxygen", currentOxygen);
				t = 0;
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
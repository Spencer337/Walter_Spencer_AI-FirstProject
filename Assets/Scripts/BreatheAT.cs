using NodeCanvas.Framework;
using ParadoxNotion.Design;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace NodeCanvas.Tasks.Actions {

	public class BreatheAT : ActionTask {
        public BBParameter<float> breatheInterval;
        public float t;
		Blackboard agentBlackboard;
		public float currentOxygen;
		public TextMeshProUGUI oxygenText;

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
			// Increase t by time
			t += Time.deltaTime;
			// If t is greater than the breathe interval
			if (t >= breatheInterval.value)
			{
				// Decrease the oxygen value by 5
                currentOxygen = agentBlackboard.GetVariableValue<float>("Oxygen");
				currentOxygen -= 5;
                agentBlackboard.SetVariableValue("Oxygen", currentOxygen);
				// Set t back to 0
				t = 0;
            }
			// Update the oxygen text on the UI with the current oxygen value
			oxygenText.text = currentOxygen.ToString();
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}
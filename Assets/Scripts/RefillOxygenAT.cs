using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class RefillOxygenAT : ActionTask {
        public BBParameter<GameObject> astronautObject;
        public BBParameter<float> refillRate;
        Blackboard otherBlackboard;

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
            
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			// Get the oxygen value off the astronaut's blackboard and store it in the currentOxygen float
            float currentOxygen = otherBlackboard.GetVariableValue<float>("Oxygen");

			// Increase currentOxygen by refillRate multiplied by time
            currentOxygen += refillRate.value * Time.deltaTime;

			// Set the oxygen value on the astronaut's blackboard to currentOxygen
            otherBlackboard.SetVariableValue("Oxygen", currentOxygen);
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class AstronautOxygenHighCT : ConditionTask {
        public BBParameter<GameObject> astronautObject;
        public float checkValue;
        Blackboard otherBlackboard;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){
            otherBlackboard = astronautObject.value.GetComponent<Blackboard>();
            return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
            // If the astronatu's oxygen is above the given check value, return true
            if (otherBlackboard.GetVariableValue<float>("Oxygen") >= checkValue)
            {
                return true;
            }
            // Otherwise, return false
            else
            {
                return false;
            }
        }
	}
}
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using TMPro;


namespace NodeCanvas.Tasks.Conditions {

	public class OxygenAboveValueCT : ConditionTask {
        public BBParameter<float> oxygen;
        public float checkValue;
        public BBParameter<bool> isFallingLeft; 

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){
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
            // If the oxygen value is greater than the given check value, return true and change isFallingLeft to the opposite state
            if (oxygen.value > checkValue)
            {
                isFallingLeft.value = !isFallingLeft.value;
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
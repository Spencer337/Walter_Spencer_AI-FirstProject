using NodeCanvas.Framework;
using ParadoxNotion.Design;
using TMPro;


namespace NodeCanvas.Tasks.Conditions {

	public class OxygenBelowValueCT : ConditionTask {
        public BBParameter<float> oxygen;
		public float checkValue;
        public BBParameter<bool> astronautIsMoving;

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
			// If the oxygen is below the given check value, return true and set astronaut is moving to false
			if (oxygen.value <= checkValue)
			{
				astronautIsMoving.value = false;
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
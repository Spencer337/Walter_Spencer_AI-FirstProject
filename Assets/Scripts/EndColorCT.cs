using NodeCanvas.Framework;
using NodeCanvas.Tasks.Actions;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class EndColorCT : ConditionTask {
		public float n;

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
			n = blackboard.GetVariableValue<int>("numberOfColorChanges");

            if (n >= 7)
			{
				Debug.Log(blackboard.GetVariableValue<int>("numberOfColorChanges"));
				return true;
			}
			else
			{
				return false;
			}
			
		}
	}
}
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.UI;


namespace NodeCanvas.Tasks.Conditions {

	public class TalkCheckCT : ConditionTask {
        public BBParameter<TMPro.TMP_InputField> inputField;
        public float randomNumber = 0;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
            if (inputField.value.text != "")
            {
                randomNumber = Random.Range(0f, 100f);
            }
        }

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {

            if (randomNumber > 50)
			{
                randomNumber = 0;
                return true;
			}
			else
			{
				return false;
			}
		}
	}
}
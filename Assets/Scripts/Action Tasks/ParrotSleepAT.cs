using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.UI;


namespace NodeCanvas.Tasks.Actions {

	public class ParrotSleepAT : ActionTask {
		public BBParameter<float> sleepValue;
		public BBParameter<Slider> sleepSlider;
		public float fillRate;


		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			// While sleeping, increase the sleep need value by fill rate by time
			sleepValue.value += fillRate * Time.deltaTime;
			// Set the sleep slider to the sleep need value
			sleepSlider.value.value = sleepValue.value;
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}
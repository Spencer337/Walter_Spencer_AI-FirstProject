using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.InputSystem.Utilities;
using UnityEngine;
using UnityEngine.UI;


namespace NodeCanvas.Tasks.Actions {

	public class ParrotEatAT : ActionTask {
        public BBParameter<float> hungerValue;
        public BBParameter<Slider> hungerSlider;
        public float increaseValue;
        public float maxTime;
        private float t;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            t = 0;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            // Increase t by time
            t += Time.deltaTime;
            // If t is greater than max time
            if (t >= maxTime)
            {
                // Increase the hunger value and update the need slider
                hungerValue.value -= increaseValue;
                hungerSlider.value.value = hungerValue.value;
                // Reset t to 0
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
using NodeCanvas.Framework;
using NUnit.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.UI;


namespace NodeCanvas.Tasks.Actions {

	public class SquawkAT : ActionTask {
        public BBParameter<float> socialValue;
		public BBParameter<AudioClip> squawkSound;
		public BBParameter<GameObject> soundSprite;
        public BBParameter<Slider> socialSlider;
        public float increaseValue;
		public float maxTime;
		public float t;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			// Play the squawk audio clip
            AudioSource.PlayClipAtPoint(squawkSound.value, agent.transform.position);
			// Set the sound sprite to visible
            soundSprite.value.SetActive(true);
			// Reset t to 0
			t = 0;
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			// Increase t by time
			t += Time.deltaTime;
			// If t is greater than max time, increase the social need by a set value and update the slider
			// Set the sound sprite to false
			if (t >= maxTime)
			{
                socialValue.value += increaseValue;
                socialSlider.value.value = socialValue.value;
                soundSprite.value.SetActive(false);
				t = 0;
                EndAction(true);
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
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.UI;


namespace NodeCanvas.Tasks.Actions {

	public class ParrotTalkAT : ActionTask {
        public BBParameter<float> socialValue;
        public BBParameter<Slider> socialSlider;
        public BBParameter<TMPro.TMP_Text> speakText;
		public BBParameter<TMPro.TMP_InputField> inputField;
        public float increaseValue;
        public float maxTime;
        public float t; 
        public BBParameter<AudioClip> talkSound;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            // Play the talk audio clip
            AudioSource.PlayClipAtPoint(talkSound.value, agent.transform.position);
            // Set the text above the parrot to the text in the input field
            speakText.value.text = inputField.value.text;
            // Reset t to 0
            t = 0;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            // Increase t by time
            t += Time.deltaTime;
            // If t is greater than max time, increase the social need by a set value and update the slider
            // Set the text above the parrot to nothing
            if (t >= maxTime)
            {
                socialValue.value += increaseValue;
                socialSlider.value.value = socialValue.value;
                speakText.value.text = "";
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
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Xml.Schema;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ChangeColorAT : ActionTask {
		public int numberOfChanges = 0;
		public int totalChanges = 7;

		public float t = 0;
		public float waitTime = 1;

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
			t += Time.deltaTime;
			if(t >= waitTime)
			{
                agent.GetComponent<Renderer>().material.color = Random.ColorHSV();
				numberOfChanges++;
				t = 0;
				if (numberOfChanges >= totalChanges)
				{
					numberOfChanges = 0;
					EndAction(true);
				}
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
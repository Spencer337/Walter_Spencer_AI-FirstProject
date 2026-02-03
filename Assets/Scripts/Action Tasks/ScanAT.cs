using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class ScanAT : ActionTask {
		public Color scanColour;
		public int numberOfScanCirclePoints;
		public BBParameter<float> scanRadius;
		public BBParameter<float> initialScanRadius; 
		public LayerMask targetMask;
		public float scanSpeed = 1f;
		public BBParameter<Transform> targetTransform; 

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			scanRadius.value = initialScanRadius.value;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

			DrawCircle(agent.transform.position, scanRadius.value, scanColour, numberOfScanCirclePoints);

			Collider[] objectsInRange = Physics.OverlapSphere(agent.transform.position, scanRadius.value, targetMask);
			foreach (Collider objectInRange in objectsInRange)
			{
				Blackboard lighthouseBlackboard = objectInRange.gameObject.GetComponentInParent<Blackboard>();
				if(lighthouseBlackboard == null)
				{
                    Debug.LogError("Failed to get lighthouse blackboard off of lighthouse layered object[" + objectInRange.gameObject.name + "].");
					continue;
                }
				float repairValue = lighthouseBlackboard.GetVariableValue<float>("repairValue");
				if(repairValue <= 0)
				{
					// Set our target to the specific lighthouse we scanned
					targetTransform.value = lighthouseBlackboard.GetVariableValue<Transform>("workpad");
                    EndAction(true);
                }
				
			}
			scanRadius.value += scanSpeed * Time.deltaTime;
		}

		private void DrawCircle(Vector3 center, float radius, Color colour, int numberOfPoints)
		{
			Vector3 startPoint, endPoint;
			int anglePerPoint = 360 / numberOfPoints;
			for (int i = 1; i <= numberOfPoints; i++)
			{
				startPoint = new Vector3(Mathf.Cos(Mathf.Deg2Rad * anglePerPoint * (i-1)), 0, Mathf.Sin(Mathf.Deg2Rad * anglePerPoint * (i-1)));
				startPoint = center + startPoint * radius;
				endPoint = new Vector3(Mathf.Cos(Mathf.Deg2Rad * anglePerPoint * i), 0, Mathf.Sin(Mathf.Deg2Rad * anglePerPoint * i));
				endPoint = center + endPoint * radius;
				Debug.DrawLine(startPoint, endPoint, colour);
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
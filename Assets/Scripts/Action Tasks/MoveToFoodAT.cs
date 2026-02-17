using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.AI;
using UnityEngine;
using static UnityEditor.U2D.ScriptablePacker;


namespace NodeCanvas.Tasks.Actions {

	public class MoveToFoodAT : ActionTask {

        public BBParameter<NavMeshAgent> navAgent;
		public BBParameter<Transform> foodTransform;
        public BBParameter<GameObject> foodSprite;
        public float t;
        public Vector3 startPos, endPos;
        public float flySpeed;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            // Set the start position to the parrot's position
            startPos = agent.transform.position;
            // Set the end position to the food bowl's transform 
            endPos = foodTransform.value.position;
            // Raise the end point by half the parrot's height
            endPos.y += agent.transform.localScale.y / 2;
            // Move the end point to the right of the food bowl
            endPos.x += foodTransform.value.localScale.x / 2;
            // Stop updating the transform to be synchronized with the nav agent
            navAgent.value.updatePosition = false;
            // Rotate the parrot to look at the destination point
            agent.transform.LookAt(endPos);
            // Set the food sprite to be visible
            foodSprite.value.SetActive(true);
		}

        //Called once per frame while the action is active.
		protected override void OnUpdate() {
            // Increase t by time multiplied by fly speed
            t += Time.deltaTime * flySpeed;
            // Lerp the parrot's position between the start and end
            agent.transform.position = Vector3.Lerp(startPos, endPos, t);
            // If t is greater than 1, reset t and set isFlying to false
            if (t >= 1)
            {
                // Teleport the parrot back onto the nav mesh at the current position
                navAgent.value.Warp(agent.transform.position);
                t = 0;
                // Start updating the transform to be synchronized with the nav agent
                navAgent.value.updatePosition = true;
                // Rotate the parrot to look at the destination point again
                agent.transform.LookAt(endPos);
                // Set the food sprite to be invisible
                foodSprite.value.SetActive(false);
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
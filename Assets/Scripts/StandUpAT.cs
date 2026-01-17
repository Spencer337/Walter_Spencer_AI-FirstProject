using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class StandUpAT : ActionTask {
        public GameObject astronautPivot;
        Blackboard agentBlackboard;
        public float standingSpeed;
        public float t;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit()
        {
            agentBlackboard = agent.GetComponent<Blackboard>();
            return null;
        }

        //This is called once each time the task is enabled.
        //Call EndAction() to mark the action as finished, either in success or failure.
        //EndAction can be called from anywhere.
        protected override void OnExecute()
        {
            if (astronautPivot.transform.rotation.z > 0)
            {
                t = 90;
            }
            if (astronautPivot.transform.rotation.z < 0)
            {
                t = -90;
            }
        }

        //Called once per frame while the action is active.
        protected override void OnUpdate()
        {
            if (astronautPivot.transform.rotation.z > 0)
            {
                t -= Time.deltaTime * standingSpeed;
                if (t < 0)
                {
                    //Debug.Log("Test");
                    //astronautPivot.transform.eulerAngles = new Vector3(0, 0, 0);
                    t = 0;
                    EndAction(true);
                }

            }
            else if (astronautPivot.transform.rotation.z < 0)
            {
                t += Time.deltaTime * standingSpeed;
                if (t > 0)
                {
                    //Debug.Log("Test");
                    //astronautPivot.transform.eulerAngles = new Vector3(0, 0, 0);
                    t = 0;
                    EndAction(true);
                }
            }
            astronautPivot.transform.eulerAngles = new Vector3(0, 0, t);
        }

        //Called when the task is disabled.
        protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}
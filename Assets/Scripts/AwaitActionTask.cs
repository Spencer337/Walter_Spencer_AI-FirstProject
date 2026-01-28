using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{

	public class AwaitActionTask : ActionTask
	{
		public float maxWaitTime;
		public float minWaitTime;
		public float t;

		protected override string OnInit(){
            return null;
		}


		protected override void OnExecute()
		{
			t = 0;
		}


		protected override void OnUpdate()
		{
			//Wait a random amount of time between two values
			t += Time.deltaTime;
			if (t > maxWaitTime)
			{
				EndAction();
			}
        }

        //Called when the task is disabled.
        protected override void OnStop(){
			
		}

		//Called when the task is paused.
		protected override void OnPause(){
			
		}
	}
}
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions{

	public class AwaitActionTask : ActionTask{
		public float maxWaitTime;
		public float minWaitTime;
		private float chosenWaitTime;
		private float timeWaiting = 0f;

		protected override string OnInit(){
            return null;
		}


		protected override void OnExecute(){
			chosenWaitTime = UnityEngine.Random.Range(minWaitTime, maxWaitTime);
			timeWaiting = 0f;
		}


		protected override void OnUpdate() {

			//Wait a random amount of time between two values
			timeWaiting += Time.deltaTime;
			if (timeWaiting > chosenWaitTime)
			{
				EndAction(true);
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
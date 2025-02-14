using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System;
using System.Collections;


namespace NodeCanvas.Tasks.Actions {

	public class SendSignalAT : ActionTask {

		public BBParameter<bool> signal;
		public int frameDelay;


		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		IEnumerator FrameDelay()
		{
			for(int i = 0; i<frameDelay; i++)
			{
				yield return new WaitForEndOfFrame();
			}
			signal.value = false;
			EndAction(true);
		}


		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			signal.value = true;
			StartCoroutine(FrameDelay());
			EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}
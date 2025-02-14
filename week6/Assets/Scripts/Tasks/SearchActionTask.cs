using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.AI;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions{

	public class SearchActionTask : ActionTask{
		public float searchRadius;
		private NavMeshAgent navAgent;

		protected override string OnInit(){
			navAgent = agent.GetComponent<NavMeshAgent>();
			return null;
		}

		protected override void OnExecute(){
			Vector3 randomPoint = Random.insideUnitSphere * searchRadius + agent.transform.position;

			//Choose a random destination on the navmesh
			NavMeshHit navHit;
			if (!NavMesh.SamplePosition(randomPoint, out navHit, searchRadius, NavMesh.AllAreas))
			{
				return;
			}

			//Set the path to that position
			navAgent.SetDestination(navHit.position);

            
        }

		protected override void OnUpdate(){
			//When they have arrived then end the task
			if (!navAgent.pathPending && navAgent.remainingDistance <= navAgent.stoppingDistance)
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
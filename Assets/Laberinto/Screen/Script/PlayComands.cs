using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayComands : MonoBehaviour {

	private Queue<int> instructions;
	const int FORWARD = 1;
	const int TURN_RIGHT = 2;
	const int TURN_LEFT = 3;

	private bool isExecuting;
	private bool execute;
	private Vector3 targetPosition;

	public GameObject robot;

	void Start () {
		instructions = new Queue<int>();
		isExecuting = false;
		execute = false;
		robot.transform.Rotate (Vector3.up * 90f);
		targetPosition = robot.transform.position;
	}

	void Update () {
		if (execute) {
			int inst = 0;
			if (!isExecuting) {
				if (instructions.Count != 0) {
					inst = instructions.Dequeue ();
					Debug.Log ("asd" + inst);
					Debug.Log (robot.transform.rotation.x + " " + robot.transform.rotation.y + " " + robot.transform.rotation.z);
					switch (inst) 
					{
					case FORWARD:
						//robot.transform.Translate (Vector3.forward * 3);
						targetPosition = robot.transform.position + robot.transform.forward * 3;
						isExecuting = true;
						break;
					case TURN_RIGHT:
						robot.transform.Rotate (Vector3.up * 90f);
						break;
					case TURN_LEFT:
						robot.transform.Rotate (Vector3.up * -90f);
						break;
					default:
						break;
					}
				} else {
					execute = false;
				}
			}
		}

		if (Vector3.Distance (robot.transform.position, targetPosition) < 0.1f) {
		//if (robot.transform.position.x - targetPosition.x < 0.1f && robot.transform.position.z - targetPosition.z < 0.1f) {
			Debug.Log ("asdtrans");
			isExecuting = false;
		} else {
			Debug.Log ("asdnottrans");
			robot.transform.position = Vector3.MoveTowards (robot.transform.position, targetPosition, Time.deltaTime);
		}

	}

	void SaveInstruction (int dir) {
		Debug.Log ("Added " + dir);
		instructions.Enqueue (dir);
	}

	void OnMouseOver(){
		if(Input.GetMouseButtonDown(0)){
			Debug.Log ("ClickStart");
			execute = true;
		}
	}
}

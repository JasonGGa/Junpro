using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnclickButton : MonoBehaviour {

	public GameObject obj;

	private void OnMouseOver(){
		if(Input.GetMouseButtonDown(0)){
			if (name == "Square1") {
				Debug.Log ("Click1");
				obj.SendMessage ("SaveInstruction", 1);
			}
			else if (name == "Arrow03") {
				Debug.Log ("Click2");
				obj.SendMessage ("SaveInstruction", 2);
			}
			else if (name == "Arrow01") {
				Debug.Log ("Click3");
				obj.SendMessage ("SaveInstruction", 3);
			}
		}
	}
}

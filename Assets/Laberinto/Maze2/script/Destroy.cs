using UnityEngine.UI;
using UnityEngine;

public class Destroy : MonoBehaviour {
	public Text text;
	void OnCollisionEnter(Collision col){
		if (col.gameObject.name == "Arrow"){
			Destroy (col.gameObject);
			text.text = "FELICIDADES! GANO";
		}
	}
}

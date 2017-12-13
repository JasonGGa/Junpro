using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Controller : MonoBehaviour {
    public float velocidadDespzamiento = 10.0f;
    public float velocidadGiro = 10.0f;
    public Button right;
    public Button left;
    public Button down;
    public Button up;

	private Rigidbody rb;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //float horizontal = Input.GetAxis("Mouse X");
        //this.transform.Rotate(Vector3.up * horizontal * velocidadGiro);
        //transform.Translate(0, 0, Input.GetAxis("Vertical") * velocidadDespzamiento * Time.deltaTime);
		//transform.Translate(Input.GetAxis("Horizontal") * velocidadDespzamiento * Time.deltaTime, 0, 0);
        /*right.onClick.AddListener(eventRight);
        left.onClick.AddListener(eventLeft);
        up.onClick.AddListener(eventUp);
        down.onClick.AddListener(eventDown);*/
        /* if (Input.GetKey(KeyCode.UpArrow))
         {
             this.transform.Translate(Vector3.forward * velocidadDespzamiento);
         }

         if (Input.GetKey(KeyCode.DownArrow))
         {
             this.transform.Translate(Vector3.back * velocidadDespzamiento);
         }

         if (Input.GetKey(KeyCode.LeftArrow))
         {
             this.transform.Translate(Vector3.left * velocidadDespzamiento);
         }

         if (Input.GetKey(KeyCode.RightArrow))
         {
             this.transform.Translate(Vector3.right * velocidadDespzamiento);
         }
         */
    }
}
    


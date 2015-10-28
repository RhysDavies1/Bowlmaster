using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

	void OnTriggerExit(Collider collider){
		
		GameObject obj = collider.gameObject;
		
		if (obj.GetComponent<Pin> ()) {
			
			Destroy (obj);
			
		}
		
	}
}

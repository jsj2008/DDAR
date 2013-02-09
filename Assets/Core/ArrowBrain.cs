using UnityEngine;
using System.Collections;

public class ArrowBrain : MonoBehaviour {

	Vector3 myVelocity=Vector3.zero;
	float mult = 0.025f;
	
	
	public void SetVelocity(Vector3 v){
		myVelocity = v;
	}
	
	void Update(){
		if(myVelocity==Vector3.zero)	
			return;
		else 
			MoveThere(myVelocity);
		timeElapsed+=Time.deltaTime;
	}
	
	void MoveThere(Vector3 v){
		transform.position += v * mult;
	}
	
	void OnTriggerEnter(Collider col){
		if(col.name!="Destroyer")
			InputTimer(col.name);
		else Destroy (gameObject);
	}
	
	void InputTimer(string name){
		// wait for hit and do something
		
	}
	
}

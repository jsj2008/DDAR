using UnityEngine;
using System.Collections;

public class ArrowBrain : MonoBehaviour {

	Vector3 myVelocity=Vector3.zero;
	float mult = 0.025f;
	float timeElapsedAfterCollide=10f;
	
	public void SetVelocity(Vector3 v){
		myVelocity = v;
	}
	
	void Update(){
		if(myVelocity==Vector3.zero)	
			return;
		else 
			MoveThere(myVelocity);
		timeElapsedAfterCollide+=Time.deltaTime;
		if(timeElapsedAfterCollide<9&&timeElapsedAfterCollide>1.37f)
			DeactivateSelf();
	}
	
	void DeactivateSelf(){
		// gesturehit flag off
		Destroy (gameObject);	
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
		// gesturehitflag
		timeElapsedAfterCollide = 0f;
	}
	
}

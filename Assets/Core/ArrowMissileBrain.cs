using UnityEngine;
using System.Collections;

public class ArrowMissileBrain : ArrowBrain {
	
	Vector3 startPos;
	
	void Start(){
		Init();
		startPos = new Vector3(Random.Range (-10,10f),Random.Range (-10,10f),0); 
		transform.position = startPos;
		SetVelocity(Vector3.zero - startPos);	
	}
	
}

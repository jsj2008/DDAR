using UnityEngine;
using System.Collections;

public class ArrowBrain : MonoBehaviour {

	Vector3 myVelocity=Vector3.zero;
	float mult = 0.025f;
	float timeElapsedAfterCollide=10f;
	
	int whichHitTag=-1; 
	
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
		if(whichHitTag==1)
			ScoreKeeper.SetHitTag1 (ScoreKeeper.TheHitTags.None);
		else if(whichHitTag==2)
			ScoreKeeper.SetHitTag2 (ScoreKeeper.TheHitTags.None);
		whichHitTag=-1;
		
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
		if(name=="Right"||name=="Bottom"||name=="Front"){
			ScoreKeeper.SetHitTagString (2,name);
			whichHitTag=2;
		}else{
			ScoreKeeper.SetHitTagString(1,name);
			whichHitTag=1;
		}
		
		// set timer to critical point period 
		timeElapsedAfterCollide = 0f;
	}
	
}

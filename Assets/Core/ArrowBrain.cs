using UnityEngine;
using System.Collections;

public class ArrowBrain : MonoBehaviour {

	Vector3 myVelocity=Vector3.zero;
	float mult = 0.025f;
	float timeElapsedAfterCollide=10f;
	
	int whichHitTag=-1; 
	string hitWall="None";
	
	WallControls wallcontrols;
	
	void Start(){
		wallcontrols = GameObject.Find ("Generator").GetComponent<WallControls>();
	}
	
	public void SetVelocity(Vector3 v){
		myVelocity = v;
	}
	
	void Update(){
		if(myVelocity==Vector3.zero)	
			return;
		else 
			MoveThere(myVelocity);
		timeElapsedAfterCollide+=Time.deltaTime;
		if(timeElapsedAfterCollide<9&&timeElapsedAfterCollide>0.5f)
			DeactivateSelf();
	}
	
	void DeactivateSelf(){
		// gesturehit flag off
		ScoreKeeper.SetOff (whichHitTag,hitWall);
		whichHitTag=-1;
		hitWall="None";
		
		Destroy (gameObject);	
	}
	
	void MoveThere(Vector3 v){
		transform.position += v * mult;
	}
	
	void OnTriggerEnter(Collider col){
		if(col.name!="Destroyer"){
			if(col.name!="Arrow"&&col.name!="BodyBouncer"){
				
				InputTimer(col.name);
				wallcontrols.GlowWall(col.gameObject);
				
			}
		}
		else Destroy (gameObject);
	}
	
	void InputTimer(string name){
		hitWall = name;
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

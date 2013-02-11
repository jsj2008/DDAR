using UnityEngine;
using System.Collections;

public class ArrowBrain : MonoBehaviour {

	Vector3 myVelocity=Vector3.zero;
	float mult = 0.005f;
	float timeElapsedAfterCollide=10f;
	
	int whichHitTag=-1; 
	string hitWall="None";
	
	bool hitSphereNormal=false;
	
	//WallControls wallcontrols;
	
	void Start(){
		Init ();	
	}
	
	public void Init(){
		//this.wallcontrols = GameObject.Find ("Generator").GetComponent<WallControls>();
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
		
		if(hitSphereNormal){
			if(timeElapsedAfterCollide>0.05f)
			{
				ScoreKeeper.IncFail ();
				Destroy (gameObject);
			}
		}else {
		
			if(timeElapsedAfterCollide<9&&timeElapsedAfterCollide>0.75f)
				DeactivateSelf();
		}
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
			if(col.name!="Arrow"&&col.name!="BodyBouncer"&&col.name!="Cylinder"){
				
				if(col.name=="sphere-normal"){
					InputTimerCenter();
				}else if(col.name=="DinoHead"){//print ("H");
					ScoreKeeper.HitArrow();
					Destroy (gameObject);
					
				}else{
					InputTimer(col.name);print (col.name+" entered");
					WallControls.GlowWall(col.gameObject);
				}
				
			}
		}
		else Destroy (gameObject);
	}
	
	void InputTimerCenter(){
		hitSphereNormal=true;
		timeElapsedAfterCollide = 0f;	
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

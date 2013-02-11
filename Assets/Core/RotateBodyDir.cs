using UnityEngine;
using System.Collections;

public class RotateBodyDir : MonoBehaviour {
	
	public Transform goBounceObject;
	
	public void DetermineDir(Vector3 p){
		transform.up = new Vector3(p.x,p.y,0);
		
	}
	
	void Update(){
		DetermineDir(goBounceObject.transform.position);	
		
		if(BodyBlurb.currentScale.magnitude>10)
			BopHead();
	}
	
	void BopHead(){
		if(transform.childCount<1)return;
		transform.GetChild (0).animation.Play ();
	}
	
}

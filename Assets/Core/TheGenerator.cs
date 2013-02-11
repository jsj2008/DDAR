using UnityEngine;
using System.Collections;

public class TheGenerator : MonoBehaviour {
	
	public GameObject goArrow;
	
	float timeElapsed=0f;
	float nextRandomInterval=0f;
	
	void Start () {
		
	}
	
	/* used to test, probably want to use GenArrow* directly with music */
	void GenRandomSequence(){
		timeElapsed+=Time.deltaTime;
		if(timeElapsed>nextRandomInterval){
			nextRandomInterval = Random.Range (1.37f,3.14f);
			timeElapsed=0f;
			GenArrowRand();
			ScoreKeeper.IncArrow();
		}
	}
	
	void GenArrowRand(){
		GenArrow(Random.Range (-1,2),Random.Range (-1,2),0);	
	}
	
	private void GenArrow(int dirx,int diry,int dirz){
		// project orthogonal dir only
		int axis = Random.Range (0,3);
		if(axis==0){diry=0;dirz=0;}
		else if(axis==1){dirx=0;dirz=0;}
		else {dirx=0;diry=0;}
		// generate arrow and assign dir (velocity)
		Vector3 v = new Vector3(dirx,diry,dirz);
		//print (v);
		GameObject g = Instantiate(goArrow,Vector3.zero,Quaternion.identity) as GameObject;
		if(g==null)return;
		ArrowBrain ab = g.GetComponent<ArrowBrain>();
		ab.SetVelocity(v);
		g.name = "Arrow";
	}
	
	void Update () {
		GenRandomSequence();
	}
}

using UnityEngine;
using System.Collections;

public class ArrowMissileBrain : ArrowBrain {
	
	Vector3 startPos;
	
	public Texture[] texEnemies=new Texture[3];
	
	void Start(){
		Init();
		int type = Random.Range (0,2);
		if(type!=0)
			transform.localScale = new Vector3(0.01f,3,6);
		renderer.material.mainTexture = texEnemies[type];
		while(startPos.magnitude < 25)
			startPos = new Vector3(Random.Range (-25,25f),Random.Range (-25,25),0); 
		transform.position = startPos;
		if(startPos.x<0)
			transform.forward = -startPos;
		else 
			transform.forward = startPos;
		SetVelocity(Vector3.zero - startPos);	
	}
	
}

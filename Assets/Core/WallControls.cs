using UnityEngine;
using System.Collections;

public class WallControls : MonoBehaviour {

	public void GlowWall(GameObject g){
		iTween.ColorFrom (g,new Color(1,1,1,1),0.5f);	
	}
	
}

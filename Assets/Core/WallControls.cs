using UnityEngine;
using System.Collections;

public class WallControls : MonoBehaviour {

	public static void GlowWall(GameObject g){//print (g.name);
		iTween.ColorFrom (g,new Color(1,1,1,1),0.5f);	
	}
	
}

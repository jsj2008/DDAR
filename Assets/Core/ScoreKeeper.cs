using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {
	
	static int arrows=0;
	static int arrowsHit=0;
	
 	static GUIText guiArrows;
	static GUIText guiArrowsHit;
	
	void Start(){
		guiArrows = GameObject.Find ("guiArrows").guiText;
		guiArrowsHit = GameObject.Find ("guiArrowsHit").guiText;
	}
	
	public static void IncArrow(){
		arrows++;
		guiArrows.text = arrows.ToString();
	}
	
	public static void HitArrow(){
		arrowsHit++;
		guiArrowsHit.text = arrowsHit.ToString();
	}
}

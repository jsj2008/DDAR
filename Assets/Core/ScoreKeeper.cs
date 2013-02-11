using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {
	
	static int arrows=0;
	static int arrowsHit=0;
	static int arrowsFail=0;
	
 	static GUIText guiArrows;
	static GUIText guiArrowsHit;
	static GUIText guiArrowsFail;
	
	public enum TheHitTags{
		None,
		Top,
		Bottom,
		Left,
		Right,
		Back,
		Front
	}
	
	static TheHitTags hitTag1 = TheHitTags.None;
	static TheHitTags hitTag2 = TheHitTags.None;
	
	public static void SetOff(int num,string wall){
		if(num==1&&hitTag1.ToString()==wall)hitTag1 = TheHitTags.None;
		else if(num==2&&hitTag2.ToString()==wall)hitTag2 = TheHitTags.None;
	}
	
	public static void CheckHitTag(string what){
		if(what==hitTag1.ToString()||what==hitTag2.ToString ())
			HitArrow ();
	}
	
	public static void SetHitTagString(int num,string what){
		foreach(TheHitTags tht in System.Enum.GetValues(typeof(TheHitTags))){
			if(tht.ToString()==what)	{
				if(num==1)hitTag1=tht;
				else if(num==2)hitTag2=tht;
				return;	
			}
		}
	}
	public static void SetHitTag1(TheHitTags t1){
		hitTag1 = t1;
	}
	public static void SetHitTag2(TheHitTags t2){
		hitTag2 = t2;
	}	
	
	void Start(){
		guiArrows = GameObject.Find ("guiArrows").guiText;
		guiArrowsHit = GameObject.Find ("guiArrowsHit").guiText;
		guiArrowsFail = GameObject.Find ("guiArrowsFail").guiText;
	}
	
	public static void IncArrow(){
		arrows++;
		guiArrows.text = "Enemies: "+arrows.ToString();
	}
	
	public static void HitArrow(){
		arrowsHit++;
		guiArrowsHit.text = "Score: "+arrowsHit.ToString();
	}
	
	public static void IncFail(){
		arrowsFail++;	
		guiArrowsFail.text = "Missed: "+arrowsFail.ToString();
	}
	
	public static int GetFails(){
		return arrowsFail;	
	}
	
	public static int GetHits(){
		return arrowsHit;	
	}	
}

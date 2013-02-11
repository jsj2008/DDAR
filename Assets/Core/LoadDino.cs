using UnityEngine;
using System.Collections;

public class LoadDino : MonoBehaviour {
	
	string selectedChar="TheDino";
	
	void Start(){
		if(PlayerPrefs.GetString ("SelectedCharName").Length>2)
			selectedChar = PlayerPrefs.GetString ("SelectedCharName");
		GameObject g = GameObject.Find(selectedChar); 
		g.transform.position = new Vector3(0,-7.147293f,2.506405f);
		g.transform.localScale = new Vector3(58.60936f,58.60936f,58.60936f);
		g.transform.parent = transform;
		g.animation.wrapMode = WrapMode.Once;
	}
	
}

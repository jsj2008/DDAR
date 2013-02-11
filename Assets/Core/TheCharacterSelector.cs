using UnityEngine;
using System.Collections;

public class TheCharacterSelector : MonoBehaviour {
	
	public GameObject[] goChars = new GameObject[5];
	
	public int currentInt=-1;
	
	public GUIText guiName;
	
	
	string lastSelected="None";
	
	BodyBlurbSelect bbs;
	
	void Start(){
		bbs = GetComponent<BodyBlurbSelect>();
	}
	
	private void SelectDino(int index){
		PlayerPrefs.SetString ("SelectedCharName",goChars[index].name);	
	}
	
	void GoNext(){
		
		if(currentInt!=-1){
			SelectDino (currentInt);
			Application.LoadLevel("bubble");	
		}
	}
	
	void OnTriggerEnter(Collider col){print (col.name);
		if(col.name=="Left"){
			if(currentInt<=0)
				currentInt=0;
			else
				currentInt--;
			ShowDino();
		}else if(col.name=="Right"){
			
			if(currentInt<(goChars.Length-1))
				currentInt++;
			else
				currentInt=goChars.Length-1;
			ShowDino();
		}
	}
	
	void ShowDino(){
		for(int i=0;i<goChars.Length;i++){
			if(i!=currentInt)
				goChars[i].transform.position = new Vector3(-9999,-9999,-9999);	
			else{
				goChars[i].transform.position = new Vector3(0,-4.010468f,0);
				guiName.text = goChars[i].name;
			}	
		}
	}
	
	void OnGUI(){
		if(GUI.Button (new Rect(Screen.width-120-10,Screen.height-120-10,100,100),">")){
			bbs.flip = false;
			GoNext();
		}
	}
	
}

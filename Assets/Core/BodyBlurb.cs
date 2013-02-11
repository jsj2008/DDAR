using UnityEngine;
public class BodyBlurb : MonoBehaviour, IBGBodyReadingListener{
	public int player = 0;
	private Vector3 startPosition;
	private Vector3 startScale;
	
	public static Vector3 currentScale;
		
	void Start(){
		BGMotionManager.GetInstance().AddBodyReadingListener(this);
		BGMotionManager.GetInstance().SetPlayerCount(1);
		startPosition = transform.position;
		startScale = transform.localScale;
	}
	 
	public void HandleReading(BGBodyReading reading) {//print ("HI");
		//there is a reading generated for each player id each camera frame, check that we're reading the right one. 
		if(player == reading.GetPlayer()){
			//move based on the reading values!
			transform.position = startPosition + new Vector3(reading.GetX()*10.0f, reading.GetY()*10.0f, 0.0f);
			//transform.localRotation = Quaternion.Euler(new Vector3(0, 0, reading.GetTilt()*Mathf.Rad2Deg));
			currentScale = startScale * reading.GetScale() * 2.0f;	
		}
	}
	
	void OnTriggerEnter(Collider col){
		ScoreKeeper.CheckHitTag(col.name);
	}
}
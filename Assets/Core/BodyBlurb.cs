using UnityEngine;
public class BodyBlurb : MonoBehaviour, IBGBodyReadingListener{
	public int player = 0;
	private Vector3 startPosition;
	private Vector3 startScale;
		
	void Start(){
		BGMotionManager.GetInstance().AddBodyReadingListener(this);
		BGMotionManager.GetInstance().SetPlayerCount(1);
		startPosition = transform.position;
		startScale = transform.localScale;
	}
	 
	public void HandleReading(BGBodyReading reading) {
		//there is a reading generated for each player id each camera frame, check that we're reading the right one. 
		if(player == reading.GetPlayer()){
			//move based on the reading values!
			transform.position = startPosition + new Vector3(reading.GetX()*10.0f, reading.GetY()*10.0f, 0.0f);
			//transform.localRotation = Quaternion.Euler(new Vector3(0, 0, reading.GetTilt()*Mathf.Rad2Deg));
			//transform.localScale = startScale * reading.GetScale() * 2.0f;	
		}
	}
	
	void OnTriggerEnter(Collider col){
		ScoreKeeper.CheckHitTag(col.name);
	}
}
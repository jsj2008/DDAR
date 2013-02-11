using UnityEngine;

public class OxygenGaugeController : MonoBehaviour {
	
	private const int lifespan=10;
	private const int mobileFrameRate=30;
	private float smoothIncrement=(360f/lifespan)/mobileFrameRate;
	private float rotateIncrement=360f/lifespan;
	public float totalRotation=0f;
	public Transform needle;
	public int badHits;
	public int goodHits;
	public Vector3 rotateVector;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		badHits=ScoreKeeper.GetFails();
		if (totalRotation>-badHits*rotateIncrement)
		{
			totalRotation+=-smoothIncrement;
			rotateVector=new Vector3(0f,0f,smoothIncrement);
			//needle.localRotation=Quaternion.Euler (0f,totalRotation,0f);
			//needle.Rotate (Quaternion.Euler(0f,0f,totalRotation));
			needle.Rotate(rotateVector);
		}
		goodHits=ScoreKeeper.GetHits ();
	/*	if (totalRotation>-goodHits*rotateIncrement)
		{
			totalRotation+=smoothIncrement;
			rotateVector=new Vector3(0f,0f,smoothIncrement);
			needle.Rotate(rotateVector);
		}
	*/
	
	}
}

using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine.VR;
using Leap.Unity;
using Leap;

public class ChangeGain : MonoBehaviour {
	public LeapProvider LeapDataProvider;
	public GameObject fingerr0;
	public GameObject fingerr1;
	public GameObject fingerr2;
	public GameObject fingerr3;
	public GameObject fingerr4;
	public GameObject fingerl0;
	public GameObject fingerl1;
	public GameObject fingerl2;
	public GameObject fingerl3;
	public GameObject fingerl4;
	public float gain=1f;
	private int f=1;
	private Vector3 angle;
	// Use this for initialization
	void Start () {
		if (LeapDataProvider == null)
		{
			LeapDataProvider = FindObjectOfType<LeapProvider>();
			if (LeapDataProvider == null || !LeapDataProvider.isActiveAndEnabled)
			{
				Debug.LogError("Cannot use LeapImageRetriever if there is no LeapProvider!");
				enabled = false;
				return;
			}
		}

	}

	
	// Update is called once per frame
	void Update () {
		Frame curFrame = LeapDataProvider.CurrentFrame.TransformedCopy(LeapTransform.Identity);
		for (int whichHand = 0; whichHand < 2; whichHand++) {
			if (curFrame.Hands.Count >whichHand) {

				if (curFrame.Hands [whichHand].IsRight) {
					ChangeFingerGain2 (fingerr0);
					ChangeFingerGain (fingerr1);
					ChangeFingerGain (fingerr2);
					ChangeFingerGain (fingerr3);
					ChangeFingerGain (fingerr4);
					//print ("R");

				} 
				if (curFrame.Hands [whichHand].IsLeft) {
					ChangeFingerGain2 (fingerl0);
					ChangeFingerGain (fingerl1);
					ChangeFingerGain (fingerl2);
					ChangeFingerGain (fingerl3);
					ChangeFingerGain (fingerl4);
					//print ("L");
				}
			}

		

		//print ("z:"+angle.z+"cos:"+getFingerPointing(angle.z));
		}
	}

	 void ChangeFingerGain(GameObject finger){
		angle=finger.transform.localRotation.eulerAngles;
		if (!Regex.IsMatch(gain.ToString(),"^[0-9]+$") && angle.z >= 180f) {
			angle.z = gain * angle.z - gain * 360f;

		} else {
			angle.z = gain * angle.z;
		}

		finger.transform.localRotation = Quaternion.Euler(angle);
		angle=new Vector3();
	}
	void ChangeFingerGain2(GameObject finger){
		angle=finger.transform.localRotation.eulerAngles;
		if (!Regex.IsMatch(gain.ToString(),"^[0-9]+$") && angle.z >= 180f) {
			angle.z = gain * angle.z - gain * 360f;

		} else {
			angle.z = gain * angle.z;
		}

		finger.transform.localRotation = Quaternion.Euler(angle);
		angle=new Vector3();
	}
	public void GainUp(){
		if(gain<1.4f){
			gain +=0.1f ;
		}
	}
	public void GainDown(){
		if(gain>0.6f){
			int temp;
			temp = (int)(gain * 10);
			if (temp > 6) {
				temp -= f;
			}
			gain =float.Parse(temp.ToString())/10 ;

		}
	}
}

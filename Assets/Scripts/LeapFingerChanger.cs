using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;

public class LeapFingerChanger : MonoBehaviour {
	public LeapProvider LeapDataProvider;


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
	

	void Update () {
		Frame currentFrame = LeapDataProvider.CurrentFrame.TransformedCopy(LeapTransform.Identity);
		for (int whichHand = 0; whichHand < 2; whichHand++) {
			if (currentFrame.Hands.Count > whichHand) {
			
				Leap.LeapQuaternion q= currentFrame.Hands [whichHand].Fingers [1].Bone (Bone.BoneType.TYPE_DISTAL).Rotation;
				Quaternion q2 = q.ToQuaternion ();
				print (q2.eulerAngles);
			}
		}
	}
}

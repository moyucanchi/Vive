using UnityEngine;
using System.Collections;
using UnityEngine.VR;
using Leap.Unity;
using Leap;

public class PinchController : MonoBehaviour {
	private float TRIGGER_DISTANCE_RATIO=0.7f;
	public LeapProvider LeapDataProvider;
	private bool isPinky = false;
	private GameObject cube;
	private GameObject hand;
	private Vector3 ProjectionOrigin;
	// Use this for initialization
	void Start () 
	{
		cube = GameObject.Find ("Cube");
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

	void Update() 
	{
		Frame curFrame = LeapDataProvider.CurrentFrame.TransformedCopy(LeapTransform.Identity);

		for (int whichHand = 0; whichHand < 2; whichHand++) {
			if (curFrame.Hands.Count>whichHand) {
				
				if (curFrame.Hands [whichHand].IsRight) {
					ProjectionOrigin = new Vector3 (0.07f,-0.00f,-0.08f);
				} else {
					ProjectionOrigin = new Vector3 (-0.07f,0.00f,-0.08f);
				}
				Vector3 Offset = curFrame.Hands[whichHand].Fingers[1].Bone(Bone.BoneType.TYPE_METACARPAL).Center.ToVector3()-ProjectionOrigin;
				print (curFrame.Hands [whichHand].Fingers [1].Bone (Bone.BoneType.TYPE_METACARPAL).Rotation);

				Vector3 Q = new Vector3(0,0,0);
				//print(Q);
				isPinky = true;

				Q.x = curFrame.Hands [whichHand].PalmNormal.x;
				Q.y = curFrame.Hands [whichHand].PalmNormal.y;
				Q.z = curFrame.Hands [whichHand].PalmNormal.z;

				//cube.transform.SetParent(curFrame.Hand,false) ;
				cube.transform.position = Offset;

				cube.transform.rotation	=Quaternion.Euler(Q);
			}
		}
	}

}

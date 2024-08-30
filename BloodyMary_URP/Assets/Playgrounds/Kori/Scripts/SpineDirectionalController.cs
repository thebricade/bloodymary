using Spine.Unity;
using System.Collections;
using UnityEngine;

public class SpineDirectionalController : MonoBehaviour {

	#region Inspector

		[SerializeField] Transform mainTransform;

		// [SpineAnimation] attribute allows an Inspector dropdown of Spine animation names coming form SkeletonAnimation.
		[SpineAnimation]
		public string FrontIdleAnimationName;

		[SpineAnimation]
		public string ProfileIdleAnimationName;

		[SerializeField] float backAngle = 65f;

		[SerializeField] float sideAngle = 155f;
		#endregion

		SkeletonAnimation skeletonAnimation;

		// Spine.AnimationState and Spine.Skeleton are not Unity-serialized objects. You will not see them as fields in the inspector.
		public Spine.AnimationState spineAnimationState;
		public Spine.Skeleton skeleton;

		
		void Start () {

		Debug.Log("We are in start function");

		// Make sure you get these AnimationState and Skeleton references in Start or Later.
		// Getting and using them in Awake is not guaranteed by default execution order.
		    skeletonAnimation = GetComponent<SkeletonAnimation>();
			spineAnimationState = skeletonAnimation.AnimationState;
			skeleton = skeletonAnimation.Skeleton;

		StartCoroutine(DebbieAnimations());

	}//end start

IEnumerator DebbieAnimations()
	{

        while (true) { 
		Debug.Log("We are in DebbieAnimations");
		//get camera direction
		Vector3 camForwardVector = new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z);
		float signedAngle = Vector3.SignedAngle(mainTransform.forward, camForwardVector, Vector3.up);
		float angle = Mathf.Abs(signedAngle);

		Debug.Log("signedAngle is: "+ signedAngle.ToString());
		Debug.Log("angle is: " + angle.ToString());

		if (angle < backAngle)
			{
			Debug.Log("We are in back");
			//back animation
			spineAnimationState.SetAnimation(0, FrontIdleAnimationName, true);
				yield return new WaitForSeconds(1f);
			}//ends back animation if

			else if (angle < sideAngle)
			{
			
			//flips the side angle
			if (signedAngle < 0)
				{
				Debug.Log("We are in side");
				spineAnimationState.SetAnimation(0, ProfileIdleAnimationName, true);
					yield return new WaitForSeconds(1f);
				}

				else
				{
				Debug.Log("We are in flipped side");
				skeleton.ScaleX = -1;
				spineAnimationState.SetAnimation(0, ProfileIdleAnimationName, true);
					yield return new WaitForSeconds(1f);
				}

			}//ends side angles else if

			else
			{
			//Front animation
			spineAnimationState.SetAnimation(0, FrontIdleAnimationName, true);
				yield return new WaitForSeconds(1f);
			}//ends front animation else
		}
	}//ends IEnumertaor
}//end public class


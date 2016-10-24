using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class moveOnScroll : MonoBehaviour {

	public Scrollbar scrollBar;

	private Vector3 initialPosition;
	private Bounds spaceBounds;
	private float previosScrollPosition;
	private float previosPlayerPosition;
	private float initialPlayerPosition;

	void Start() {
		GameObject group = GameObject.Find("Pictures");
		Vector3 center = Vector3.zero;

		foreach (Transform child in group.transform) {
			center += child.gameObject.GetComponent<Renderer>().bounds.center;  
		}
		center /= group.transform.childCount; //center is average center of children

		// Now you have a center, calculate the bounds by creating a zero sized 'Bounds',
		Bounds bounds = new Bounds(center,Vector3.zero); 

		foreach (Transform child in group.transform) {
			bounds.Encapsulate(child.gameObject.GetComponent<Renderer>().bounds);
		}
		spaceBounds = bounds;
		//    Debug.Log(bounds.size);

		previosScrollPosition = scrollBar.value;
		initialPlayerPosition = transform.position.z;
		previosPlayerPosition = transform.position.z;
	}

	void Update () {
		// Debug.Log (scrollBar.value);
		if (previosScrollPosition != scrollBar.value) {
			float diff = previosScrollPosition - scrollBar.value;
			transform.position = transform.position + Vector3.forward * diff * spaceBounds.size.z;
			previosScrollPosition = scrollBar.value;
			previosPlayerPosition = transform.position.z;
			return;
		}
		if (previosPlayerPosition != transform.position.z) {
			float positionDiff = (initialPlayerPosition - transform.position.z) / spaceBounds.size.z * -1f;
			// Debug.Log (positionDiff);
			positionDiff = Mathf.Clamp(positionDiff, 0f, 1f);
			// Debug.Log (positionDiff);
			scrollBar.value = 1f - positionDiff;
			// Debug.Log (scrollBar.value);
			previosScrollPosition = scrollBar.value;
			previosPlayerPosition = transform.position.z;
		}
	}

}

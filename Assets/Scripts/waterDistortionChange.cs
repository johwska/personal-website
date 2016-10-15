using UnityEngine;
using System.Collections;

public class waterDistortionChange : MonoBehaviour {

	public GameObject customPlayer;
	[Range(0f, 1.5f)]
	public float maximumDistortion = 1f;
	[Range(0f, 1.5f)]
	public float minimumDistortion = 0.26f;

	private float positionDifference;
	private float refractionDistortion;

	void Start () {
		if (customPlayer.Equals(null)) customPlayer = GameObject.Find("FPSController");
	}
	
	void Update () {
		// if (positionDifference == customPlayer.transform.position.y - transform.position.y) return;

		positionDifference = customPlayer.transform.position.y - transform.position.y;
		refractionDistortion = 1.5f - convertRange(positionDifference, 0f, 2.7f, 0f, 1.5f);
		refractionDistortion = Mathf.Clamp(refractionDistortion, minimumDistortion, maximumDistortion);
		GetComponent<Renderer>().material.SetFloat("_RefrDistort", refractionDistortion);
	}

	float convertRange(
		float value,
		float originalStart,
		float originalEnd,
		float newStart,
		float newEnd
	) {
		float originalRange = originalEnd - originalStart;
		float newRange = newEnd - newStart;
		float ratio = newRange / originalRange;
		float newValue = value * ratio;
		float finalValue = newValue + newStart;
		return finalValue;
	}

}

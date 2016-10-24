using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class showAreaTitle : MonoBehaviour {

	[TextArea(3,10)]
	public string title;

	private GameObject player;
	private float minX;
	private float maxX;
	private float minZ;
	private float maxZ;
	private Text caption;
	private bool wasRendered;

	void Start () {
		player = GameObject.Find("FPSController");

		Vector3 center = gameObject.GetComponent<Renderer>().bounds.center;  
		Bounds bounds = new Bounds(center,Vector3.zero); 
		bounds.Encapsulate(gameObject.GetComponent<Renderer>().bounds);
		minX = center.x - bounds.size.x / 2;
		maxX = center.x + bounds.size.x / 2;
		minZ = center.z - bounds.size.z / 2;
		maxZ = center.z + bounds.size.z / 2;

		caption = GameObject.Find("Text").GetComponent<Text>();
		wasRendered = false;
	}

	void Update () {
		if (
			player.transform.position.x > minX
			&& player.transform.position.x < maxX
			&& player.transform.position.z > minZ
			&& player.transform.position.z < maxZ
			) 
		{
			caption.text = title;
			wasRendered = true;
		} else if (wasRendered == true) {
			caption.text = null;
			wasRendered = false;
		}
	}

}

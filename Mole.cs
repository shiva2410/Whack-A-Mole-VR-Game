using UnityEngine;
using System.Collections;

public class Mole : MonoBehaviour {

	public float visibleHeight = 0.2f;
	public float hiddenHeight = -0.3f;
	public float speed = 4f;
	public float disappearDuration = 0.5f;

	private Vector3 targetPosition;
	private float disappearTimer = 0f;

	// Use this for initialization
	void Awake () {
		targetPosition = new Vector3 (
			transform.localPosition.x,
			hiddenHeight,
			transform.localPosition.z
		);

		transform.localPosition = targetPosition;
	}
	
	// Update is called once per frame
	void Update () {
		disappearTimer -= Time.deltaTime;
		if (disappearTimer <= 0f) {
			Hide ();
		}

		transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, Time.deltaTime * speed);
	}

	public void Rise () {
		targetPosition = new Vector3 (
			transform.localPosition.x,
			visibleHeight,
			transform.localPosition.z
		);

		disappearTimer = disappearDuration;
	}

	public void Hide () {
		targetPosition = new Vector3 (
			transform.localPosition.x,
			hiddenHeight,
			transform.localPosition.z
		);
	}

	public void OnHit () {
		Hide ();
	}
}

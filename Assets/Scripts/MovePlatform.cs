using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
	[SerializeField] private float movingLength = 5.0f;
	[SerializeField] private float movingSpeed = 5.0f;
	[SerializeField] private bool isHorizontal = true;

	private Rigidbody2D rbPlatform;
	private Vector2 defaultPosition;

	void Start()
	{
		rbPlatform = GetComponent<Rigidbody2D>();
		defaultPosition = transform.position;
	}

	void FixedUpdate()
	{
		if (isHorizontal) {
			transform.position = new Vector2(defaultPosition.x + Mathf.PingPong(Time.time * movingSpeed, movingLength), defaultPosition.y);
		} else {
			transform.position = new Vector2(defaultPosition.x, defaultPosition.y + Mathf.PingPong(Time.time * movingSpeed, movingLength));
		}
	}
}

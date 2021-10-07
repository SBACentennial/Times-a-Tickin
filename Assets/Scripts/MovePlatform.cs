using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
	[SerializeField] private float movingLength = 5.0f;
	[SerializeField] private float movingSpeed = 5.0f;

	private Rigidbody2D rbPlatform;
	private Vector2 defaultPosition;

	void Start()
	{
		rbPlatform = GetComponent<Rigidbody2D>();
		defaultPosition = transform.position;
	}

	void FixedUpdate()
	{
		rbPlatform.MovePosition(new Vector2(defaultPosition.x + Mathf.PingPong(Time.time * movingSpeed, movingLength), defaultPosition.y));
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCrateController : MonoBehaviour
{
	[SerializeField] private GameObject explosionAnim;
	[SerializeField] private float timeLimit = 3.0f;

	private bool isToched = false;
	private float currentTime = 0.0f;
	private Animator anim;

	void Update() {
		// count timer then explode
		if (isToched) {
			anim = GetComponent<Animator>();
			anim.SetBool("isToched", isToched);
			currentTime = currentTime + Time.deltaTime;

			if (currentTime >= timeLimit) {
				GameObject.Instantiate(explosionAnim, this.transform.position, Quaternion.identity);
				Destroy(this.gameObject);
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D other) {
		// Debug.Log("player touch crate");
		if (other.gameObject.tag == "Player") {
			isToched = true;
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Bullet")) {
			// explode immediately
			GameObject.Instantiate(explosionAnim, this.transform.position, Quaternion.identity);

			Destroy(this.gameObject);
		}
	}
}

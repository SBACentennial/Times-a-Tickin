using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
	private EnemyWalkerScript enemy;

	public void DestroyThis() {
		Destroy(this.gameObject);
	}

	private void OnTriggerEnter2D(Collider2D other) {
        GameObject gameTimer = GameObject.FindWithTag("Timer");
        Timer timerScript = gameTimer.GetComponent<Timer>();
        if (other.gameObject.tag == "Player")
        {
            timerScript.isExplosion = true;
        }

		// if (other.gameObject.tag == "Hazard") {
		// 	enemy.TakeDamage(30);
		// }
	}
}
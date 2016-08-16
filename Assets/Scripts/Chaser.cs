using UnityEngine;
using System.Collections;

public class Chaser : MonoBehaviour {

	public float speed;
	public Transform targetTransform;
	
	// Update is called once per frame
	void Update () {
		Vector3 displacement = targetTransform.position - transform.position;
		if (displacement.magnitude > 1.5)
		{
			Vector3 direction = displacement.normalized;
			Vector3 velocity = direction * speed;
			transform.Translate(velocity * Time.deltaTime);
			
		}
	}
}

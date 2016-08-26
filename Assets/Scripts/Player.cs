using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float moveSpeed;

	Camera viewCamera;
	PlayerController controller;

	void Start () {
		controller = FindObjectOfType<PlayerController>();
		viewCamera = Camera.main;
	}
	
	void Update () {
		Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
		Vector3 moveDirection = moveInput.normalized;
		Vector3 moveVelocity = moveDirection * moveSpeed;
		// Vector3 moveAmount = moveVelocity * Time.deltaTime;
		// transform.Translate(moveAmount);
		controller.Move(moveVelocity);

		Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
		Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
		float rayDistance;

		if (groundPlane.Raycast(ray, out rayDistance)) {
			Vector3 point = ray.GetPoint(rayDistance);
			Debug.DrawLine(ray.origin, point, Color.red);
			controller.LookAt(point);
		}
	}
}

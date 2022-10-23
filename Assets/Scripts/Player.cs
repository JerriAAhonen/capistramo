using System;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{
	[SerializeField] private float movementForce;
	[SerializeField] private float rotationForce;
	[SerializeField] private float collisionForce;
	private Rigidbody rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.A))
		{
			// Rotate left
			rb.AddTorque(Vector3.up * -rotationForce);
		}
		else if (Input.GetKey(KeyCode.D))
		{
			// Rotate right
			rb.AddTorque(Vector3.up * rotationForce);
		}
		
		rb.AddForce(transform.forward * movementForce, ForceMode.Force);
	}

	private void OnCollisionEnter(Collision collision)
	{
		var obs = collision.gameObject.GetComponent<Obstacle>();
		if (obs)
		{
			var dir = (transform.position - obs.transform.position).normalized;
			rb.AddForce(dir * collisionForce, ForceMode.Impulse);
			var ps = obs.DestroyPS;
			var instance = Instantiate(ps);
			instance.transform.position = obs.transform.position;
			
			Destroy(obs.gameObject);
		}
	}
}

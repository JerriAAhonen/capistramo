using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] private Camera cam;
	[SerializeField] private Vector3 offset;
	[SerializeField] private float speed;

	[SerializeField] private float minZoom;
	[SerializeField] private float maxZoom;
	[SerializeField] private float maxPlayerDistance;

	private void LateUpdate()
	{
		Move();
		Zoom();
	}

	private void Move()
	{
		var targetPos = GameManager.Instance.PlayerCenter + offset;
		transform.position = Vector3.Slerp(transform.position, targetPos, Time.deltaTime * speed);
	}

	private void Zoom()
	{
		var fov = Mathf.Lerp(minZoom, maxZoom, GameManager.Instance.PlayerDistanceFromEachother / maxPlayerDistance);
		cam.fieldOfView = fov;
	}
}

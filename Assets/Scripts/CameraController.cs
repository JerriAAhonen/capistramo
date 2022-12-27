using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] private Camera camera;
	[SerializeField] private List<Transform> targets;
	[SerializeField] private Vector3 offset;
	[SerializeField] private float speed;

	[SerializeField] private float minZoom;
	[SerializeField] private float maxZoom;
	[SerializeField] private float maxPlayerDistance;

	private Vector3 centerPoint;
	private float greatestDistance;

	private void LateUpdate()
	{
		if (targets.Count == 0)
			return;

		Refresh();
		Move();
		Zoom();
	}

	private void Move()
	{
		var targetPos = centerPoint + offset;
		transform.position = Vector3.Slerp(transform.position, targetPos, Time.deltaTime * speed);
	}

	private void Zoom()
	{
		var fov = Mathf.Lerp(minZoom, maxZoom, greatestDistance / maxPlayerDistance);
		camera.fieldOfView = fov;
	}

	private void Refresh()
	{
		var bounds = new Bounds(targets[0].position, Vector3.zero);

		foreach (var target in targets)
		{
			bounds.Encapsulate(target.position);
		}

		centerPoint = bounds.center;
		greatestDistance = Mathf.Max(bounds.size.x, bounds.size.z);
	}
}

using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
	[SerializeField] private Obstacle prefab;
	[SerializeField] private Transform player;
	[SerializeField] private int maxObstacles;
	[SerializeField] private float spawnDistance;

	private readonly HashSet<Obstacle> instances = new();

	private void Update()
	{
		if (instances.Count < maxObstacles)
		{
			var rand = Random.insideUnitCircle.normalized;
			var dir = new Vector3(rand.x, 0, rand.y);
			var pos = transform.position + dir * spawnDistance;
			
			var hitColliders = Physics.OverlapSphere(pos, 2);
			if (hitColliders.Length > 0)
				return;
			
			var obs = Instantiate(prefab);
			obs.Init(this, player, spawnDistance + 20f);
			obs.transform.position = pos;
			instances.Add(obs);
		}
	}

	public void Remove(Obstacle obs)
	{
		instances.Remove(obs);
	}
}
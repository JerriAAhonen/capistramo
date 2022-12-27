using UnityEngine;
using Random = UnityEngine.Random;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private ParticleSystem destroyPS;
    
    private Vector3 rotation;
    private ObstacleSpawner obsSpawner;
    private float despawnDist;

    public ParticleSystem DestroyPS => destroyPS;
    
    private void Start()
    {
        rotation = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }

    public void Init(ObstacleSpawner spawner, float despawnDistance)
    {
        obsSpawner = spawner;
        despawnDist = despawnDistance;
    }

    private void Update()
    {
        transform.Rotate(rotation);

        if ((transform.position - GameManager.Instance.PlayerCenter).sqrMagnitude > Mathf.Pow(despawnDist, 2) + Mathf.Pow(GameManager.Instance.PlayerDistanceFromEachother, 2))
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        obsSpawner.Remove(this);
    }
}

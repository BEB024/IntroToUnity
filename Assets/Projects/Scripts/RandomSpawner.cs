using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject prefab;
    public int count = 5;
    // public color z;

    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 pos = new Vector3(i * 2f, 1f, 0);
            GameObject go = Instantiate(prefab, pos, Quaternion.identity);
            var renderer = go.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = new Color(Random.value, Random.value, Random.value);
                // renderer.material.color = z;
            }
        }
    }
}
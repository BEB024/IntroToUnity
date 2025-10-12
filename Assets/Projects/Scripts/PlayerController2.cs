using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>(); // cache component
        Debug.Log("Awake: rb cached");
    }
    void Start()
    {
        Debug.Log("Start: game begins");
    }
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, 0, v).normalized;
        // non-physics movement
        transform.Translate(dir * moveSpeed * Time.deltaTime);
    }
    void FixedUpdate()
    {
        // use for physics: e.g., rb.MovePosition(...)
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with " + collision.gameObject.name);
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by " + other.gameObject.name);
    }
}
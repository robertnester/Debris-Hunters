using UnityEngine;
using System.Collections;

public class MoveTowards : MonoBehaviour
{
    // Adjust the speed for the application.
    public float speed = 1.0f;
    public Gun gunscript;
    // The target (cylinder) position.
    public Transform target;

    void Awake()
    {
        gunscript = GameObject.FindObjectOfType<Gun>();

    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

    }
    private void OnCollisionEnter(Collision collision)
    {
        gunscript.asteroid.value -= 1;
        print("boom");
        Destroy(this.gameObject); 
    }
}
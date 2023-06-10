using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public GameObject target;
    public float bulletSpeed = 5f;

    private Rigidbody rb;

    bool isRed = false;
    bool isBlue = false;

    private void Start()
    {
        if (this.CompareTag("redBullet")) 
        {
            target = GameObject.Find("MrHan");
            isRed = true;
        }
        else if (this.CompareTag("blueBullet"))
        {
            //target = GameObject.Find("MrHan");
            isBlue = true;
        }
        
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 direction = target.transform.position - transform.position;
            rb.velocity = direction.normalized * bulletSpeed;
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
        else
        {
            // If the target is lost, destroy the bullet
            Destroy(gameObject);
        }
    }
}
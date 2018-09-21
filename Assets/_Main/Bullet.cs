using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shootable")
        {
            Debug.Log("Hit " + collision.gameObject.name );
            var hit = collision.gameObject;
            var health = hit.GetComponentInParent<Health>();
            if (health != null)
            {
                Debug.Log("Take damage!");
                health.TakeDamage(10);
            }

            Destroy(gameObject);
        }
    }
}

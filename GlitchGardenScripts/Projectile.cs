using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 6f;
    [SerializeField] float damage = 50f;

    void Update()
    {
        //Move the zucchini along the path
        transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);
        
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //Debug.Log("I hit: " + otherCollider.name);

        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();

        if(attacker && health)
        {
            //reduce health
            health.DealDamage(damage);
            Destroy(gameObject);
        }
        
    }
}

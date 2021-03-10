using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject.Find("LivesText").GetComponent<Lives>().TakeLife();
        Destroy(otherCollider.gameObject);
    }

}

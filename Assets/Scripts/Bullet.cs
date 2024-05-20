using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject hitEffect;
    [SerializeField] int damage;
    public GameObject shooter;

   void OnTriggerEnter2D(Collider2D other)
    {
        //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);

        if (other.GetComponent<Health>() != null)
        {
            other.GetComponent<Health>().LoseHealth(damage, shooter);
        }

        //Destroy(effect, 5f);

        Destroy(this.gameObject);
    }
}

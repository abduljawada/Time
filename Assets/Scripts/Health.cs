using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth = 10;
    int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void LoseHealth(int damage, GameObject shooter)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
        else if (this.gameObject.tag != "Player")
        {
            GetComponent<TargetManager>().SetTarget(shooter.transform);
        }
    }

    void Die()
    {
        if (gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
        }
        else
        {
            GameManager.instance.Lose();
        }
    }
}
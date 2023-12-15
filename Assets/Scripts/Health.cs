using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    [SerializeField] private GameObject deathEffectPrefab;
    [SerializeField] private float deathEffectDuration = 2f;
    
    public void Damage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Death();
        }
    }
    
    private void Death()
    {
        if (deathEffectPrefab != null)
        {
            GameObject effect = Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, deathEffectDuration);
        }
        Destroy(gameObject); // destroy go
    }
}
using System.Collections;
using UnityEngine;

public class ZombieLogic : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float damagePerBite = 25f;
    [SerializeField] private float biteInterval = 1f;
    public bool canMove = false;
    
    private Coroutine biteCoroutine;

    void Update()
    {
        if (canMove)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }
    public void HasSpawnedEnableMovement()
    {
        canMove = true;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Friendlies"))
        {
            canMove = false;
            biteCoroutine = StartCoroutine(Bite(other.gameObject));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Friendlies") && biteCoroutine != null)
        {
            StopCoroutine(biteCoroutine);
            biteCoroutine = null;
            canMove = true;
        }
    }

    private IEnumerator Bite(GameObject target)
    {
        while (true)
        {
            if (IsTargetNull(target))
            {
                canMove = true; // Resume moving if the plant is destroyed
                yield break;
            }

            Health health = target.GetComponent<Health>();
            if (health != null)
            {
                Debug.Log($"Bit for {damagePerBite} damage");
                health.Damage(damagePerBite);
            }

            yield return new WaitForSeconds(biteInterval);
        }
    }

    private bool IsTargetNull(GameObject target)
    {
        return target == null;
    }
}
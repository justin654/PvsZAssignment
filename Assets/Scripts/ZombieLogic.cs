using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR;
using UnityEngine;

public class ZombieLogic : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float damagePerBite = 25f;
    [SerializeField] private float biteInterval = 1f;

    private bool CanMove = false;

    private Coroutine biteCoroutine;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (CanMove)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }
    
    public void EnableMovement()
    {
        CanMove = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Friendlies"))
        {
            biteCoroutine = StartCoroutine(Bite(other.gameObject));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Friendlies") && biteCoroutine != null)
        {
            StopCoroutine(biteCoroutine);
            biteCoroutine = null;
        }
    }

    private IEnumerator Bite(GameObject target)
    {
        while (true)
        {
            if (target == null) // null check to see if go still exists to stop error
            {
                yield break; // if hits arrow, and arrow destroyed, stop coroutine
            }

            Health health = target.GetComponent<Health>();
            if (health != null)
            {
                Debug.Log("Bit for " + damagePerBite + " damage");
                health.Damage(damagePerBite);
            }

            yield return new WaitForSeconds(biteInterval);
        }
    }

}
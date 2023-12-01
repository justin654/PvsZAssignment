using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieLogic : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float damagePerBite = 10f;
    [SerializeField] private float biteInterval = 1f;

    private Coroutine biteCoroutine;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(gameObject.name + " hit " + other.gameObject.name);

        if (other.gameObject.CompareTag("Friendlies"))// using tags to check if we collide with plant
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
            Health health = target.GetComponent<Health>();
            if (health != null)
            {
                Debug.Log("Bit for " + damagePerBite + "damage");
                health.Damage(damagePerBite);
            }

            yield return new WaitForSeconds(biteInterval);
        }
    }

}

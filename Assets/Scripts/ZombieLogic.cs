using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieLogic : MonoBehaviour
{
    [SerializeField] private float speed = 1f; // Movement speed
    [SerializeField] private float damagePerBite = 10f; // Damage inflicted per bite
    [SerializeField] private float biteInterval = 1f; // Time interval between bites

    private Coroutine biteCoroutine; // Coroutine for biting

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}

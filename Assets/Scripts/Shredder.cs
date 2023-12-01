using UnityEngine;

public class Shredder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Friendlies"))
        {
            Destroy(other.gameObject);
            Debug.Log("Destoryed Arrow");
        }
    }
}

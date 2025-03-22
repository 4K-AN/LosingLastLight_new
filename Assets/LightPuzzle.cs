using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private GameObject door; 
    [SerializeField] private float openDelay = 1.3f; 
    [SerializeField] private float closeDelay = 10f; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            StartCoroutine(OpenDoorWithDelay()); 
        }
    }

    private IEnumerator OpenDoorWithDelay()
    {
        yield return new WaitForSeconds(openDelay); 
        door.SetActive(false); 
        StartCoroutine(CloseDoorAfterDelay()); 
    }

    private IEnumerator CloseDoorAfterDelay()
    {
        yield return new WaitForSeconds(closeDelay); 
        door.SetActive(true); 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    public Transform playerLocation;
    public float speedKejar;
  
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerLocation.position, speedKejar * Time.deltaTime);  
    }
    
}

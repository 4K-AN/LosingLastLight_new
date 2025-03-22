using UnityEngine;

public class DestroyAndRespawn : MonoBehaviour
{
    public float respawnTime = 5f; 

    void Start()
    {
        DestroyObject();
    }

    void DestroyObject()
    {
        gameObject.SetActive(false); 
        Invoke(nameof(RespawnObject), respawnTime); 
    }

    void RespawnObject()
    {
        gameObject.SetActive(true); 
    }
}

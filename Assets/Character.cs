using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int healthCharacter; 
    public int attackPower;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if(attackPower <= 0)
        {
            attackPower = 0;
            Destroy(gameObject);
        }
    }
    public void Attack(Character HitObject)
    {
        HitObject.healthCharacter = HitObject.healthCharacter - this.attackPower;
    }
}

using UnityEngine;

namespace ClearSky
{
    public class StaffController : MonoBehaviour
    {
        public Transform player;  
        public Vector3 offset = new Vector3(0.96f, 1.605f, 0f); 

        void Update()
        {
            if (player != null)
            {
                
                transform.position = player.position + offset;
            }
        }
    }
}

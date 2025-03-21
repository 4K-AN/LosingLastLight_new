using UnityEngine;

namespace ClearSky
{
    public class StaffController : MonoBehaviour
    {
        public Transform player;  // Referensi ke player
        public Vector3 offset = new Vector3(0.96f, 1.605f, 0f); // Posisi relatif terhadap player

        void Update()
        {
            if (player != null)
            {
                // Pastikan staff mengikuti posisi player dengan offset yang tetap
                transform.position = player.position + offset;
            }
        }
    }
}

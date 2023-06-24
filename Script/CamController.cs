
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform player;
    public Transform cam;
    // public CinemachineCameraOffset camm;
    private const float Liftup = 5f;

    void Update()
    {
        
        if (transform.rotation.x>.15f || transform.rotation.x<.12f)
        {
            // print(transform.rotation.x.ToString());
            // cam.transform.position =player.position + new Vector3(0.5f,Liftup,-16.9f);
        }
         // transform.LookAt(player);
        
    }
}

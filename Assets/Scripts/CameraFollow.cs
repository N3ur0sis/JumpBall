
/*          [  Solo Designs  ]          */
//Attach this script to an object and this will follow the *Target* position

using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    //Parameters for Camera Following
    public Transform player;
    public float smoothTime = 0.3F;
    //Reference of current Velocity
    private Vector3 velocity = Vector3.zero;


    private void Update()
    {
        //Check if player has passed the camera position
        if (player.position.y > transform.position.y)
        {
            //Move smoothly the camera to the player altitude
            Vector3 target = new Vector3(0, player.position.y, -10);
            transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, smoothTime);
        }
    }
}


/*          [  Solo Designs  ]          */
//Use this script to fit all your game with the screen size

using UnityEngine;
public class Start : MonoBehaviour
{
    //Delete Start object when out of screen for optimization
    private void Update()
    {

        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        if (transform.position.y + 15 < screenBounds.y)
        {
            gameObject.SetActive(false);
        }

    }
}

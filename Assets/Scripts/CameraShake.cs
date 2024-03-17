
/*          [  Solo Designs  ]          */
//Attach this script to an object to create fake shake movement of the object

using System.Collections;
using UnityEngine;
public class CameraShake : MonoBehaviour
{
    //Public reference to the camera shake movement
    public IEnumerator Shake (float duration, float magnitude)
    {
        //Save the Initial camera Position
        Vector3 originalPos = transform.localPosition;

        float elapsedTime = 0.0f;

        //Play the shake movement during the indicated Time
        while (elapsedTime < duration)
        {
            //Generate small position offset for the camera
            float x = Random.Range(-1.5f, 1.5f) * magnitude;
            float y = Random.Range(-1.5f, 1.5f) * magnitude;
            //apply the offset and restart until the time is complete
            transform.localPosition = new Vector3(x, y, originalPos.z);
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        //Reset camera initial position to avoid bug
        transform.localPosition = originalPos;
    }
}

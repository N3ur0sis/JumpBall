
/*          [  Solo Designs  ]          */
//This script is used to keep the aspect ratio of an object regardless of the parent scale modification

using UnityEngine;
public class FixedScale : MonoBehaviour
{
    //the parent of the object you attached this script on
    GameObject parent;
    //scale coefficient
    float ratio;


    //assign Values of variables
    private void Start()
    {
        parent = transform.parent.gameObject;
        ratio = (1 / transform.localScale.y);
    }
    //Scale the object in y according to the x scale factor of the parent object
    void Update()
    {
        transform.localScale = new Vector3(1, parent.transform.localScale.x / ratio , 1);
    }
}

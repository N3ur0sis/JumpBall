
/*          [  Solo Designs  ]          */
//This script is used to control the floor object

using UnityEngine;
public class Floor : MonoBehaviour
{

    BoxCollider2D boxCollider;
    public CameraShake shake;
    //Camera shake variables and is changing color condition
    public float duration;
    public float magnitude;
    public bool color = true;
    // Level 1 and 2 background
    public SpriteRenderer BG1;
    public SpriteRenderer BG2;
    // All color avaible for background             //Edit: better use arrays here for simplify the changes
    public Color32 red;
    public Color32 blue;
    public Color32 green;
    public Color32 gray;
    public Color32 purple;
    public Color32 yellow;
    //Used to avoid repetiting color
    public Color32 oldColor;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    //When Player trigger the floor object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!boxCollider.isActiveAndEnabled)
            {
                //if its the first time the player trigger = new level
                StartCoroutine(shake.Shake(duration, magnitude));
                //Handheld.Vibrate();
                boxCollider.enabled = true;
                //Change the colo background for the level object
                if (color)
                {
                    oldColor = BG1.color;
                    do
                    {
                        //Set the total number of color, change it if add new color, and change the switch
                        int random = Random.Range(0, 6);
                        //Edit : if arrays is used, make a loop to assign every color of the arrays and generate randomly the end of the loop with max the size of the arrays
                        switch (random)
                        {
                            case 0:
                                BG1.color = red;
                                BG2.color = red;
                                break;
                            case 1:
                                BG1.color = blue;
                                BG2.color = blue;
                                break;
                            case 2:
                                BG1.color = green;
                                BG2.color = green;
                                break;
                            case 3:
                                BG1.color = purple;
                                BG2.color = purple;
                                break;
                            case 4:
                                BG1.color = yellow;
                                BG2.color = yellow;
                                break;
                            case 5:
                                BG1.color = gray;
                                BG2.color = gray;
                                break;
                        }
                    } while (oldColor == BG1.color && BG2.color == oldColor);
                    oldColor = BG1.color;
                }
            }
        }
    }
}

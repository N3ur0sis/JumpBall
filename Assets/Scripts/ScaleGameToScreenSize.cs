
/*          [  Solo Designs  ]          */
//Use this script to fit all your game with the screen size

using System;
using UnityEngine;
public class ScaleGameToScreenSize : MonoBehaviour
{
    [Header("Environment")]
    public GameObject StartLevel;
    public GameObject Level1;
    public GameObject Level2;
    [Header("Fixed Childs")]
    public GameObject FixStartLevel;
    public GameObject FixLevel1;
    public GameObject FixLevel2;
    [Header("Props ")]
    public SpriteRenderer bgSR;
    public PlayerController player;
    public float LevelChange;
    Camera cam;
    //Const Variable for scaling depedning on the screen size
    float scrH;
    float scrW;
    float scrAspect;
    float camHeight;
    float camWidht;
    float bgH;
    float bgW;
    float bgScaleH;
    float bgScaleW;


    private void Start()
    {
        ResizeGame();
    }

    public void ResizeGame()
    {
        //Camera Resize
        cam = GetComponent<Camera>();
        scrH = Screen.height;
        scrW = Screen.width;
        scrAspect = scrW / scrH;
        cam.aspect = scrAspect;
        camHeight = 91.06f * cam.orthographicSize;
        camWidht = camHeight * scrAspect;
        //Game Resize
        bgH = bgSR.sprite.rect.height;
        bgW = bgSR.sprite.rect.width;
        bgScaleH = (camHeight / bgH) / 1.7785f;
        bgScaleW = (camWidht / bgW) / 1.00094f;
        StartLevel.transform.localScale = new Vector3(bgScaleW, 1, 1);
        Level1.transform.localScale = new Vector3(bgScaleW, 2, 1);
        Level2.transform.localScale = new Vector3(bgScaleW, 2, 1);
        //Compensate the scale in y axis to conserve aspect for fix object
        FixStartLevel.transform.localScale = new Vector3(1, 1 * bgScaleW, 1);
        FixLevel1.transform.localScale = new Vector3(1, 2 * bgScaleW, 1);
        FixLevel2.transform.localScale = new Vector3(1, 2 * bgScaleW, 1);

        LevelChange = ((Level1.transform.localScale.x * 20) / 2);
        player.MakePlayerProp();
        ResetPosition();
        FixPosition();
    }

    //Put the levels in the initial position to fix it afterwards
    public void ResetPosition()
    {
        StartLevel.transform.localPosition = new Vector3(0, 0, 0);
        Level1.transform.localPosition = new Vector3(0, 15, 0);
        Level2.transform.localPosition = new Vector3(0, 35, 0);
    }
    //Put the level one after the other
    public void FixPosition()
    {
        StartLevel.transform.localPosition = new Vector3(0, StartLevel.transform.localPosition.y - ((10 - (StartLevel.transform.localScale.x * 10)) / 2), 0);
        Level1.transform.localPosition = new Vector3(0, Level1.transform.localPosition.y - ((20 - (Level1.transform.localScale.x * 20) - StartLevel.transform.localPosition.y) - (10 - (StartLevel.transform.localScale.x * 10)) / 2), 0);
        Level2.transform.localPosition = new Vector3(0, Level2.transform.position.y - (((20 - (Level2.transform.localScale.x * 20)) / 2) ) - (20 - (Level1.transform.localScale.x * 20) - StartLevel.transform.localPosition.y) - ((10 - (StartLevel.transform.localScale.x * 10)) / 2), 0);
    }

}

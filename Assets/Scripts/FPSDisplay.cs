
/*          [  Solo Designs  ]          */
//This script is used to add a FPS display in the upper left corner of the screen, used for prototyping only

using UnityEngine;
public class FPSDisplay : MonoBehaviour
{
	float deltaTime = 0.0f;
	//Get the current latency between two frame
	void Update()
	{
		deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
	}

	void OnGUI()
	{
		//Create the UI items
		int w = Screen.width, h = Screen.height;
		GUIStyle style = new GUIStyle();
		Rect rect = new Rect(0, 0, w, h * 2 / 100);
		style.alignment = TextAnchor.UpperLeft;
		style.fontSize = h * 2 / 100;
		style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
		//Set the fps and the ms using the latency 
		float msec = deltaTime * 1000.0f;
		float fps = 1.0f / deltaTime;
		string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
		GUI.Label(rect, text, style);
	}
}
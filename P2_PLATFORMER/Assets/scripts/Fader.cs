using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour {

    public float fadeTime = 1f;
    public float delay = 0f;
    public bool fadeIn = true;
    public Image faderImage;
    

    //void Start () {
    IEnumerator Start()
    {
        //Image faderImage = GetComponent<Image>();
        if (fadeIn)
        {
            yield return new WaitForSeconds(delay); //waits 2 seconds and then does whatever is below
            faderImage.CrossFadeAlpha(0f, fadeTime, false); //completely opaque to completely transparant, 1 second, false: ignore time scale
        } else
        {
            faderImage.canvasRenderer.SetAlpha(0f);
            yield return new WaitForSeconds(delay); //waits 2 seconds and then does whatever is below
            faderImage.CrossFadeAlpha(1f, fadeTime, false); //completely transparant to completely opaque, 1 second, false: ignore time scale
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

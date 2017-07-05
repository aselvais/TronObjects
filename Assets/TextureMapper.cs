using System.Collections;
using UnityEngine;

/**
 * Class to attach to a texture enabeling a color change dynamically
 * 
 * @author Arnaud Selvais for Hostopia
 */
public class TextureMapper : MonoBehaviour {

    /**
     * Target color
     */
    Color newColor;
    /**
     * RGB values
     */
    float color_r = 0F;
    float color_g = 1F;
    float color_b = 0F;
    /**
     * Amount of time it takes to fade between colors
     */
    float transitionTime = 1f;
    /**
     * 
     */
 //   bool activate = true;

    /**
     * Renderer of our object
     */
    Renderer thisRend;

    /**
     * 
     */
    void Start()
    {
        // grab the renderer component on our cube
        thisRend = GetComponent<Renderer>();
        newColor = new Color(color_r, color_g, color_b, 1F);
        // start our coroutine when the game starts
        StartCoroutine(ColorChange());
    }

    /**
     * 
     */
    void Update()
    {
    }

    /**
     * 
     */
    IEnumerator ColorChange()
    {
        // Infinite loop will ensure our coroutine runs all game
        while (true)
        {
            // Create and set transitionRate to 0. This is necessary for our next while loop to function
            float transitionRate = 0;
            /**
             * 1 is the highest value that the Color.Lerp function uses for
             * transitioning between two colors. This while loop will execute
             * until transitionRate is incremented to 1 or higher
             */
            while (transitionRate < 1)
            {
                // this next line is how we change our material color property. We Lerp between the current color and newColor
                thisRend.material.SetColor("_Color", 
                    Color.Lerp(
                        thisRend.material.color, 
                        newColor, 
                        Time.deltaTime * transitionRate
                    )
                );
                // Increment transitionRate over the length of transitionTime
                transitionRate += Time.deltaTime / transitionTime;
                // wait for a frame then loop again
                yield return null;
            }
            // wait for a frame then loop again
            yield return null; 
        }
    }
}
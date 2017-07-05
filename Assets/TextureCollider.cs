using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This attached to a game object will change the color of the object to the one colliding with it
 */
public class TextureCollider : MonoBehaviour {

    /**
     * Declare and initialize a new List of GameObjects called currentCollisions.
     */
    List<GameObject> currentCollisions = new List<GameObject>();

    /**
     * Container for the original color of the object
     */
    Color colorOriginal;

    /**
     * Container for all the Renderers composing this object
     */
    List<Renderer> thisObjects = new List<Renderer>();

    /**
     * 
     */
    private void Start()
    {
        var rdr = this.GetComponent<Renderer>();
        if (rdr)
        {
            thisObjects.Add(rdr);
            colorOriginal = rdr.material.color;
        }
        else
        {
            print("Getting the kids COLORS !!! ...");
            int children = transform.childCount;
            for (int i = 0; i < children; ++i)
            {
                thisObjects.Add(transform.GetChild(i).GetComponent<Renderer>());
            }
        }
    }

    /**
     * When colliding with an object build the list of colliding objects and change the color or this one
     */
    void OnCollisionEnter(Collision col)
    {

        // Add the GameObject collided with to the list.
        currentCollisions.Add(col.gameObject);

        // Print the entire list to the console.
        foreach (GameObject gObject in currentCollisions)
        {
            print("This " + name + " object touched the " + gObject.name + " object");
            changeColor( gObject.GetComponent<Renderer>().material.color );
        }
    }

    /**
     * 
     */
    void OnCollisionExit(Collision col)
    {
        changeColor(colorOriginal);

        // Remove the GameObject collided with from the list.
        currentCollisions.Remove(col.gameObject);
        // Print the entire list to the console.
        foreach (GameObject gObject in currentCollisions)
        {
            print(gObject.name);
        }
    }

    /**
     * Change color of the current object (and all its kids)
     */
    void changeColor(Color newColor)
    {
        foreach (Renderer obj in thisObjects)
        {
            obj.material.color = newColor;
        }
    }
}

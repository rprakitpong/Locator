using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightFeedback : MonoBehaviour
{
    bool HighlightToggle;
    GameObject HighlightMarker;
    Renderer HighlightMarkerRenderer;

    // Start is called before the first frame update
    void Start()
    {
        HighlightToggle = true;
        if (GameObject.Find("LocatingSystem") != null)
        {
            HighlightMarker = GameObject.Find("LocatingSystem").transform.GetChild("PointerArrow");
        } else
        {
            throw new System.Exception("Please drop LocatingSystem prefab into scene");
        }
        
        HighlightMarkerRenderer = HighlightMarker.GetComponent<Renderer>();
    }
    
    void OnBecameVisible()
    {
        if (HighlightToggle)
        {

        }
    }

    void OnBecameInvisible()
    {

    }

    public void HighlightBehaviour()
    {
        Debug.Log("Highlighter turned on for " + this.gameObject.name);
    }
}

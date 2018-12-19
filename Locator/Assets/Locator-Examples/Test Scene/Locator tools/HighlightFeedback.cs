using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightFeedback
{
    
    bool HighlightToggle;
    GameObject HighlightedObject;
    Renderer HighlightedObjectRenderer;
    GameObject HighlightMarker;
    Renderer HighlightMarkerRenderer;

    float waitTime = 2f; 

    private IEnumerator HighlightCoroutine;

    // Start is called before the first frame update
    public HighlightFeedback(GameObject ObjectToHighlight, GameObject HighlightMarker, float waitTime)
    {
        HighlightToggle = true;

        this.HighlightedObject = ObjectToHighlight;
        HighlightedObjectRenderer = HighlightedObject.GetComponent<Renderer>();
        this.HighlightMarker = HighlightMarker;
        HighlightMarkerRenderer = HighlightMarker.GetComponent<Renderer>();

        HighlightCoroutine = Highlight();
    }
    
    void OnBecameVisible()
    {
        if (HighlightToggle)
        {
            StartCoroutine(HighlightCoroutine);
        } 
    }

    void OnBecameInvisible()
    {
        if (HighlightToggle)
        {
            StopCoroutine(HighlightCoroutine);
        } 
    }

    IEnumerator Highlight()
    {
        PositionMarker();
        HighlightMarkerRenderer.enabled = true;
        Debug.Log("renderer turned on");
        yield return new WaitForSeconds(waitTime);
        HighlightMarkerRenderer.enabled = false;
        Debug.Log("renderer turned off");
    }

    public void HighlightBehaviour()
    {
        Debug.Log("Highlighter turned on for " + this.gameObject.name);
        if (HighlightToggle)
        {
            HighlightToggle = false;
        } else
        {
            HighlightToggle = true;
        }
    }
    
    private void PositionMarker()
    {
        // TODO find a more elegant way to do this position marker next to object
        // right now it's sitting inside the object
        HighlightMarker.transform.position = new Vector3(HighlightedObject.transform.position.x, HighlightedObject.transform.position.y, HighlightedObject.transform.position.z);
    }
}

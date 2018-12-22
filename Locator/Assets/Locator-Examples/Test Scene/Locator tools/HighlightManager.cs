using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;

public class HighlightManager : Singleton<HighlightManager>
{
    Dictionary<string, HighlightFeedback> Highlights;

    public float waitTime;

    GameObject HighlightMarker;

    protected override void Awake()
    {
        base.Awake();

        //instantiate highlightmarker
        if (GameObject.Find("LocatingSystem") != null)
        {
            HighlightMarker = GameObject.Find("LocatingSystem").transform.Find("PointerArrow").gameObject;
        }
        else
        {
            throw new System.Exception("Please drop LocatingSystem prefab into scene");
        }

        //instantiate waittime (hardcode)
        waitTime = 2f;
    }

    public void AddHighlight(GameObject GO)
    {
        if (Highlights.ContainsKey(GO.name))
        {
            Highlights[GO.name].HighlightBehaviour();
        } else
        {
            Highlights.Add(GO.name, new HighlightFeedback(GO, HighlightMarker, waitTime));
        }
    }
    
}

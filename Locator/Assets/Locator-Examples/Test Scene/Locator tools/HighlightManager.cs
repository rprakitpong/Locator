using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightManager : Singleton<HighlightManager>
{
    Dictionary<HighlightFeedback, Info> Highlights;

    public float waitTime;

    GameObject HighlightMarker;

    protected override void Awake()
    {
        base.Awake();

        if (GameObject.Find("LocatingSystem") != null)
        {
            HighlightMarker = GameObject.Find("LocatingSystem").transform.Find("PointerArrow").gameObject;
        }
        else
        {
            throw new System.Exception("Please drop LocatingSystem prefab into scene");
        }

        if (waitTime == null)
        {
            waitTime = 2f;
        }
    }

    public void AddHighlight(GameObject GO)
    {
        //TODO should refactor this into a factory later
        if (Highlights.ContainsValue(new Info(GO.name, 0f)))
        {
            //
        }
        Highlights.Add(new HighlightFeedback(GO, HighlightMarker, waitTime), 2f);
        //TODO priority is hardcoded as 2f 
        //TODO decide what script and method to get priority from gameobject, ex GO.GetComponent<SomeScript>().GetPriority
    }

    private class Info
    {
        string name { get; set; }
        float priority { get; set; }

        public Info(string name, float priority)
        {
            this.name = name;
            this.priority = priority;
        }

        public override bool Equals(object obj)
        {
            return name == obj.name;
        }
    }
}

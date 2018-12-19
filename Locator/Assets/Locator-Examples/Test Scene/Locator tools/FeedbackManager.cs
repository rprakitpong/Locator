using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;

public class FeedbackManager : Singleton<FeedbackManager>
{
    
    protected override void Awake()
    {
        base.Awake();
    }

    public void AddFeedback(GameObject GO)
    {
        HighlightManager.AddHighlight(GO);
        
    }
    
}

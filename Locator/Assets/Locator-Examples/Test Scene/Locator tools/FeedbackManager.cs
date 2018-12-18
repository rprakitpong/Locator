using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit;

public class FeedbackManager : Singleton<FeedbackManager>
{
    override void Awake()
    {
        base.Awake();

    }

    public void AddFeedback(GameObject GO)
    {
        if (GO.GetComponent<HightlightFeedback>() != null)
        {
            GO.GetComponent<HighlightFeedback>().HighlightBehaviour();
        } else
        {
            GO.AddComponent<HighlightFeedback>();
        }
    }
}

using HoloToolkit.Examples.InteractiveElements;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flow : MonoBehaviour {

    public GameObject NextButton;
    public GameObject Scenario_Description;

    private List<string> ChaptersDescription;
    private IEnumerator ChaptersDescriptionEnumerator;
    private TextMesh CurrentDescription;

    private List<Renderer[]> PagesInChapters;
    private IEnumerator PagesInChaptersEnumerator;
    private Renderer[] pagesInCurrentChapter;

    // Use this for initialization
    void Start () {
        if (NextButton != null)
        {
            NextButton.GetComponent<Interactive>().OnSelectEvents.AddListener(ShowNextChapter);
        }

        InitializePagesInChaptersAndItsEnumerator();
        InitializeDescription();
        ShowNextChapter();
    }

    private void InitializePagesInChaptersAndItsEnumerator()
    {
        PagesInChapters = new List<Renderer[]>();

        foreach (Transform chapter in this.gameObject.transform)
        {
            pagesInCurrentChapter = chapter.gameObject.GetComponentsInChildren<Renderer>();
            PagesInChapters.Add(pagesInCurrentChapter);
            TurnOffAllRenderer(pagesInCurrentChapter);
        }

        PagesInChaptersEnumerator = PagesInChapters.GetEnumerator();
    }
    
    private void InitializeDescription()
    {
        CurrentDescription = Scenario_Description.GetComponent<TextMesh>();
        ChaptersDescription = new List<String>();

        foreach (Transform chapter in this.gameObject.transform)
        {
            CurrentDescription.text = chapter.gameObject.name;
            ChaptersDescription.Add(CurrentDescription.text);
        }

        ChaptersDescriptionEnumerator = ChaptersDescription.GetEnumerator();
    }

    private void ShowNextChapter()
    {
        ShowNextChapterPages();
        ChangeDescriptionToNextChapter();
    }

    private void ShowNextChapterPages()
    {
        if (PagesInChaptersEnumerator.MoveNext() == false)
        {
            PagesInChaptersEnumerator.Reset();
            PagesInChaptersEnumerator.MoveNext();
        }

        TurnOffAllRenderer(pagesInCurrentChapter);
        pagesInCurrentChapter = (Renderer[])PagesInChaptersEnumerator.Current;
        TurnOnAllRenderer(pagesInCurrentChapter);
    }

    private void TurnOnAllRenderer(Renderer[] pagesInCurrentChapter)
    {
        foreach (Renderer r in pagesInCurrentChapter)
        {
            r.enabled = true;
        }
    }

    private void TurnOffAllRenderer(Renderer[] pagesInCurrentChapter)
    {
        foreach (Renderer r in pagesInCurrentChapter)
        {
            r.enabled = false;
        }
    }

    private void ChangeDescriptionToNextChapter()
    {
        if (ChaptersDescriptionEnumerator.MoveNext() == false)
        {
            ChaptersDescriptionEnumerator.Reset();
            ChaptersDescriptionEnumerator.MoveNext();
        }

        CurrentDescription.text = (String)ChaptersDescriptionEnumerator.Current;
    }
}

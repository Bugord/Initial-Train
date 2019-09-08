using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score = 0;
    private int maxScore = 0;
    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
        Print();
    }

    public void Reset()
    {
        if (score > maxScore)
            maxScore = score;
        score = 0;
        Print();
    }

    void Print()
    {
        text.text = string.Format("{0} ({1})", score, maxScore);

    }

    public void Add()
    {
        score++;
        Print();
    }
}

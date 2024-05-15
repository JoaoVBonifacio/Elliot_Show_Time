using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAlphaHitTest : MonoBehaviour
{
    public float alpha;
    public Image theButton;

    // Use this for initialization
    void Start()
    {
        theButton.alphaHitTestMinimumThreshold = alpha;
    }
}

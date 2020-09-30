using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;

public class BreatheThing : MonoBehaviour
{
    public List<Disc> discs = new List<Disc>();

    public float discAlpha = 1f;

    // Update is called once per frame
    void Update()
    {
        foreach (Disc d in discs) {
            d.SetAlpha(discAlpha);
        }
    }
}

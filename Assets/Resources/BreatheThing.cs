using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;
using DG.Tweening;

public class BreatheThing : MonoBehaviour
{
    public List<Disc> discs = new List<Disc>();
    public List<Disc> discGlows = new List<Disc>();

    public float discAlpha = 1f;

    public float discOffsetRadius = 1f;

    public float discGlowAlpha = 0.25f;
    public float discGlowRadius = 1.25f;

    void Start() {
        // Sequence s = DOTween.Sequence();
        // foreach (Disc d in discs) {
        //     s.Append(s.To());
        // }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Disc d in discs) {
            d.SetAlpha(discAlpha);
            d.GetComponent<PlaceOnAngle>().radius = discOffsetRadius;
        }

        foreach (Disc d in discGlows) {
            d.SetInnerAlpha(discGlowAlpha);
            d.Radius = discGlowRadius;
        }
    }
}

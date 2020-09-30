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


    public float discGlowExpandedRadius = 1.25f;
    public float discGlowContractedRadius = 0.5f;
    public float discExpandedRadius = 1f;
    public float discContractedRadius = 0.2f;

    [Header("Timing")]
    public float breatheInDuration = 1f;
    public float holdInDuration = 1f;
    public float breatheOutDuration = 1f;
    public float holdOutDuration = 1f;

    void Start() {
        // set initial values
        transform.localEulerAngles = Vector3.zero;
        for (int i = 0; i < discs.Count; i++) {
            Disc d = discs[i];
            Disc dGlow = discGlows[i];
            d.GetComponent<PlaceOnAngle>().radius = 0;
            d.Radius = discContractedRadius;
            dGlow.Radius = discGlowContractedRadius;
        }


        Sequence s = DOTween.Sequence();

        // Expand (inhale)
        s.Append(transform.DORotate(new Vector3(0f, 0f, -45f), breatheInDuration));
        for (int i = 0; i < discs.Count; i++) {
            Disc d = discs[i];
            Disc dGlow = discGlows[i];
            s.Join(DOTween.To(() => d.GetComponent<PlaceOnAngle>().radius, x => d.GetComponent<PlaceOnAngle>().radius = x, discOffsetRadius, breatheInDuration));
            s.Join(d.DORadius(discExpandedRadius, breatheInDuration));
            s.Join(dGlow.DORadius(discGlowExpandedRadius, breatheInDuration));
        }
        
        // Hold breath in
        s.AppendInterval(holdInDuration);

        // Contract (exhale)
        s.Append(transform.DORotate(new Vector3(0f, 0f, 0f), breatheOutDuration));
        for (int i = 0; i < discs.Count; i++) {
            Disc d = discs[i];
            Disc dGlow = discGlows[i];
            s.Join(DOTween.To(() => d.GetComponent<PlaceOnAngle>().radius, x => d.GetComponent<PlaceOnAngle>().radius = x, 0, breatheOutDuration));
            s.Join(d.DORadius(discContractedRadius, breatheOutDuration));
            s.Join(dGlow.DORadius(discGlowContractedRadius, breatheOutDuration));
        }

        // Hold breath out(?)
        s.AppendInterval(holdOutDuration);

        s.SetEase(Ease.InOutSine);
        // At this point it should be at the same point it was at the beginning, so loop
        s.SetLoops(-1, LoopType.Restart);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Disc d in discs) {
            d.SetAlpha(discAlpha);
        }

        foreach (Disc d in discGlows) {
            d.SetInnerAlpha(discGlowAlpha);
        }
    }
}

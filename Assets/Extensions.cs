using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;
public static class Extensions
{
    public static void SetAlpha(this ShapeRenderer obj, float alpha) {
        Color c = obj.Color;
        c.a = alpha;
        obj.Color = c;
        return;
    }

    public static void SetInnerAlpha(this Disc obj, float alpha) {
        Color c = obj.ColorInner;
        c.a = alpha;
        obj.ColorInner = c;
        return;
    }
}
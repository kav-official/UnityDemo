using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathOrder : MonoBehaviour
{
    public static List<int> Orders = new List<int> {
    13, 12, 14, 11, 15, 10, 16, 9, 17, 8, 18, 7, 19, 6, 20, 5, 21, 4, 22, 3, 2, 1, 0,
    26, 25, 27, 24, 28, 23, 29};
    public static void BuildPathOrder()
    {
        Orders.Clear();
        int centerTop = 13;
        Orders.Add(centerTop);
        for (int offset = 1; offset <= 13; offset++)
        {
            if (centerTop - offset >= 0) Orders.Add(centerTop - offset);
            if (centerTop + offset <= 22) Orders.Add(centerTop + offset);
        }
        int centerBottom = 26;
        Orders.Add(centerBottom);
        for (int offset = 1; offset <= 3; offset++)
        {
            if (centerBottom - offset >= 23) Orders.Add(centerBottom - offset);
            if (centerBottom + offset <= 29) Orders.Add(centerBottom + offset);
        }
    }
}

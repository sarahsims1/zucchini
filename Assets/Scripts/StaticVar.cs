using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVar : MonoBehaviour
{
    private static int squashGathered;

    private static int dirtGathered=99;

    private static int seedsGathered=99;

    public static int GetSquash()
    {
        return squashGathered;
    }

    public static int GetDirt()
    {
        return dirtGathered;
    }
    public static int GetSeeds()
    {
        return seedsGathered;
    }

    public static void SetSquash(int squash)
    {
        squashGathered = squash;
    }

    public static void SetSeeds(int seeds)
    {
        seedsGathered = seeds;
    }

    public static void SetDirt(int dirt)
    {
        dirtGathered = dirt;
    }
}

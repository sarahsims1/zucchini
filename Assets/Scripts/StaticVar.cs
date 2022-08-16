using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVar : MonoBehaviour
{
    private static int squashGathered;

    private static int dirtGathered;

    private static int seedsGathered;

    private static bool tutorialFailed;

    public delegate void Change();
    public static Change varChange;
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
        if (squash >= 0) squashGathered = squash;
        else squashGathered = 0;
        varChange();
    }

    public static void SetSeeds(int seeds)
    {
        if (seeds >= 0) seedsGathered = seeds;
        else seedsGathered = 0;
        varChange();
    }

    public static void SetDirt(int dirt)
    {
        if (dirt >= 0) dirtGathered = dirt;
        else dirtGathered = 0;
        varChange();
    }

    public static bool GetFailed()
    {
        return tutorialFailed;
    }

    public static void SetFailed(bool failed)
    {
        tutorialFailed = failed;
    }
}

using System.Collections.Generic;
using UnityEngine;

public class DoneButton : MonoBehaviour
{
    public void Done()
    {
        List<Vector3> currentPos = new List<Vector3>();
        List<string> currentPartName = new List<string>();
        List<float> distances = new List<float>();

        AddToLists(currentPos, currentPartName);
        CalculateDistances(currentPos, distances, currentPartName);
        Check(distances, currentPartName);
    }

    private static void Check(List<float> distances, List<string> names)
    {
        int counter = 0;

        for (int i = 0; i < distances.Count; i++)
        {
            //Debug.Log("AAAAAA"); //DEBUG
            if (distances[i] >= 0 && distances[i] <= 1)
            {
                Debug.Log(names[i] + " is near the exact point"); //DEBUG
                Handheld.Vibrate();
                counter++;
                if (counter >= RandomBodyPartPlacement.Instance.amountOfBodyPartsToPlace)
                {
                    FindObjectOfType<LevelLoader>().LoadNextLevel();
                }
            }
        }
    }

    private static void CalculateDistances(List<Vector3> currentPos, List<float> distances, List<string> names)
    {
        for (int i = 0; i < currentPos.Count; i++)
        {
            for (int j = 0; j < currentPos.Count; j++)
            {
                if(names[i].Contains(RandomBodyPartPlacement.Instance.currentMemoryGroup[j].type.ToString()))
                {
                    distances.Add(Vector3.Distance(currentPos[i], RandomBodyPartPlacement.Instance.currentMemoryGroup[j].position));
                    //Debug.Log("Added!"); //DEBUG
                }
            }
        }
    }

    private static void AddToLists(List<Vector3> currentPos, List<string> currentPartName)
    {
        foreach (var part in RandomBodyPartPlacement.Instance.partsToPlacePositions)
        {
            if (part.transform.childCount > 0)
            {
                currentPartName.Add(part.transform.GetChild(0).name);
                currentPos.Add(part.transform.GetChild(0).position);
            }
        }
    }
}

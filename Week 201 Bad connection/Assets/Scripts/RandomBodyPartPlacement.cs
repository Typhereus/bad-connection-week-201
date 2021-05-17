using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBodyPartPlacement : MonoBehaviour
{
    /// <summary>
    /// Uses the body part prefabs to display a preview of the parts to memorize
    /// instantiated randomly on allpoints gameobjects, adds them to the previewparts 
    /// to destroy them when the preview is over
    /// 
    /// The second part of the game is the placement of the parts in the same positions 
    /// displayed during memory
    /// </summary>

    #region Singleton
    public static RandomBodyPartPlacement Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    //Preview body part prefabs
    public List<GameObject> allUniqueBodyPartsPrefabs = new List<GameObject>();

    public List<GameObject> allPoints = new List<GameObject>();

    public Transform previewBodyPartsTransform;

    private List<GameObject> previewBodyParts = new List<GameObject>();


    //Memory Part of the game
    public List<BodyPartPosition> currentMemoryGroup = new List<BodyPartPosition>();

    public List<GameObject> partsToPlacePositions = new List<GameObject>();

    [Space]
    [TextArea]
    public string amountNote = "Cannot be higher than amount of points or amount of body parts";
    public int amountOfBodyPartsToPlace = 3;


    private void Start()
    {
        PreviewPlaceBodyPartsAndMakeList();
    }

    public void PreviewPlaceBodyPartsAndMakeList()
    {
        List<int> bodyPartIndex = new List<int>();
        for (int i = 0; i < allUniqueBodyPartsPrefabs.Count; i++)
        {
            bodyPartIndex.Add(i);
        }
        ShuffleList.ShuffleTheList(bodyPartIndex);


        List<int> pointIndex = new List<int>();
        for (int u = 0; u < allPoints.Count; u++)
        {
            pointIndex.Add(u);
        }
        ShuffleList.ShuffleTheList(pointIndex);

        for (int i = 0; i < amountOfBodyPartsToPlace; i++)
        {
            GameObject prefab = allUniqueBodyPartsPrefabs[bodyPartIndex[0]];
            GameObject point = allPoints[pointIndex[0]];

            GameObject go = Instantiate(prefab, point.transform.position, Quaternion.identity, previewBodyPartsTransform);
            previewBodyParts.Add(go);

            bodyPartIndex.Remove(bodyPartIndex[0]);
            pointIndex.Remove(pointIndex[0]);

            //Create point
            currentMemoryGroup.Add(new BodyPartPosition(go.GetComponent<BodyPartGameObject>().bodyPartType, point.transform.position));
        }
    }

    public void MemoryGameSpawnPlacingParts()
    {
        int iterator = 0;
        foreach (var item in currentMemoryGroup)
        {
            GameObject goToSpawn = allUniqueBodyPartsPrefabs.Find(x => x.GetComponent<BodyPartGameObject>().bodyPartType == item.type);
            Instantiate(goToSpawn, partsToPlacePositions[iterator].transform.position, Quaternion.identity, partsToPlacePositions[iterator].transform);

            iterator++;
        }
    }

    public void RemovePreview()
    {
        foreach (var item in previewBodyParts)
        {
            Destroy(item);
        }
    }
}
public class BodyPartPosition
{
    public BodyPartGameObject.BodyPartType type;

    public Vector3 position;

    public BodyPartPosition(BodyPartGameObject.BodyPartType _type, Vector3 _position)
    {
        type = _type;
        position = _position;
    }
}

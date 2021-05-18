using UnityEngine;

public class BodyPartGameObject : MonoBehaviour
{
    public enum BodyPartType
    {
        Kidney,
        Heart,
        Lung,
        Spleen,
        Pancreas,
    }
    public BodyPartType bodyPartType;
}

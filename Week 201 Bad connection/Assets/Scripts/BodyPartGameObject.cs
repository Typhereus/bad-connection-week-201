using UnityEngine;

public class BodyPartGameObject : MonoBehaviour
{
    public enum BodyPartType
    {
        RightArm,
        LeftArm,
        RightLeg,
        LeftFoot,
        Leg,
        Eye,
        Wing,
        Heart,
        Intestine,
        Lungs,
    }
    public BodyPartType bodyPartType;
}

using UnityEngine;

public class FloorController : MonoBehaviour
{
    [SerializeField] private float scaleX = 8f;
    [SerializeField] private Transform leftCorner;
    [SerializeField] private Transform rightCorner;

    void OnValidate()
    {
        if(!Application.isPlaying)
        {
            var gameObjectScale = gameObject.transform.localScale;
            var leftCornerPos = leftCorner.position;
            var rightCornerPos = rightCorner.position;

            rightCornerPos.x = (scaleX / 2);
            leftCornerPos.x = (scaleX / 2) * -1;

            gameObjectScale.x = scaleX;
            gameObject.transform.localScale = gameObjectScale;
            rightCorner.position = rightCornerPos;
            leftCorner.position = leftCornerPos;
        }
    }

    public float GetFloorScale()
    {
        return scaleX;
    }
}

using System.Collections.Generic;
using Mediapipe;
using UnityEngine;

public class HandToCircleMapper : MonoBehaviour
{
    public Transform handObject; // Reference to the object that will follow the hand position

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetHandLandmarks(IReadOnlyList<NormalizedLandmarkList> _landmarkList)
    {
        if (_landmarkList != null)
        {
            NormalizedLandmarkList handLandmarkList = _landmarkList[0]; // Get the first hand landmark list
            if (handObject != null)
            {
                // Assuming the first landmark represents the palm position
                NormalizedLandmark palmPosition = handLandmarkList.Landmark[0];

                // Convert normalized coordinates to world position (you may need to adjust the scale and offset)
                Vector3 handWorldPosition = new Vector3(palmPosition.X * 10f, palmPosition.Y * 10f, -palmPosition.Z * 10f);

                // Update the position of the handObject to follow the hand position
                handObject.position = handWorldPosition;
                Debug.Log("Hand Position: " + handWorldPosition);

            }
        }
    }
}

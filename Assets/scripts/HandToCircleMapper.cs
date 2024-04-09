using System.Collections.Generic;
using Mediapipe;
using UnityEngine;

public class HandToCircleMapper : MonoBehaviour
{
    public Transform handObject; // Reference to the object that will follow the hand position

    private Vector3 handWorldPosition;

    private Vector3 initPosition;

    private Vector3 fixPositionhelper;
    
    private bool handPositionChanged = false;
    // Start is called before the first frame update
    void Start()
    {
        initPosition = handObject.transform.position;
        handWorldPosition = Vector3.zero;
        fixPositionhelper = Vector3.zero;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (handPositionChanged)
        {
            handObject.position = initPosition + handWorldPosition + fixPositionhelper;
            Debug.Log("Hand Position: " + handWorldPosition);
            handPositionChanged = false;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            fixPositionhelper = -handWorldPosition;
        }
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
                Vector3 handWorldPosition = new Vector3(palmPosition.X * 10f, -palmPosition.Y * 10f, -palmPosition.Z * 10f);

                // Update the position of the handObject to follow the hand position
                this.handWorldPosition = handWorldPosition;
                
                
                handPositionChanged = true;
            }
        }
    }
}

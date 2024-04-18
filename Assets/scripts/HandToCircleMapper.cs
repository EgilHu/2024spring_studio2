using System.Collections.Generic;
using Mediapipe;
using UnityEngine;

public class HandToCircleMapper : MonoBehaviour
{
    private Transform handObject; // Reference to the object that will follow the hand position

    public Vector3 handWorldPosition;

    // All position variables
    private Vector3 initPosition;

    private Vector3 lastObjPosition;

    private Vector3 fixPositionhelper;

    private bool handPositionChanged = false;

    public Collider2D _collider2D;
    // Start is called before the first frame update
    void Start()
    {
        handObject = this.transform;
        initPosition = handObject.transform.position;
        handWorldPosition = Vector3.zero;
        fixPositionhelper = Vector3.zero;
        lastObjPosition = initPosition;
        _collider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (handPositionChanged && Input.GetKey(KeyCode.Space) && !Input.GetKeyDown(KeyCode.Space))
        {
            handObject.position = lastObjPosition + (handWorldPosition - fixPositionhelper);
            handObject.position = new Vector3(handObject.position.x, handObject.position.y, 0.0f);
            // Debug.Log("Hand Position: " + handWorldPosition);
            handPositionChanged = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            fixPositionhelper = handWorldPosition;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            lastObjPosition = initPosition;
            fixPositionhelper = handWorldPosition;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            lastObjPosition = handObject.position;
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
                Vector3 handWorldPosition = new Vector3(palmPosition.X * 25f, -palmPosition.Y * 10f, -palmPosition.Z * 10f);

                // Update the position of the handObject to follow the hand position
                this.handWorldPosition = handWorldPosition;


                handPositionChanged = true;
            }
        }
    }
}

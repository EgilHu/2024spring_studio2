using System.Collections;
using System.Collections.Generic;
using Mediapipe;
using UnityEngine;

public class HandToCircleMapper : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = HandPosition;
        Debug.Log(HandPosition);
    }

    public Vector3 HandPosition;

    public void GetHandLandmarks(IReadOnlyList<NormalizedLandmarkList> _landmarkList)
    {
        if (_landmarkList != null && _landmarkList.Count > 0)
        {
            NormalizedLandmarkList handLandmarkList = _landmarkList[0]; //这个handLandmarkList包含手部21个关键点
            HandPosition = new Vector3(handLandmarkList.Landmark[0].X, handLandmarkList.Landmark[0].Y,
                handLandmarkList.Landmark[0].Z);
        }
    }
}

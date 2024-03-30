using System.Collections;
using System.Collections.Generic;
using Mediapipe;
using UnityEngine;

public class ExampleGetHandtrackOutput : MonoBehaviour
{
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
            NormalizedLandmarkList handLandmarkList = _landmarkList[0]; //这个handLandmarkList包含手部21个关键点
            Vector3 example_waist_position = new Vector3(handLandmarkList.Landmark[0].X, handLandmarkList.Landmark[0].Y,
                handLandmarkList.Landmark[0].Z);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Google.Protobuf.Collections;
using Mediapipe;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class HandToCircleMapper : MonoBehaviour
{
    [SerializeField] private ExampleGetHandtrackOutput _exampleGetHandtrackOutput;
    GameObject circle;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        circle.transform.position = new Vector3(_exampleGetHandtrackOutput.GetHandLandmarks(handLandmarkList.Landmark[x].X), _exampleGetHandtrackOutput.GetHandLandmarks(0));
    }

}
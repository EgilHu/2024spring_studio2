using System.Collections;
using System.Collections.Generic;
using Google.Protobuf.Collections;
using Mediapipe;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DebugHandLandMarks : MonoBehaviour
{
    private float previous_bone_length = 0.0f;

    public TextMeshProUGUI _debuginfo;
    public TextMeshProUGUI _stiketimeinfo;
    
    private string debug_text = "";
    
    public float velocity_threshold = 0.1f;
    public float fist_threshold = 0.01f;
    public float palm_threshold = 0.005f;
    public int num_frames_to_avarage = 30;
    
    private bool fist_detected = false;

    private bool palm_detected = false;
    
    private bool forwarding_detected = true;

    private Queue<float> hand_speed_queue = new Queue<float>();

    private int strike_times = 0;

    private bool enqueue_stopped = false;

    private float enqueue_timer = 0.0f;

    public float enqueue_stop_time = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fist_detected && forwarding_detected)
        {
            _debuginfo.text = "Fist";
        }
        else if (palm_detected && forwarding_detected)
        {
            _debuginfo.text = "Palm";
        }
        else if (fist_detected)
        {
            _debuginfo.text = "Fist";
        }
        else if (palm_detected)
        {
            _debuginfo.text = "Palm";
        }
        else if (forwarding_detected)
        {
            _debuginfo.text = "Forwarding";
        }
        else
        {
            _debuginfo.text = "";
        }

        _stiketimeinfo.text = "Strike times: " + strike_times;
        
        // 0.1s后再次进行平均速度的判断
        if (enqueue_stopped)
        {
            enqueue_timer += Time.deltaTime;
            if (enqueue_timer >= enqueue_stop_time)
            {
                enqueue_timer = 0.0f;
                enqueue_stopped = false;
            }
        }
    }

    float GetTIPMCPDistance(Landmark mcp, Landmark tip)
    {
        Vector3 tip_pos = new Vector3(tip.X, tip.Y, tip.Z);
        Vector3 mcp_pos = new Vector3(mcp.X, mcp.Y, mcp.Z);
        
        return Vector3.Distance(tip_pos, mcp_pos);
    }

    float GetWholefingerLength(Landmark mcp, Landmark pip, Landmark dip, Landmark tip)
    {
        Vector3 mcp_pos = new Vector3(mcp.X, mcp.Y, mcp.Z);
        Vector3 pip_pos = new Vector3(pip.X, pip.Y, pip.Z);
        Vector3 dip_pos = new Vector3(dip.X, dip.Y, dip.Z);
        Vector3 tip_pos = new Vector3(tip.X, tip.Y, tip.Z);

        return Vector3.Distance(mcp_pos, pip_pos) + Vector3.Distance(pip_pos, dip_pos) +
               Vector3.Distance(dip_pos, tip_pos);
    }

    bool DetectFist(IReadOnlyList<LandmarkList> _landmarkList)
    {
        RepeatedField<Landmark> landmark = _landmarkList[0].Landmark;
        // bool detect_thumb = false;
        bool detect_index = false;
        bool detect_middle = false;
        bool detect_ring = false;
        bool detect_pinky = false;
        // // thumb
        // if (GetTIPMCPDistance(landmark[1], landmark[4]) -
        //     GetWholefingerLength(landmark[1], landmark[2], landmark[3], landmark[4])> fist_threshold)
        // {
        //     detect_thumb = true;
        // }
        //
        // index
        // Debug.Log(GetWholefingerLength(landmark[5], landmark[6], landmark[7], landmark[8]) -
        //           GetTIPMCPDistance(landmark[5], landmark[8]));
        if (GetWholefingerLength(landmark[5], landmark[6], landmark[7], landmark[8]) -
            GetTIPMCPDistance(landmark[5], landmark[8])> fist_threshold)
        {
            detect_index = true;
        }
        
        // middle
        if (GetWholefingerLength(landmark[9], landmark[10], landmark[11], landmark[12]) -
            GetTIPMCPDistance(landmark[9], landmark[12]) > fist_threshold)
        {
            detect_middle = true;
        }
        
        //ring
        if (GetWholefingerLength(landmark[13], landmark[14], landmark[15], landmark[16]) - 
            GetTIPMCPDistance(landmark[13], landmark[16]) > fist_threshold)
        {
            detect_ring = true;
        }
        
        //pinky
        if (GetWholefingerLength(landmark[17], landmark[18], landmark[19], landmark[20]) -
            GetTIPMCPDistance(landmark[17], landmark[20]) > fist_threshold)
        {
            detect_pinky = true;
        }

        return detect_index && detect_middle && detect_ring && detect_pinky;
    }
    
    bool DetectPalm(IReadOnlyList<LandmarkList> _landmarkList)
    {
        RepeatedField<Landmark> landmark = _landmarkList[0].Landmark;
        bool detect_thumb = false;
        bool detect_index = false;
        bool detect_middle = false;
        bool detect_ring = false;
        bool detect_pinky = false;
        // thumb
        if (GetTIPMCPDistance(landmark[1], landmark[4]) -
            GetWholefingerLength(landmark[1], landmark[2], landmark[3], landmark[4])< palm_threshold)
        {
            detect_thumb = true;
        }
        
        // index
        if (GetWholefingerLength(landmark[5], landmark[6], landmark[7], landmark[8]) -
            GetTIPMCPDistance(landmark[5], landmark[8])< palm_threshold)
        {
            detect_index = true;
        }
        
        // middle
        if (GetWholefingerLength(landmark[9], landmark[10], landmark[11], landmark[12]) -
            GetTIPMCPDistance(landmark[9], landmark[12]) < palm_threshold)
        {
            detect_middle = true;
        }
        
        //ring
        if (GetWholefingerLength(landmark[13], landmark[14], landmark[15], landmark[16]) - 
            GetTIPMCPDistance(landmark[13], landmark[16]) < palm_threshold)
        {
            detect_ring = true;
        }
        
        //pinky
        if (GetWholefingerLength(landmark[17], landmark[18], landmark[19], landmark[20]) -
            GetTIPMCPDistance(landmark[17], landmark[20]) < palm_threshold)
        {
            detect_pinky = true;
        }

        return detect_index && detect_middle && detect_ring && detect_pinky;
    }
    
    public void DebugWorldBonelength(IReadOnlyList<LandmarkList> _landmarkList)
    {
        if (_landmarkList != null)
        {
            if (DetectFist(_landmarkList))
            {
                fist_detected = true;
            }
            else
            {
                fist_detected = false;
            }
            
            if (DetectPalm(_landmarkList))
            {
                palm_detected = true;
            }
            else
            {
                palm_detected = false;
            }
        }

    }

    float CalculateHandAveragevelocity()
    {
        float sum = 0.0f;
        foreach (float speed in hand_speed_queue)
        {
            sum += speed;
        }
        Debug.Log(sum);
        return sum / hand_speed_queue.Count;
    }
    public void DebugBonelength(IReadOnlyList<NormalizedLandmarkList> _landmarkList)
    {
        if (_landmarkList != null && !enqueue_stopped)
        {
            Vector3 index_mcp_pos = new Vector3(_landmarkList[0].Landmark[5].X, _landmarkList[0].Landmark[5].Y, _landmarkList[0].Landmark[5].Z);
            Vector3 wrist_pos = new Vector3(_landmarkList[0].Landmark[0].X, _landmarkList[0].Landmark[0].Y, _landmarkList[0].Landmark[0].Z);
            float bone_length = Vector3.Distance(index_mcp_pos, wrist_pos);
            float bone_length_velocity = bone_length - previous_bone_length;
            hand_speed_queue.Enqueue(bone_length_velocity);
            previous_bone_length = bone_length;

            if (hand_speed_queue.Count > num_frames_to_avarage)
            {
                if (CalculateHandAveragevelocity() > velocity_threshold)
                {
                    forwarding_detected = true;
                    strike_times++;
                    enqueue_stopped = true;
                }
                else
                {
                    forwarding_detected = false;
                }

                hand_speed_queue.Clear();
            }

        }

    }
}

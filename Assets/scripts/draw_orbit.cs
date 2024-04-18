using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class draw_orbit : MonoBehaviour
{
    // 绘制轨迹组件
    public LineRenderer line;
    public List<Vector3> points;
    // 读取本地txt文件位置信息，改变物体位置
    string[] text_buf;
    int i = 0;

    void Start()
    {
        // 物体位置控制方法根据自己需求来，我这里是从txt文件读取位置信息然后更新
        TextAsset ta = Resources.Load("satellite_orbit") as TextAsset;
        string text = ta.text;
        text_buf = text.Split('\n');
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (i < text_buf.Length)
            {
                // 读取坐标信息
                string[] line = text_buf[i].Split(',');
                float x = Convert.ToSingle(line[0]) / 1000;
                float y = Convert.ToSingle(line[1]) / 1000;
                float z = Convert.ToSingle(line[2]) / 1000;
                // 更新物体位置
                transform.position = new Vector3(x, y, z);
                // 绘制轨迹
                AddPoints();
            }
            i++;
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }

    }

    // 绘制轨迹方法
    public void AddPoints()
    {
        Vector3 pt = transform.position;
        if (points.Count > 0 && (pt - lastPoint).magnitude < 0.1f)
            return;
        if (pt != new Vector3(0, 0, 0))
            points.Add(pt);

        line.positionCount = points.Count;
        if (points.Count > 0)
            line.SetPosition(points.Count - 1, lastPoint);
    }
    public Vector3 lastPoint
    {
        get
        {
            if (points == null)
                return Vector3.zero;
            return (points[points.Count - 1]);
        }
    }
}


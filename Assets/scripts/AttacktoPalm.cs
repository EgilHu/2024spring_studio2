using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttacktoPalm : MonoBehaviour
{
    private float timeSinceSpawn = 0f;
    public float timeToChangeColor = 2f;
    public float timeToDie = 4f;
    private bool isClicked = false;

    private Collider2D _collider2D;

    private DebugHandLandMarks _debugHandLandMarks;
    private HandToCircleMapper _handToCircleMapper;
    private void Start()
    {
        _collider2D = this.GetComponent<Collider2D>();
        _debugHandLandMarks = FindObjectOfType<DebugHandLandMarks>();
        _handToCircleMapper = FindObjectOfType<HandToCircleMapper>();
    }

    void Update()
    {
        timeSinceSpawn += Time.deltaTime;

        // // 变红
        // if (timeSinceSpawn >= timeToChangeColor && timeSinceSpawn < timeToDie)
        // {
        //     GetComponent<SpriteRenderer>().color = Color.red;
        // }

        // 判断是否生存时间过长
        if (timeSinceSpawn >= timeToDie)
        {
            Debug.Log("You die");
            Destroy(gameObject);
        }

        if (OnFistAttack())
        {
            Debug.Log("Attack!");
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        if (!isClicked)
        {
            isClicked = true;
            Destroy(gameObject);
        }
    }

    private bool OnFistAttack()
    {
        Vector2 handPoint =
            new Vector2(_handToCircleMapper.handWorldPosition.x, _handToCircleMapper.handWorldPosition.y);
        if (_debugHandLandMarks.DetectFist() && _collider2D.IsTouching(_handToCircleMapper._collider2D))
        {
            return true;
        }

        return false;
    }
}

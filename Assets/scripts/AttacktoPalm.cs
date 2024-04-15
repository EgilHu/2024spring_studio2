using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttacktoPalm : MonoBehaviour
{
    private float timeSinceSpawn = 0f;
    public float timeToChangeColor = 2f;
    public float timeToDie = 4f;
    private bool isClicked = false;

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
    }

    private void OnMouseDown()
    {
        if (!isClicked)
        {
            isClicked = true;
            Destroy(gameObject);
        }
    }
}

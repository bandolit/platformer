using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rewind : MonoBehaviour
{
    public List<Vector3> tabPositions = new();
    public List<bool> tabRotations = new();
    bool rewinding = false;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!rewinding)
        {
            tabPositions.Add(transform.position);
            tabRotations.Add(spriteRenderer.flipX);
            Debug.Log("Tab[0] = " + tabPositions[0] + " " + tabPositions.Count);
            if (tabPositions.Count >= 2000)
            {
                tabPositions.RemoveAt(0);
            }

            if (tabRotations.Count >= 2000)
            {
                tabRotations.RemoveAt(0);
            }
        }
        else if (tabPositions.Count > 0)
        {
            spriteRenderer.color = Color.red;
            int index = tabPositions.Count - 1;
            transform.position = tabPositions[index];
            spriteRenderer.flipX = tabRotations[index];

            tabPositions.RemoveAt(index);
            tabRotations.RemoveAt(index);
        }
        else
        {
            spriteRenderer.color = Color.white;
            rewinding = false;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            rewinding = true;
            tabPositions.ToArray();
        }
    }
}
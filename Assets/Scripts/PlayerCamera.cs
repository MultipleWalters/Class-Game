using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEditor;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private Transform[] playerTransforms;
    private Transform cameraPos;
    private float xMin, xMax;
    private Camera currentCamera;
    public float minSize = 2.0f;
    public float zAxisStart;
    public float yAxisStart;

    
    private void Start()
    {
        currentCamera = GetComponent<Camera>();
        cameraPos = transform;     
        
    }
    private void LateUpdate()
    {
        if (playerTransforms == null)
        {
            return;
        }
        
        if(playerTransforms.Length == 0)
        {
            Debug.Log("No player found, ensure player tag is set to 'Player'");
            return;
        }
        xMin = xMax = playerTransforms[0].position.x;
        for(int i = 1; i < playerTransforms.Length; i++)
        {
            if (playerTransforms[i].position.x < xMin)
                xMin = playerTransforms[i].position.x;
            if (playerTransforms[i].position.x > xMax)
                xMax = playerTransforms[i].position.x;
        }

        
        float xMiddle = (xMin + xMax) / 2;
        float Size = (xMax - xMin) / currentCamera.aspect;
        if (Size < minSize)
        {
            Size = minSize;
        }

        transform.position = new Vector3(xMiddle, yAxisStart, zAxisStart);
        currentCamera.orthographicSize = Size;

    }

    public void GatherPlayers()
    {
        GameObject[] allPlayers = GameObject.FindGameObjectsWithTag("Player");
        playerTransforms = new Transform[allPlayers.Length];
        for (int i = 0; i < allPlayers.Length; i++)
        {
            playerTransforms[i] = allPlayers[i].transform;
        }
    }
}

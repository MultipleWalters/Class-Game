using Cinemachine;
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
    private CinemachineVirtualCamera currentCamera;
    public float minSize = 2.0f;
    public float maxSize = 6.0f;
    public float zAxisStart = -20;
    public float yAxisStart = 2.0f;
     
    
    private void Start()
    {
        currentCamera = GetComponent<CinemachineVirtualCamera>();
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
        float Size = (xMax - xMin);
        if (Size < minSize)
        {
            Size = minSize;
        }
        if (Size > maxSize)
        {
            Size = maxSize;
        }
        transform.position = new Vector3(xMiddle, yAxisStart + Size, zAxisStart);

        currentCamera.m_Lens.OrthographicSize = Size;

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

using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAddPlayerToVcamTargets : MonoBehaviour
{
    [TagField]
    public string Tag = "Player";
    // Update is called once per frame
    void Update()
    {
        var targetGroup = GetComponent<CinemachineTargetGroup>();
        var targets = GameObject.FindGameObjectsWithTag(Tag);
        for (int i = 0; i < targetGroup.m_Targets.Length; i++)
        {
            if (targetGroup != null && Tag.Length > 0)
            {
                if (targets.Length > 0)
                targetGroup.m_Targets[i].target = targets[i].transform;
            }
        }
    }
}

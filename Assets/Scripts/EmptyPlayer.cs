using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class EmptyPlayer : MonoBehaviourPun
{
    void Start()
    {
        GameManager.Instance.AddPlayer(photonView);
    }

    void Update()
    {
        
    }
}

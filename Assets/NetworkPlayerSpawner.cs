using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

using Unity.XR.CoreUtils;

public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    private GameObject spawnedPlayerPrefab;

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        spawnedPlayerPrefab = PhotonNetwork.Instantiate("Network Player", transform.position, transform.rotation);
    }
    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
    }
    public void DeactivatePlayer()
    {
        PhotonView player1 = PhotonView.Find(1001);
        PhotonView player2 = PhotonView.Find(2001);

        //head
        player1.GetComponentInChildren<MeshRenderer>().enabled = false;
        player2.GetComponentInChildren<MeshRenderer>().enabled = false;

        //hands
        SkinnedMeshRenderer[] p1hands = player1.GetComponentsInChildren<SkinnedMeshRenderer>();
        SkinnedMeshRenderer[] p2hands = player2.GetComponentsInChildren<SkinnedMeshRenderer>();

        for (int i = 0; i < p1hands.Length; i++)
        {
            p1hands[i].enabled = false;
            p2hands[i].enabled = false;
        }
    }

}

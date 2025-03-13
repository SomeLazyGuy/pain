using System;
using System.Collections.Generic;
using UnityEngine;

public class FollowManager : MonoBehaviour
{
    [SerializeField] private PlayerCollect playerCollect;
    [SerializeField] private GameObject keyPlacebo;

    //private List<GameObject> followers;
    private GameObject _follower;

    public void OnEnable()
    {
        playerCollect.keyPickedUpEvent.AddListener(AddFollowKey);
        playerCollect.doorOpenedEvent.AddListener(RemoveFollowKey);
    }

    private void AddFollowKey()
    {
        _follower = Instantiate(keyPlacebo, transform.position, Quaternion.identity);
    }
    private void RemoveFollowKey()
    {
        Destroy(_follower);
    }

    public void OnDisable()
    {
        playerCollect.keyPickedUpEvent.RemoveListener(AddFollowKey);
        playerCollect.doorOpenedEvent.RemoveListener(RemoveFollowKey);
    }
}

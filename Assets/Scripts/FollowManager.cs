using System;
using System.Collections.Generic;
using UnityEngine;

public class FollowManager : MonoBehaviour
{
    [SerializeField] private GameObject keyPlacebo;
    
    private GameObject player;
    private PlayerCollect playerCollect;    

    //private List<GameObject> followers;
    private GameObject _follower;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCollect = player.GetComponent<PlayerCollect>();
        
        playerCollect.keyPickedUpEvent.AddListener(AddFollowKey);    
        playerCollect.doorOpenedEvent.AddListener(RemoveFollowKey);  
    }

//   public void OnEnable()
//   {
//       playerCollect.keyPickedUpEvent.AddListener(AddFollowKey);
//       playerCollect.doorOpenedEvent.AddListener(RemoveFollowKey);
//   }

    private void AddFollowKey()
    {
        _follower = Instantiate(keyPlacebo, player.transform.position, Quaternion.identity);
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

using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour
{

    [SerializeField]
    private Transform player;
    [SerializeField]
    private float lerpRate;

    private Vector3 offset;

    // Use this for initialization
    void Start ()
    {
        offset = player.position - transform.position;
        offset.y = 0;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
	{
	    transform.position = Vector3.Lerp(transform.position,new Vector3(player.position.x, transform.position.y, player.position.z) + -offset, lerpRate);
	}
}

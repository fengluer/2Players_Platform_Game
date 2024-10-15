using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] public Transform player1;


    public static Camera instance;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player1.position.x, player1.position.y, transform.position.z);
    }
}

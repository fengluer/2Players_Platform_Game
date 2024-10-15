using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2_Manager : MonoBehaviour
{
    public LayerMask lm;
    public UnityEngine.Camera cam;
    public static  List<Player2_Move> player2 =new List<Player2_Move>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (var p in player2)
        {
            if (p == null)
                continue;
            p.OnDeselected();
            p.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Get the mouse position in world coordinates
            Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
            // Cast a ray from the mouse position
            RaycastHit2D hit = Physics2D.Raycast(new Vector2 (mousePosition.x, mousePosition.y), Vector2.zero,100,lm);
            //Debug.Log("1");
            // Check if the ray hit a collider
            if (hit.collider != null)
            {
                //Debug.Log(hit.collider);
                // Check if the collider hit is the one attached to this GameObject
                var current_Player = hit.collider.gameObject.GetComponent<Player2_Move>();
                if (current_Player!=null)
                {
                    //Debug.Log("Mouse clicked on the 2D collider attached to this GameObject.");
                    foreach(var p in player2)
                    {
                        if (p == current_Player)
                        {
                            if (p != null)
                            {
                                p.enabled = true;
                                p.OnSelected();
                            }
                        }
                        else
                        {
                            if (p != null)
                            {
                                p.OnDeselected();
                                p.enabled = false;
                            }
                        }
                    }
                }
            }
        }
     }
}

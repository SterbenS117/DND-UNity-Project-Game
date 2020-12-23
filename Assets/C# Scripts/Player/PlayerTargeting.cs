using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpriteActions;

public class PlayerTargeting : MonoBehaviour
{
    bool mouseSelecting;
    bool mouseReleased;
    bool mouseSelected;
    GameObject targetEnemy;
    Vector2 mousePosition1;
    List<GameObject> allenemies = new List<GameObject>();
    
    public GameObject TargetEnemy { get => targetEnemy; set => targetEnemy = value; }
    public bool MouseSelected { get => mouseSelected; set => mouseSelected = value; }

    // Start is called before the first frame update
    void Start()
    {
        
        for (int f = 0; f <= GameObject.FindGameObjectsWithTag("Enemy").Length - 1; f++)
        {
            //Debug.LogWarning("adding enemy " + f);
            allenemies.Add(GameObject.FindGameObjectsWithTag("Enemy")[f]);
        }
        mouseSelected = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Collider2D mouseSelection() {
        
        if (Input.GetMouseButtonDown(0))
        {
            //Camera.main.ScreenToViewportPoint(Input.mousePosition)
            Vector3 mouseUnproccessed = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 45);
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(mouseUnproccessed);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            
            //Debug.Log(mousePos2D.x + " " + mousePos2D.y);
            
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            //Debug.Log("workinh working");
            if (hit.rigidbody != null)
            {

                //hit.collider.attachedRigidbody.AddForce(Vector2.up);   //hit.collider.gameObject.name
                //Debug.Log(hit.transform.name);
                mouseSelected = true;
                return hit.collider;
            }
            
        }
        return null;
    }
} 


using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    private Vector3 mousePos;

    public GameObject certainScreen;

    public bool mouseDown;

    RaycastHit2D raycastHit2D;
    Transform preHoverObject, nextHoverObject;

    public Texture2D normalCursor;
    public Texture2D hoverCursor;

    public bool isHoveringOnTriggerbox;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {

        GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("triggerboxNeutral");

    }

    // Update is called once per frame
    void Update()
    {
        pointAndClick();

        if (Input.GetMouseButtonDown(0))
        {
            mouseDown = true;
            Debug.Log(mouseDown);
        }
        else
        {
            mouseDown = false;
        }

        certainScreen = nextHoverObject.transform.parent.gameObject;
        
    }


    void pointAndClick()
    {
        //Getting the Co-ords of the mousePosition in game
        mousePos = Input.mousePosition;
        Ray mouseRay = Camera.main.ScreenPointToRay(mousePos);

        preHoverObject = nextHoverObject;

        //Get a raycast and save the object in 'nextHoverObject'
        raycastHit2D = Physics2D.Raycast(mouseRay.origin, mouseRay.direction);
        nextHoverObject = raycastHit2D ? raycastHit2D.collider.transform : null;

        //if we did hit something
        if (nextHoverObject)
        {
            //Set Cursor mode to hovering

            Cursor.SetCursor(hoverCursor, new Vector2(400, 0), CursorMode.Auto);
            isHoveringOnTriggerbox = true;
            disableTriggerboxes();

            //Check if the object hovered before and after are equal to each other, if not, change to normal cursor
            if (preHoverObject && nextHoverObject && preHoverObject.GetInstanceID() != nextHoverObject.GetInstanceID())
            {
                Cursor.SetCursor(normalCursor, new Vector2(0, 0), CursorMode.Auto);
                isHoveringOnTriggerbox = false;
                enableTriggerboxes();
            }
        }

        else
        {
            if (preHoverObject)
            {
                Cursor.SetCursor(normalCursor, new Vector2(0, 0), CursorMode.Auto);
                isHoveringOnTriggerbox = false;
                enableTriggerboxes();
            }
        }


        void disableTriggerboxes()
        {
            nextHoverObject.gameObject.tag = "triggerboxOn";

            GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("triggerboxNeutral");
            foreach (GameObject go in gameObjectArray)
            {
                go.SetActive(false);
                Debug.Log("setting false");
            }
        }

        void enableTriggerboxes()
        {
            preHoverObject.gameObject.tag = "triggerboxNeutral";

            foreach (Transform t in certainScreen.transform)
            {
                t.gameObject.SetActive(t.gameObject); // if you want to disable all

            }

        }
    }
}

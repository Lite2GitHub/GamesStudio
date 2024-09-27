using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler, IPointerUpHandler
{
    //variables given by the parent
    public IHateMyselfSO hackData;
    public GameObject inWorldFlower;


    public GameObject occupiedSquare;

    [SerializeField] SetParentOnClick setParentOnClick; //I need this to access all of the grids in the flower, really  bad way to do it but
    [SerializeField] GridItemInventoryChecker gridItemInventoryChecker;

    [SerializeField] Transform parentTransform;

    [SerializeField] Sprite regularGrid;
    [SerializeField] Sprite incorrectlyPlacedGrid;

    GridSquareClickReparent gridSquareClickReparent;

    Transform universalItemHolder;
    RectTransform rectTransform;
    Canvas uiCanvas;
    CanvasGroup canvasGroup;
    Image image;

    bool spawnedPickUp = false;
    public bool hackForSpawn = true;
    Vector2 mouseOffset;

    PointerEventData passData;

    private void Awake()
    {
        gridSquareClickReparent = GetComponent<GridSquareClickReparent>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        uiCanvas = GameObject.FindGameObjectWithTag("UICanvas").GetComponent<Canvas>();
        universalItemHolder = GameObject.FindGameObjectWithTag("UIItemHolder").GetComponent<Transform>();
        image = GetComponent<Image>();

        //parentTransform = GetComponentInParent<Transform>().GetComponentInParent<Transform>(); //due to the reparenting with the flower grid it needs to grab the parent of the parent
        //print("the parent is: " + parentTransform);

        setParentOnClick = GetComponentInParent<SetParentOnClick>();
        gridItemInventoryChecker = GetComponentInParent<GridItemInventoryChecker>();

        if (Input.GetMouseButtonDown(0))
        {
            if (hackForSpawn)
            {
                spawnedPickUp = true;
            }
        }
    }

    //This update fucntion shoudn't exist but it was faster than coming up with a good solution
    void Update()
    {
        if (passData != null)
        {
            Vector2 mousePosition = new Vector2(Input.mousePosition.x - (Screen.width / 2), Input.mousePosition.y - (Screen.height / 2)); //mouse origin is bottom left ui is center have to offset
            mousePosition = mousePosition / uiCanvas.scaleFactor; //have to then divide by scale factor of cnavas to support any screen resolution

            rectTransform.anchoredPosition = mousePosition - mouseOffset;

            if (Input.GetMouseButtonUp(0))
            {
                gridSquareClickReparent.UnparentOnDeselect();
                spawnedPickUp = false;
                passData = null;
                hackForSpawn = false;
                canvasGroup.blocksRaycasts = true;
                RaySpawnFlowerOnGround();
                hackData.openInventoryHoverBook = false;
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        print("begin drag");
        parentTransform.SetParent(universalItemHolder);
        //canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;

        gridItemInventoryChecker.ResetOnPickup();

        if (occupiedSquare != null)
        {
            //ClearSquare();

            //clear sqaure for all grids
            foreach (GameObject grid in setParentOnClick.squareArray)
            {
                print("loops throug");
                grid.GetComponent<DragDrop>().ClearSquare();
            }
        }

        Vector2 mousePosition = new Vector2(Input.mousePosition.x - (Screen.width / 2), Input.mousePosition.y - (Screen.height / 2)); //mouse origin is bottom left ui is center have to offset
        mousePosition = mousePosition / uiCanvas.scaleFactor; //have to then divide by scale factor of cnavas to support any screen resolution

        Vector2 rectPosition = new Vector2(rectTransform.position.x - (Screen.width / 2), rectTransform.position.y - (Screen.height / 2));
        rectPosition = rectPosition / uiCanvas.scaleFactor;

        print("mouse position: " + mousePosition);
        print("rect trans pos: " + rectPosition);

        rectTransform.anchoredPosition = mousePosition - (rectPosition - rectTransform.anchoredPosition);
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / uiCanvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        gridItemInventoryChecker.CheckIfPlacedCorrectly();

        RaySpawnFlowerOnGround();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        print("pointer down");

        hackData.openInventoryHoverBook = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        hackData.openInventoryHoverBook = false;
    }

    public void SetOnSquare(GameObject squareBeingOccupied)
    {
        occupiedSquare = squareBeingOccupied;
        SnapOnDrop squareSOD = occupiedSquare.GetComponent<SnapOnDrop>();
        parentTransform.SetParent(squareSOD.itemHolder);
    }

    public void ClearSquare()
    {
        if (occupiedSquare != null)
        {
            occupiedSquare.GetComponent<SnapOnDrop>().EmptySqaure();
            this.occupiedSquare = null;
        }
    }

    public void AddToInventory(string itemName)
    {
        occupiedSquare.GetComponent<SnapOnDrop>().AddItemToInventory(itemName);
    }

    public void RemoveFromInventory(string itemName)
    {
        if (occupiedSquare != null)
        {
            occupiedSquare.GetComponent<SnapOnDrop>().RemoveFromInventory(itemName);
        }
    }

    //call this function from grid item manager script when placed to change if place incorrectly
    public void PlacedStateIndicatorChange(bool placedCorrectly)
    {
        if (placedCorrectly)
        {
            var tempColor = image.color;
            tempColor.a = 0f;
            image.color = tempColor;
            image.sprite = regularGrid;
        }
        else
        {
            var tempColor = image.color;
            tempColor.a = 1f;
            image.color = tempColor;
            image.sprite = incorrectlyPlacedGrid;
        }
    }

    void RaySpawnFlowerOnGround()
    {
        if (!hackData.inventoryOpen)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000, LayerMask.GetMask("Terrain")))
            {
                Instantiate(inWorldFlower, hit.point, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }

    // code ends here no reasoning scrolling anymore















    //Pretend this awful mess doesn't exist its my hack to get around spawning the tiles and the click even not gettting to register 
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (spawnedPickUp && hackForSpawn)
        {
            hackData.openInventoryHoverBook = true;
            hackData.hackyEventDataItem = gameObject;
            print("this gameobject: " + gameObject);
            passData = eventData;
            gridSquareClickReparent.ParentOnSelect();

            parentTransform.SetParent(universalItemHolder);
            //canvasGroup.alpha = 0.6f;
            canvasGroup.blocksRaycasts = false;

            gridItemInventoryChecker.ResetOnPickup();
            ClearOtherSqauresFromHack();

            if (occupiedSquare != null)
            {
                //ClearSquare();

                //clear sqaure for all grids
                foreach (GameObject grid in setParentOnClick.squareArray)
                {
                    grid.GetComponent<DragDrop>().ClearSquare();
                }
            }

            mouseOffset = new Vector2(Input.mousePosition.x - (Screen.width / 2), Input.mousePosition.y - (Screen.height / 2)); //mouse origin is bottom left ui is center have to offset
            mouseOffset = mouseOffset / uiCanvas.scaleFactor; //have to then divide by scale factor of cnavas to support any screen resolution
        }
    }

    void ClearOtherSqauresFromHack() //Im so sorry this function exists
    {
        foreach (GameObject grid in setParentOnClick.squareArray)
        {
            grid.GetComponent<DragDrop>().hackForSpawn = false;
        }
    }

    public void CheckIfPlaced()
    {
        gridItemInventoryChecker.CheckIfPlacedCorrectly();
    }


}

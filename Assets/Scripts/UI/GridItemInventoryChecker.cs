using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridItemInventoryChecker : MonoBehaviour
{
    [SerializeField] GameObject kickParticle;
    [SerializeField] Material kickMaterial;
    [SerializeField] GameObject inWorldFlowerGO;

    public string flowerType;

    [SerializeField] Image flowerImage;

    public bool placedCorrectly;

    SetParentOnClick setParentOnClick; //just to get all sqaure references, I should fix this
    List<GameObject> sqaureRefs = new List<GameObject>();

    private FMOD.Studio.EventInstance instance;

    void Start()
    {
        setParentOnClick = GetComponent<SetParentOnClick>();
        sqaureRefs = setParentOnClick.squareArray;
    }

    public void CheckIfPlacedCorrectly()
    {
        foreach (GameObject sqaure in sqaureRefs)
        {
            if (sqaure.GetComponent<DragDrop>().occupiedSquare == null)
            {

                var temppColor = flowerImage.color; //there was an error mesahe about the name of the variable idk was too lazy to fix so just named it temppColor instead
                temppColor.a = 0.5f;
                flowerImage.color = temppColor;

                foreach (GameObject square in sqaureRefs)
                {
                    DragDrop dragDrop = square.GetComponent<DragDrop>();
                    if (dragDrop.occupiedSquare != null)
                    {
                        dragDrop.PlacedStateIndicatorChange(true);
                    }
                    else
                    {
                        dragDrop.PlacedStateIndicatorChange(false);
                    }
                }

                placedCorrectly = false;
                PlaceFail();
                return;
            }
        }
        placedCorrectly = true;
        PlaceSuccess();
        var tempColor = flowerImage.color;
        tempColor.a = 1f;
        flowerImage.color = tempColor;

        setParentOnClick.squareArray[0].GetComponent<DragDrop>().AddToInventory(flowerType);
    }

    public void ResetOnPickup()
    {
        placedCorrectly = false;

        var tempColor = flowerImage.color;
        tempColor.a = 1f;
        flowerImage.color = tempColor;

        setParentOnClick.squareArray[0].GetComponent<DragDrop>().RemoveFromInventory(flowerType);
    }

    public void KickFromInventory()
    {
        print("kicked from inventory");

        var particle = Instantiate(kickParticle, GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position, Quaternion.identity);
        DropItemParticle dropItemParticle = particle.GetComponent<DropItemParticle>();

        dropItemParticle.dropMaterial = kickMaterial;
        dropItemParticle.flowerToSpawn = inWorldFlowerGO;

        dropItemParticle.Initiate();
        dropItemParticle.Play();

        foreach (GameObject grid in setParentOnClick.squareArray)
        {
            print("loops throug");
            grid.GetComponent<DragDrop>().ClearSquare();
        }

        Destroy(gameObject);
    }

    void PlaceSuccess()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/FlowerSuccess");
        instance.start();
        instance.release();
    }

    void PlaceFail()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/FlowerFail");
        instance.start();
        instance.release();
    }
}

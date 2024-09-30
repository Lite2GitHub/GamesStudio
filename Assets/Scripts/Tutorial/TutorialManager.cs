using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [Header ("General")]
    [SerializeField] IHateMyselfSO hackyData; //ignore this
    [SerializeField] TutorialTasksManager tutorialTasksManager;
    [SerializeField] SceneController sceneController;


    public int tutorialStage;

    [Header("Stage References")]
    [SerializeField] Transform moundTransform;
    [SerializeField] GridContentsManager gridContentsManager;


    [Header("Stage 0")]
    [SerializeField] GameObject flowerDorpParticleEffect;
    [SerializeField] int flowerDropAmount;
    [SerializeField] Material flowerDropMaterial;
    [SerializeField] GameObject flowerToSpawn;
    [SerializeField] Transform particleSpawnTransform;
    bool stage0t1DoOnce = true;
    bool stage0t2DoOnce = true;

    [Header("Stage 1")]
    [SerializeField] GameObject spirit;
    bool stage1t1DoOnce = true;

    void Update()
    {
        switch (tutorialStage)
        {
            case 0:
                if (hackyData.hackyEventDataItem!= null)
                {
                    if (stage0t1DoOnce)
                    {
                        tutorialTasksManager.RevealNextTask();
                        tutorialTasksManager.CompleteNextTask();
                        stage0t1DoOnce = false;
                    }
                }
                if (gridContentsManager.contents.Count > 0)
                {
                    if (stage0t2DoOnce)
                    {
                        tutorialTasksManager.CompleteNextTask();
                        stage0t2DoOnce = false;
                    }
                    
                    if (!hackyData.inventoryOpen)
                    {
                        for (int i = 0; i < flowerDropAmount; i++)
                        {
                            var particle = Instantiate(flowerDorpParticleEffect, moundTransform.position, Quaternion.identity);
                            DropItemParticle dropItemParticle = particle.GetComponent<DropItemParticle>();

                            dropItemParticle.dropMaterial = flowerDropMaterial;
                            dropItemParticle.flowerToSpawn = flowerToSpawn;
                            dropItemParticle.releaseAngle = 45;
                            dropItemParticle.Initiate();
                            dropItemParticle.Play();
                        }
                        tutorialStage++;
                    }
                }
                return;
            case 1:
                if (hackyData.inventoryOpen)
                {
                    if (stage1t1DoOnce)
                    {
                        tutorialTasksManager.RevealNextTask();

                        Instantiate(spirit, moundTransform.position, Quaternion.identity);
                        stage1t1DoOnce = false;
                    }

                    //var spiritInst = Instantiate(spirit, moundTransform.position, Quaternion.identity);
                    
                }
                return;
        }
    }
}

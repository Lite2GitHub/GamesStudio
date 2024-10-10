using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [Header ("General")]
    [SerializeField] IHateMyselfSO hackyData; //ignore this
    [SerializeField] TutorialTasksManager tutorialTasksManager;
    [SerializeField] SceneController sceneController;
    [SerializeField] HintController hintController;


    public int tutorialStage;

    [Header("Stage References")]
    [SerializeField] Transform moundTransform;
    [SerializeField] GridContentsManager gridContentsManager;


    [Header("Stage 0")]
    [SerializeField] GameObject flowerDorpParticleEffect0;
    [SerializeField] int flowerDropAmount0;
    [SerializeField] Material flowerDropMaterial0;
    [SerializeField] GameObject flowerToSpawn0;
    bool stage0t1DoOnce = true;
    bool stage0t2DoOnce = true;

    [Header("Stage 1")]
    [SerializeField] GameObject spirit;
    bool stage1t1DoOnce = true;
    bool stage1t2DoOnce = true;
    [SerializeField] GameObject flowerDorpParticleEffect1;
    [SerializeField] int flowerDropAmount1;
    [SerializeField] Material flowerDropMaterial1;
    [SerializeField] GameObject flowerToSpawn1;

    [Header("Stage 2")]
    bool stage2t1DoOnce = true;
    bool stage2t2DoOnce = true;

    [Header("Stage 3")]
    bool stage3t1DoOnce = true;
    bool stage3t2DoOnce = true;

    //general private variables
    SpiritManager spiritManager; //the manager from the tutorial spirit which will get assigned once instantiated

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
                        for (int i = 0; i < flowerDropAmount0; i++)
                        {
                            var particle = Instantiate(flowerDorpParticleEffect0, moundTransform.position, Quaternion.identity);
                            DropItemParticle dropItemParticle = particle.GetComponent<DropItemParticle>();

                            dropItemParticle.dropMaterial = flowerDropMaterial0;
                            dropItemParticle.flowerToSpawn = flowerToSpawn0;
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
                        hintController.GiveHint("Spirits speak thier own language and ask for flowers");

                        tutorialTasksManager.RevealNextTask();

                        spirit.SetActive(true);
                        spiritManager = spirit.GetComponent<SpiritManager>();
                        stage1t1DoOnce = false;
                    }

                    if (spiritManager.timerActive && stage1t2DoOnce)
                    {
                        tutorialTasksManager.CompleteNextTask();
                        tutorialTasksManager.RevealNextTask();
                        stage1t2DoOnce = false;
                    }
                }
                else
                {
                    if (spiritManager != null)
                    {
                        if (spiritManager.dialogueIndex == 1)
                        {
                            tutorialTasksManager.CompleteNextTask();

                            for (int i = 0; i < flowerDropAmount1; i++)
                            {
                                var particle = Instantiate(flowerDorpParticleEffect1, moundTransform.position, Quaternion.identity);
                                DropItemParticle dropItemParticle = particle.GetComponent<DropItemParticle>();

                                dropItemParticle.dropMaterial = flowerDropMaterial1;
                                dropItemParticle.flowerToSpawn = flowerToSpawn1;
                                dropItemParticle.releaseAngle = 45;
                                dropItemParticle.Initiate();
                                dropItemParticle.Play();
                            }
                            tutorialStage++;
                            tutorialTasksManager.RevealNextTask();
                        }
                    }
                }
                return;
            case 2:
                if (!hackyData.inventoryOpen)
                {
                    if (spiritManager.dialogueIndex == 2)
                    {
                        tutorialTasksManager.CompleteNextTask();
                        tutorialTasksManager.RevealNextTask();
                        tutorialStage++;

                        for (int i = 0; i < flowerDropAmount0; i++)
                        {
                            var particle = Instantiate(flowerDorpParticleEffect0, moundTransform.position, Quaternion.identity);
                            DropItemParticle dropItemParticle = particle.GetComponent<DropItemParticle>();

                            dropItemParticle.dropMaterial = flowerDropMaterial0;
                            dropItemParticle.flowerToSpawn = flowerToSpawn0;
                            dropItemParticle.releaseAngle = 45;
                            dropItemParticle.Initiate();
                            dropItemParticle.Play();
                        }

                        for (int i = 0; i < flowerDropAmount1; i++)
                        {
                            var particle = Instantiate(flowerDorpParticleEffect1, moundTransform.position, Quaternion.identity);
                            DropItemParticle dropItemParticle = particle.GetComponent<DropItemParticle>();

                            dropItemParticle.dropMaterial = flowerDropMaterial1;
                            dropItemParticle.flowerToSpawn = flowerToSpawn1;
                            dropItemParticle.releaseAngle = 45;
                            dropItemParticle.Initiate();
                            dropItemParticle.Play();
                        }
                    }
                }
                else
                {
                    if (stage2t2DoOnce)
                    {
                        print("rotate call");
                        hintController.GiveHint("Q and E will rotate the flower");
                        stage2t2DoOnce = false;
                    }
                    
                }
                return;
            case 3:
                if (stage3t1DoOnce)
                {
                    hintController.GiveHint("Their bouquet can only contain the flowers previously asked for");
                    stage3t1DoOnce = false;
                }
                
                if (!hackyData.inventoryOpen)
                {
                    if (spiritManager.dialogueIndex == 3 && stage2t1DoOnce)
                    {
                        if (stage3t2DoOnce)
                        {
                            hintController.GiveHint("Pick up the tear");
                            stage3t2DoOnce = false;
                        }
                        
                        if (gridContentsManager.contents.Contains("tear"))
                        {
                            sceneController.StartNextScene("LevelTest 1");
                            stage2t1DoOnce = false;
                        }
                    }
                }
                return;
        }
    }
}

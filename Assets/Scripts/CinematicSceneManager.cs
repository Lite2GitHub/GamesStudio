using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CinematicSceneManager : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;

    SceneController sceneController;

    void Start()
    {
        sceneController = GetComponent<SceneController>();

        videoPlayer.loopPointReached += VideoEnd;
    }

    void VideoEnd(UnityEngine.Video.VideoPlayer vp)
    {
        sceneController.StartNextScene("Tutorial");
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class RecordScene : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer _videoPlayer;

    [SerializeField]
    private Recorder _recorder;


    public IEnumerator OnClickRecord()
    {
        _videoPlayer.Play();
        _recorder.Record();
        yield return new WaitUntil(() => _videoPlayer.isPaused || !_videoPlayer.isPlaying);
        _recorder.StopRecord();
    }
}
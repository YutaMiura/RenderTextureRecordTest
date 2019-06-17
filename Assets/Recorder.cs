using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class Recorder : MonoBehaviour
{
    private Camera _camera;

    private bool _isRecording;

    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();         
    }

    // Update is called once per frame
    public void Record()
    {
        ClearFiles();
        _isRecording = true;
    }

    public void StopRecord()
    {
        _isRecording = false;
    }

    private void Update()
    {
        if (_isRecording)
        {
            CapturePerFrame();    
        }        
    }

    void ClearFiles()
    {
        foreach (var file in Directory.GetFiles("/Users/yutamiura/Desktop/test/"))
        {
            File.Delete(file);
        }
    }

    void CapturePerFrame()
    {
        var tex = _camera.targetTexture;
        var t = new Texture2D(tex.width, tex.height, TextureFormat.RGB24, false);
        t.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);
        t.Apply();

        var b = t.EncodeToJPG();

        File.WriteAllBytes($"/Users/yutamiura/Desktop/test/{i++}.jpg", b);
        
        Destroy(t);
    }

    void CreateVideoFile()
    {
        
    }
    
}

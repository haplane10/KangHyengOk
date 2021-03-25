using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class DeviceCamera : MonoBehaviour
{
    //WebCamTexture webCamTexture;
    [SerializeField] new MeshRenderer renderer;
    private WebCamDevice frontCameraDevice;
    private WebCamTexture frontCameraTexture;
    private WebCamDevice backCameraDevice;
    private WebCamTexture backCameraTexture;
    private WebCamDevice activeCameraDevice;
    private WebCamTexture activeCameraTexture;

    Texture2D photo;
    [SerializeField] Text cameraText;
    [SerializeField] Material capturedMat;

    void Start()
    {
#if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            Permission.RequestUserPermission(Permission.Camera);
        }

        if (WebCamTexture.devices.Length == 0)
        {
            cameraText.text = "No devices cameras found";
            return;
        }

        frontCameraDevice = WebCamTexture.devices.Last();
        //backCameraDevice = WebCamTexture.devices.First();

        frontCameraTexture = new WebCamTexture(frontCameraDevice.name);
        //backCameraTexture = new WebCamTexture(backCameraDevice.name);

        frontCameraTexture.filterMode = FilterMode.Trilinear;
        //backCameraTexture.filterMode = FilterMode.Trilinear;

        activeCameraTexture = frontCameraTexture;
        activeCameraDevice = WebCamTexture.devices.FirstOrDefault(device => device.name == frontCameraTexture.deviceName);

        renderer.material.mainTexture = activeCameraTexture; //Add Mesh Renderer to the GameObject to which this script is attached to
        activeCameraTexture.Play();
#else
        webCamTexture = new WebCamTexture();
        renderer.material.mainTexture = webCamTexture; //Add Mesh Renderer to the GameObject to which this script is attached to
        webCamTexture.Play();
#endif
    }

    public void OnTakePhotoButtonClick()
    {
        StartCoroutine(TakePhoto());
    }
    IEnumerator TakePhoto()  // Start this Coroutine on some button click
    {

        // NOTE - you almost certainly have to do this here:

        yield return new WaitForEndOfFrame();

        // it's a rare case where the Unity doco is pretty clear,
        // http://docs.unity3d.com/ScriptReference/WaitForEndOfFrame.html
        // be sure to scroll down to the SECOND long example on that doco page 

        photo = new Texture2D(frontCameraTexture.width, frontCameraTexture.height);
        photo.SetPixels(frontCameraTexture.GetPixels());
        photo.Apply();

        capturedMat.mainTexture = photo;
        ////Encode to a PNG
        //byte[] bytes = photo.EncodeToPNG();
        ////Write out the PNG. Of course you have to substitute your_path for something sensible
        //File.WriteAllBytes(Application.dataPath + "/Resources/photo.png", bytes);
    }
}

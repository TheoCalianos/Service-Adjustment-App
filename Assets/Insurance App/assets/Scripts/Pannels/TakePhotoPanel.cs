using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakePhotoPanel : MonoBehaviour, IPanel
{
  public RawImage photoTaken;
  public InputField photoNotes;
  public Text caseNumberText;
  private string imgPath;

  public void OnEnable()
  {
    caseNumberText.text =  "CASE NUMBER " + UIManager.Instance.activeCase.CaseId;
  }
  public void ProcessInfo()
  {

    if(string.IsNullOrEmpty(imgPath) == false)
    {
      Texture2D img = (Texture2D)NativeCamera.LoadImageAtPath(imgPath, 512, false);
      byte[] imgData = img.EncodeToPNG();
      UIManager.Instance.activeCase.photoTaken = imgData;
    }
    else
    {
      UIManager.Instance.activeCase.photoTaken = null;
    }
      UIManager.Instance.activeCase.photoNotes = photoNotes.text;
      UIManager.Instance.OverviewPanel.gameObject.SetActive(true);
      Debug.Log(UIManager.Instance.couter);
      if(UIManager.Instance.listObjects.Contains(UIManager.Instance.OverviewPanel.gameObject)){}
      else
      {
        UIManager.Instance.listObjects.Add(UIManager.Instance.OverviewPanel.gameObject);
        UIManager.Instance.couter ++;
      }
  }
  public void TakePictureButton()
  {
    TakePicture(512);
  }
  private void TakePicture( int maxSize )
{
	NativeCamera.Permission permission = NativeCamera.TakePicture( ( path ) =>
	{
		Debug.Log( "Image path: " + path );
		if( path != null )
		{
			// Create a Texture2D from the captured image
			Texture2D texture = NativeCamera.LoadImageAtPath( path, maxSize, false);
			if( texture == null )
			{
				Debug.Log( "Couldn't load texture from " + path );
				return;
			}

      photoTaken.texture = texture;
      photoTaken.gameObject.SetActive(true);
      imgPath = path;
			// Assign texture to a temporary quad and destroy it after 5 seconds
		}
	}, maxSize );

	Debug.Log( "Permission result: " + permission );
}

}

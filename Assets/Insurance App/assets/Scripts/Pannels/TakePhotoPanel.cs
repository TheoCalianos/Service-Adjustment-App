using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakePhotoPanel : MonoBehaviour, IPanel
{
  public RawImage photoTaken;
  public InputField photoNotes;
  public Text caseNumberText;

  public void OnEnable()
  {
    caseNumberText.text =  "CASE NUMBER " + UIManager.Instance.activeCase.CaseId;
  }
  public void ProcessInfo()
  {
      UIManager.Instance.activeCase.photoTaken = photoTaken.texture;
      UIManager.Instance.activeCase.photoNotes = photoNotes.text;
      UIManager.Instance.OverviewPanel.gameObject.SetActive(true);
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
			Texture2D texture = NativeCamera.LoadImageAtPath( path, maxSize );
			if( texture == null )
			{
				Debug.Log( "Couldn't load texture from " + path );
				return;
			}

      photoTaken.texture = texture;
      photoTaken.gameObject.SetActive(true);
			// Assign texture to a temporary quad and destroy it after 5 seconds
		}
	}, maxSize );

	Debug.Log( "Permission result: " + permission );
}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationPanel : MonoBehaviour, IPanel
{
  public RawImage mapImage;
  public InputField mapNotes;
  public float xCord, yCord;
  public int zoom;
  public int imgSize;
  public string url = "https://maps.googleapis.com/maps/api/staticmap?";

  public string apiKey;

  public void OnEnable()
  {
     url = url + "center=" + xCord + "," + yCord + "&zoom=" + zoom + "&size=" + imgSize + "x" + imgSize + "&key=" + apiKey;
     Debug.LogError(url);
     StartCoroutine(GetLocationRoutine());

  }
  IEnumerator GetLocationRoutine()
  {
    using(WWW map = new WWW(url))
    {
      yield return map;

      if (map.error != null)
      {
        Debug.LogError("Map Error" + map.error);
      }

      mapImage.texture = map.texture;
    }

  }
  public void ProcessInfo()
  {

  }
}

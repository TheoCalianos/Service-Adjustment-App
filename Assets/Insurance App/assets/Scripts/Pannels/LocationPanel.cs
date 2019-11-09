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

  public IEnumerator Start()
  {
    if(Input.location.isEnabledByUser == true)
    {
      Input.location.Start();

      int maxWait= 20;
      while(Input.location.status == LocationServiceStatus.Initializing && maxWait > 0 )
      {
        yield return new WaitForSeconds(1.0f);
        maxWait--;
      }
      if(maxWait < 1)
      {
        Debug.LogError("Timed Out");
        yield break;
      }
      else if(Input.location.status == LocationServiceStatus.Failed)
      {
        Debug.LogError("Failed to recive Location status");
      }
      else
      {
         xCord = Input.location.lastData.latitude;
         yCord = Input.location.lastData.longitude;
      }

      Input.location.Stop();

    }
    else
    {
      Debug.LogError("location services are not enabled.");
    }
     StartCoroutine(GetLocationRoutine());

  }
  IEnumerator GetLocationRoutine()
  {
    url = url + "center=" + xCord + "," + yCord + "&zoom=" + zoom + "&size=" + imgSize + "x" + imgSize + "&key=" + apiKey;
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

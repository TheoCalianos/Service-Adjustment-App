using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class LocationPanel : MonoBehaviour, IPanel
{
  public RawImage mapImage;
  public InputField mapNotes;
  public string xCord, yCord;
  public int zoom;
  public int imgSize;
  public string url = "https://maps.googleapis.com/maps/api/staticmap?";
  public Text caseNumberText;
  public InputField LocationNotes;
  public string mapApiKey;
  public string Geourl = "https://maps.googleapis.com/maps/api/geocode/json?";
  public AddressResult jsonaddress;

  public void OnEnable()
  {
      caseNumberText.text = UIManager.Instance.activeCase.CaseId;
  }
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
         xCord = Input.location.lastData.latitude.ToString();
         yCord = Input.location.lastData.longitude.ToString();
      }

      Input.location.Stop();

    }
    else
    {
      //Debug.LogError("location services are not enabled.");
    }
     StartCoroutine(GetLocationRoutine());
     StartCoroutine(GetAddress());

  }
  IEnumerator GetLocationRoutine()
  {
    url = url + "center=" + xCord + "," + yCord + "&zoom=" + zoom + "&size=" + imgSize + "x" + imgSize + "&key=" + mapApiKey;
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
  IEnumerator GetAddress()
  {
    Geourl = "https://maps.googleapis.com/maps/api/geocode/json?latlng="+xCord+","+yCord+"&key="+ mapApiKey;
    using(WWW address = new WWW(Geourl))
    {
      yield return address;

      if (address.error != null)
      {
        Debug.LogError("Map Error" + address.error);
      }
      jsonaddress = JsonUtility.FromJson<AddressResult>(address.text);
      UIManager.Instance.activeCase.location = jsonaddress.results[0].formatted_address;
			}

    }
  public void ProcessInfo()
  {
    if (string.IsNullOrEmpty(LocationNotes.text) == false)
    {
      UIManager.Instance.activeCase.locationNotes = LocationNotes.text;
    }
    UIManager.Instance.TakePhotoPanel.gameObject.SetActive(true);


  }
}

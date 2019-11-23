using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.Runtime;
using System.IO;
using System;
using Amazon.S3.Util;
using System.Collections.Generic;
using Amazon.CognitoIdentity;
using Amazon;

public class AWSManager : MonoBehaviour
{

  private static AWSManager _instance;
  public static AWSManager Instance
  {
    get
    {
        if(_instance == null)
        {
          Debug.LogError("AWS Manager is null");
        }
        return _instance;
      }
    }
    // Start is called before the first frame update
    public string S3Region =  RegionEndpoint.USEast2.SystemName;
    private RegionEndpoint _S3Region
    {
      get { return RegionEndpoint.GetBySystemName(S3Region); }
    }

    private AmazonS3Client _s3Client;

    public AmazonS3Client S3Client
    {
      get
      {
        if (_s3Client == null)
        {
          _s3Client = new AmazonS3Client (new CognitoAWSCredentials (
          "us-east-2:02d841ad-44c2-47da-94f7-dab27aca80dc", // Identity Pool ID
          RegionEndpoint.USEast2 // Region
          ), _S3Region);
        }
              return _s3Client;
      }
    }

    private void Awake()
    {
      _instance = this;

      UnityInitializer.AttachToGameObject(this.gameObject);
      AWSConfigs.HttpClient = AWSConfigs.HttpClientOption.UnityWebRequest;

      S3Client.ListBucketsAsync(new ListBucketsRequest(), (responseObject) =>
      {
          if (responseObject.Exception == null)
         {
              responseObject.Response.Buckets.ForEach((s3b) =>
             {
               Debug.Log("Bucket name: " + s3b.BucketName);

             });
         }
         else
         {
            Debug.Log("AWS ERROR" + responseObject.Exception);
         }
       });
    }
}

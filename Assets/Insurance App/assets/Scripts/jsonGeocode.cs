using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class AddressComponent
{
    public string long_name;
    public string short_name;
    public string[] types;
}

[Serializable]
public class Location
{
    public double lat;
    public double lng;
}

[Serializable]
public class Northeast
{
    public double lat;
    public double lng;
}

[Serializable]
public class Southwest
{
    public double lat;
    public double lng;
}

[Serializable]
public class Viewport
{
    public Northeast northeast;
    public Southwest southwest;
}

[Serializable]
public class Northeast2
{
    public double lat;
    public double lng;
}

[Serializable]
public class Southwest2
{
    public double lat;
    public double lng;
}

[Serializable]
public class Bounds
{
    public Northeast2 northeast;
    public Southwest2 southwest;
}

[Serializable]
public class Geometry
{
    public Location location;
    public string location_type;
    public Viewport viewport;
    public Bounds bounds;
}

[Serializable]
public class Result
{
    public AddressComponent[] address_components;
    public string formatted_address;
    public Geometry geometry;
    public string place_id;
    public string[] types;
}

[Serializable]
public class AddressResult
{
    public Result[] results;
    public string status;
}

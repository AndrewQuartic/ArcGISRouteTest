# ArcGIS Route Test

ArcGIS Route Test is a simple wrapper class / example for interfacing with Esri network analyst services. 

### Development

Requirements:

- .NET 4.5.2
- [ArcGIS Runtime 100.2.1](https://www.nuget.org/packages/Esri.ArcGISRuntime/100.2.1)
- Visual Studio 2015 or above

IMPORTANT 

- You should *always* explicitly specify the correct input spatial reference for each of the coordinates you pass in. 
Even if the coordinates look the same you should still explicitly set a value if it is different from the service, which is in [NAD_1983_StatePlane_California_VI_FIPS_0406_Feet (WKID 2230)](http://spatialreference.org/ref/esri/nad-1983-stateplane-california-vi-fips-0406-feet/).
- [NAD_1983_StatePlane_California_VI_FIPS_0406_Feet (WKID 2230)](http://spatialreference.org/ref/esri/nad-1983-stateplane-california-vi-fips-0406-feet/) is not the same as the projection that CAD is in, which is [GCS_North_American_1983 (WKID 4269)](http://spatialreference.org/ref/epsg/nad83/). All you need to do is specify the correct input spatial reference and the service will translate for you. 
- If you are using the composite geocoder we provided you it will return coordinates in [NAD_1983_StatePlane_California_VI_FIPS_0406_Feet (WKID 2230)](http://spatialreference.org/ref/esri/nad-1983-stateplane-california-vi-fips-0406-feet/). You must identify this before matching it with CAD coordinates.
If you're using Google as a locator then you're going to get coordinates returned as [WGS_1984_Web_Mercator_Auxiliary_Sphere (3857)](http://spatialreference.org/ref/sr-org/epsg3857-wgs84-web-mercator-auxiliary-sphere/). They look remakably similar to CAD's coordinates but they are not. To convert to CAD's coordinates you can use the following service.
- Please confirm both the name and WKID of CAD's coordinate type internally to make certain this is correct. 

### Resources

Please consult the following resources for tips on how to develop for ArcGIS Network Analysis Services.

- [ArcGIS Runtime SDK - Find a route](https://developers.arcgis.com/net/latest/android/sample-code/findroute.htm)
- [ArcGIS Runtime SDK for .NET API References](https://developers.arcgis.com/net/latest/api-reference/)
- [Network analysis services - Documentation](http://enterprise.arcgis.com/en/server/latest/publish-services/windows/network-analysis-services.htm)
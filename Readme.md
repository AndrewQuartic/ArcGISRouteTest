# ArcGIS Route Test

ArcGIS Route Test is a simple wrapper class / example for interfacing with Esri network analyst services. Includes console application for testing / prototyping. 

### Development

Requirements:

- .NET 4.5.2
- [ArcGIS Runtime 100.2.1](https://www.nuget.org/packages/Esri.ArcGISRuntime/100.2.1)
- Visual Studio 2015 or above

IMPORTANT 

- Some of the tools you will use reference data in different coordinate systems. It is very important to carefully review the data prior to proceeding. Not following proper procedures for projection translation will lead to differences in accuracy. This is true when dealing with data sourced from CAD, Google, and the City / SanGIS GIS data warehouse. 
- You should *always* explicitly specify the correct input spatial reference for each of the coordinates you pass in. 
Even if the coordinates look the same you should still explicitly set a value if it is different from the service, which is in [NAD_1983_StatePlane_California_VI_FIPS_0406_Feet (WKID 2230)](http://spatialreference.org/ref/esri/nad-1983-stateplane-california-vi-fips-0406-feet/).

  Example - *Same* sample point in 4 different systems, formatted as EsriJson:

  GCS_North_American_1983 (4269) - *CAD coordinates*
  ```
  {"geometries": [{
     "x": -117.0670431809381,
     "y": 32.761347321543
  }]}
  ```
  GCS_WGS_1984 (4326) - *Google Earth*
  ```
  {"geometries": [{
     "x": -117.06705506901389,
     "y": 32.76135209262446
  }]}
  ```
  NAD_1983_StatePlane_California_VI (2230) - *City / SanGIS coordinates in Atlas*
  ```
  {"geometries": [{
     "x": 6310487.005141617,
     "y": 1857778.0038371873
  }]}
  ```
  WGS_1984_Web_Mercator_Aux (102100 / 3857) - *Google Maps Coordinate*
  ```
  {"geometries": [{
     "x": -13031844.958950741,
     "y": 3863670.1178109264
  }]}
  ```  
- [NAD_1983_StatePlane_California_VI_FIPS_0406_Feet (WKID 2230)](http://spatialreference.org/ref/esri/nad-1983-stateplane-california-vi-fips-0406-feet/) is not the same as the projection that CAD is in, which is [GCS_North_American_1983 (WKID 4269)](http://spatialreference.org/ref/epsg/nad83/). All you need to do is specify the correct input spatial reference and the service will translate for you. 
- If you are using the composite geocoder we provided you it will return coordinates in [NAD_1983_StatePlane_California_VI_FIPS_0406_Feet (WKID 2230)](http://spatialreference.org/ref/esri/nad-1983-stateplane-california-vi-fips-0406-feet/). You must identify this before matching it with CAD coordinates.
If you're using Google as a locator then you're going to get coordinates returned as [WGS_1984_Web_Mercator_Auxiliary_Sphere (3857)](http://spatialreference.org/ref/sr-org/epsg3857-wgs84-web-mercator-auxiliary-sphere/). They look remakably similar to CAD's coordinates but they are not. To convert to CAD's coordinates you can use the following service.
- Please confirm both the name and WKID of CAD's coordinate type internally to make certain this is correct. 

### Resources

Please consult the following resources if you have questions regarding coordinate systems and how to reproject / convert:

- **[Projecting to different spatial references - Guide](https://developers.arcgis.com/net/10-2/desktop/guide/geometry-operations.htm#ESRI_SECTION2_98BDBE00EC5243F1BFA85323E76CCE4F)
- [Geometry Operations - Guide](https://developers.arcgis.com/net/10-2/desktop/guide/geometry-operations.htm)
- [Spatial references - Overview](https://developers.arcgis.com/net/10-2/desktop/guide/spatial-references.htm)

Please consult the following resources for tips on how to develop for ArcGIS Network Analysis Services.

- [ArcGIS Runtime SDK - Find a route](https://developers.arcgis.com/net/latest/android/sample-code/findroute.htm)
- [ArcGIS Runtime SDK for .NET API References](https://developers.arcgis.com/net/latest/api-reference/)
- [Network analysis services - Documentation](http://enterprise.arcgis.com/en/server/latest/publish-services/windows/network-analysis-services.htm)

using System.Collections.Generic;


namespace NasaImageLibrary.Applicationservice.Dtos
{
    public class AssetDto
    {
        public AssetCollection collection { get; set; }
    }

    public class AssetCollection
    {
        public double version { get; set; }
        public string href { get; set; }
        public List<AssetItem> items { get; set; }
      
    }

    public class AssetItem
    {
        public string href { get; set; }

    }
}



using System;
using System.Collections.Generic;

namespace NasaImageLibrary.Applicationservice.Dtos
{
    public class FileDto
    {
        public Collection collection { get; set; }
    }

    public class Collection
    {
        public double version { get; set; }
        //query href :
        public string href { get; set; }
        public List<Item> items { get; set; }
        public MetaData metaData { get; set; }
        public List<PageLink> links { get; set; }
    }
    public class MetaData
    {
        public int total_hits { get; set; }
    }

    public class PageLink
    {
        //query other pages href :
        public string href { get; set; }
        public string rel { get; set; }
        public string prompt { get; set; }
    }
    public class Item
    {
        //image assets :
        public string href { get; set; }
        public List<Datum> data { get; set; }
       
        public List<FileLink> links { get; set; }
    }

    public class Datum
    {
        public string center { get; set; }
        public string title { get; set; }
        public List<string> keywords { get; set; }
        public string nasa_id { get; set; }
        public DateTime date_created { get; set; }
        public string media_type { get; set; }
        public string description { get; set; }
    }

    public class FileLink
    { 
        //real image link :
        public string href { get; set; }
        public string rel { get; set; }
        public string render { get; set; }
    }
}

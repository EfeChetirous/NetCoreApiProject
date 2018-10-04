using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GreenFluxApi.Domain.Models
{
    
    public class Owner
    {
        [XmlAttribute(AttributeName = "nsid")]
        public string Nsid { get; set; }
        [XmlAttribute(AttributeName = "username")]
        public string Username { get; set; }
        [XmlAttribute(AttributeName = "realname")]
        public string Realname { get; set; }
        [XmlAttribute(AttributeName = "location")]
        public string Location { get; set; }
        [XmlAttribute(AttributeName = "iconserver")]
        public string Iconserver { get; set; }
        [XmlAttribute(AttributeName = "iconfarm")]
        public string Iconfarm { get; set; }
        [XmlAttribute(AttributeName = "path_alias")]
        public string Path_alias { get; set; }
    }
   
    public class Visibility
    {
        [XmlAttribute(AttributeName = "ispublic")]
        public string Ispublic { get; set; }
        [XmlAttribute(AttributeName = "isfriend")]
        public string Isfriend { get; set; }
        [XmlAttribute(AttributeName = "isfamily")]
        public string Isfamily { get; set; }
    }
    
    public class Dates
    {
        [XmlAttribute(AttributeName = "posted")]
        public string Posted { get; set; }
        [XmlAttribute(AttributeName = "taken")]
        public string Taken { get; set; }
        [XmlAttribute(AttributeName = "takengranularity")]
        public string Takengranularity { get; set; }
        [XmlAttribute(AttributeName = "takenunknown")]
        public string Takenunknown { get; set; }
        [XmlAttribute(AttributeName = "lastupdate")]
        public string Lastupdate { get; set; }
    }
    
    public class Editability
    {
        [XmlAttribute(AttributeName = "cancomment")]
        public string Cancomment { get; set; }
        [XmlAttribute(AttributeName = "canaddmeta")]
        public string Canaddmeta { get; set; }
    }
    
    public class Publiceditability
    {
        [XmlAttribute(AttributeName = "cancomment")]
        public string Cancomment { get; set; }
        [XmlAttribute(AttributeName = "canaddmeta")]
        public string Canaddmeta { get; set; }
    }
    
    public class Usage
    {
        [XmlAttribute(AttributeName = "candownload")]
        public string Candownload { get; set; }
        [XmlAttribute(AttributeName = "canblog")]
        public string Canblog { get; set; }
        [XmlAttribute(AttributeName = "canprint")]
        public string Canprint { get; set; }
        [XmlAttribute(AttributeName = "canshare")]
        public string Canshare { get; set; }
    }
    
    public class Note
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "photo_id")]
        public string Photo_id { get; set; }
        [XmlAttribute(AttributeName = "author")]
        public string Author { get; set; }
        [XmlAttribute(AttributeName = "authorname")]
        public string Authorname { get; set; }
        [XmlAttribute(AttributeName = "authorrealname")]
        public string Authorrealname { get; set; }
        [XmlAttribute(AttributeName = "authorispro")]
        public string Authorispro { get; set; }
        [XmlAttribute(AttributeName = "authorisdeleted")]
        public string Authorisdeleted { get; set; }
        [XmlAttribute(AttributeName = "x")]
        public string X { get; set; }
        [XmlAttribute(AttributeName = "y")]
        public string Y { get; set; }
        [XmlAttribute(AttributeName = "w")]
        public string W { get; set; }
        [XmlAttribute(AttributeName = "h")]
        public string H { get; set; }
        [XmlText]
        public string Text { get; set; }
    }
    
    public class Notes
    {
        [XmlElement(ElementName = "note")]
        public List<Note> Note { get; set; }
    }
    
    public class People
    {
        [XmlAttribute(AttributeName = "haspeople")]
        public string Haspeople { get; set; }
    }
    
    public class Tag
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "author")]
        public string Author { get; set; }
        [XmlAttribute(AttributeName = "authorname")]
        public string Authorname { get; set; }
        [XmlAttribute(AttributeName = "raw")]
        public string Raw { get; set; }
        [XmlAttribute(AttributeName = "machine_tag")]
        public string Machine_tag { get; set; }
        [XmlText]
        public string Text { get; set; }
    }
    
    public class Tags
    {
        [XmlElement(ElementName = "tag")]
        public List<Tag> Tag { get; set; }
    }
    
    public class Locality
    {
        [XmlAttribute(AttributeName = "place_id")]
        public string Place_id { get; set; }
        [XmlAttribute(AttributeName = "woeid")]
        public string Woeid { get; set; }
        [XmlText]
        public string Text { get; set; }
    }
    
    public class County
    {
        [XmlAttribute(AttributeName = "place_id")]
        public string Place_id { get; set; }
        [XmlAttribute(AttributeName = "woeid")]
        public string Woeid { get; set; }
        [XmlText]
        public string Text { get; set; }
    }
    public class Region
    {
        [XmlAttribute(AttributeName = "place_id")]
        public string Place_id { get; set; }
        [XmlAttribute(AttributeName = "woeid")]
        public string Woeid { get; set; }
        [XmlText]
        public string Text { get; set; }
    }
    
    public class Country
    {
        [XmlAttribute(AttributeName = "place_id")]
        public string Place_id { get; set; }
        [XmlAttribute(AttributeName = "woeid")]
        public string Woeid { get; set; }
        [XmlText]
        public string Text { get; set; }
    }
    
    public class Location
    {
        [XmlElement(ElementName = "locality")]
        public Locality Locality { get; set; }
        [XmlElement(ElementName = "county")]
        public County County { get; set; }
        [XmlElement(ElementName = "region")]
        public Region Region { get; set; }
        [XmlElement(ElementName = "country")]
        public Country Country { get; set; }
        [XmlAttribute(AttributeName = "latitude")]
        public string Latitude { get; set; }
        [XmlAttribute(AttributeName = "longitude")]
        public string Longitude { get; set; }
        [XmlAttribute(AttributeName = "accuracy")]
        public string Accuracy { get; set; }
        [XmlAttribute(AttributeName = "context")]
        public string Context { get; set; }
        [XmlAttribute(AttributeName = "place_id")]
        public string Place_id { get; set; }
        [XmlAttribute(AttributeName = "woeid")]
        public string Woeid { get; set; }
    }
    
    public class Geoperms
    {
        [XmlAttribute(AttributeName = "ispublic")]
        public string Ispublic { get; set; }
        [XmlAttribute(AttributeName = "iscontact")]
        public string Iscontact { get; set; }
        [XmlAttribute(AttributeName = "isfriend")]
        public string Isfriend { get; set; }
        [XmlAttribute(AttributeName = "isfamily")]
        public string Isfamily { get; set; }
    }
    
    public class Url
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }
    
    public class Urls
    {
        [XmlElement(ElementName = "url")]
        public Url Url { get; set; }
    }
    
    public class Photo
    {
        [XmlElement(ElementName = "owner")]
        public Owner Owner { get; set; }
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "visibility")]
        public Visibility Visibility { get; set; }
        [XmlElement(ElementName = "dates")]
        public Dates Dates { get; set; }
        [XmlElement(ElementName = "editability")]
        public Editability Editability { get; set; }
        [XmlElement(ElementName = "publiceditability")]
        public Publiceditability Publiceditability { get; set; }
        [XmlElement(ElementName = "usage")]
        public Usage Usage { get; set; }
        [XmlElement(ElementName = "comments")]
        public string Comments { get; set; }
        [XmlElement(ElementName = "notes")]
        public Notes Notes { get; set; }
        [XmlElement(ElementName = "people")]
        public People People { get; set; }
        [XmlElement(ElementName = "tags")]
        public Tags Tags { get; set; }
        [XmlElement(ElementName = "location")]
        public Location Location { get; set; }
        [XmlElement(ElementName = "geoperms")]
        public Geoperms Geoperms { get; set; }
        [XmlElement(ElementName = "urls")]
        public Urls Urls { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "secret")]
        public string Secret { get; set; }
        [XmlAttribute(AttributeName = "server")]
        public string Server { get; set; }
        [XmlAttribute(AttributeName = "farm")]
        public string Farm { get; set; }
        [XmlAttribute(AttributeName = "dateuploaded")]
        public string Dateuploaded { get; set; }
        [XmlAttribute(AttributeName = "isfavorite")]
        public string Isfavorite { get; set; }
        [XmlAttribute(AttributeName = "license")]
        public string License { get; set; }
        [XmlAttribute(AttributeName = "safety_level")]
        public string Safety_level { get; set; }
        [XmlAttribute(AttributeName = "rotation")]
        public string Rotation { get; set; }
        [XmlAttribute(AttributeName = "views")]
        public string Views { get; set; }
        [XmlAttribute(AttributeName = "media")]
        public string Media { get; set; }
    }

    [XmlRoot(ElementName = "rsp")]
    public class PhotoModel
    {
        [XmlElement(ElementName = "photo")]
        public Photo Photo { get; set; }
        [XmlAttribute(AttributeName = "stat")]
        public string Stat { get; set; }
    }

}

using System.Collections.Generic;

namespace ClubRoomDownloader.StageOne
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Analytics
    {
        public string rbbtitle { get; set; }
        public string rbbhandle { get; set; }
        public string ATIxtn2 { get; set; }
        public List<string> chapter { get; set; }
        public bool isTrailer { get; set; }
        public int duration { get; set; }
        public List<string> termids { get; set; }
    }

    public class Root
    {
        public string config { get; set; }
        public string media { get; set; }
        public Analytics analytics { get; set; }
    }


}

namespace ClubRoomDownloader.StageTwo
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class MediaStreamArray
    {
        public string _stream { get; set; }
        public string _termid { get; set; }
        public string _server { get; set; }
        public int _quality { get; set; }
    }

    public class MediaArray
    {
        public int _plugin { get; set; }
        public List<MediaStreamArray> _mediaStreamArray { get; set; }
    }

    public class Root
    {
        public List<int> _sortierArray { get; set; }
        public List<object> _defaultQuality { get; set; }
        public string rbbtitle { get; set; }
        public string rbbhandle { get; set; }
        public string _type { get; set; }
        public bool _isLive { get; set; }
        public bool _dvrEnabled { get; set; }
        public bool _geoblocked { get; set; }
        public int _duration { get; set; }
        public List<MediaArray> _mediaArray { get; set; }
    }


}
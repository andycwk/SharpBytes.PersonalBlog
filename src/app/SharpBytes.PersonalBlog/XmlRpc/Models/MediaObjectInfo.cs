using System.Runtime.Serialization;

namespace MetaWebBlog_spike.XmlRpc.Models
{
    public class MediaObjectInfo
    {
        [DataMember(Name = "url")]
        public string Url { get; set; }
    }
}

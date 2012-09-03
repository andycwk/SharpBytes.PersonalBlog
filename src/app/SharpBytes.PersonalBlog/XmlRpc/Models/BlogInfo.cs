namespace SharpBytes.PersonalBlog.XmlRpc.Models
{
    using System.Runtime.Serialization;

    public class BlogInfo
    {
        [DataMember(Name = "url")]
        public string url { get; set; }
        
		[DataMember(Name = "blogid")]
		public string blogid { get; set; }
		
		[DataMember(Name = "blogName")]
        public string blogName { get; set; }
    }
}

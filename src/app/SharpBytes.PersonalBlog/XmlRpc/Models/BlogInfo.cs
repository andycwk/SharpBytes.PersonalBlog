namespace SharpBytes.PersonalBlog.XmlRpc.Models
{
    using System.Runtime.Serialization;

    public class BlogInfo
    {
        [DataMember(Name = "url")]
        public string Url { get; set; }
        
		[DataMember(Name = "blogid")]
		public string Blogid { get; set; }
		
		[DataMember(Name = "blogName")]
        public string BlogName { get; set; }
    }
}

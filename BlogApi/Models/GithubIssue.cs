using System.Runtime.Serialization;

namespace BlogApi.Models
{
    [DataContract]
    public class GithubIssue
    {
        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "repository_url")]
        public string RepositoryUrl { get; set; }

        [DataMember(Name = "labels_url")]
        public string LabelsUrl { get; set; }

        [DataMember(Name = "comments_url")]
        public string CommentsUrl { get; set; }

        [DataMember(Name = "events_url")]
        public string EventsUrl { get; set; }

        [DataMember(Name = "html_url")]
        public string HtmlUrl { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "number")]
        public string Number { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "labels")]
        public string Labels { get; set; }

        [DataMember(Name = "state")]
        public string State { get; set; }

        [DataMember(Name = "milestone")]
        public string Milestone { get; set; }

        [DataMember(Name = "comments")]
        public string Comments { get; set; }

        [DataMember(Name = "created_at")]
        public string CreatedAt { get; set; }

        [DataMember(Name = "updated_at")]
        public string UpdatedAt { get; set; }

        [DataMember(Name = "closed_at")]
        public string ClosedAt { get; set; }

        [DataMember(Name = "body")]
        public string Body { get; set; }
    }
}
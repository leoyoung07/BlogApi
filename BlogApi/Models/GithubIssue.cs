using System;
using System.Collections.Generic;
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
        public long Id { get; set; }

        [DataMember(Name = "number")]
        public int Number { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "labels")]
        public List<Label> Labels { get; set; }

        [DataMember(Name = "state")]
        public string State { get; set; }

        [DataMember(Name = "milestone")]
        public Milestone Milestone { get; set; }

        [DataMember(Name = "comments")]
        public int Comments { get; set; }

        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }

        [DataMember(Name = "updated_at")]
        public DateTime UpdatedAt { get; set; }

        [DataMember(Name = "closed_at")]
        public DateTime ClosedAt { get; set; }

        [DataMember(Name = "body")]
        public string Body { get; set; }
    }

    [DataContract]
    public class Label
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "node")]
        public string NodeId { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "color")]
        public string Color { get; set; }

        [DataMember(Name = "default")]
        public bool Default { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }
    }

    [DataContract]
    public class Milestone
    {
        // TODO class Milestone
    }
}
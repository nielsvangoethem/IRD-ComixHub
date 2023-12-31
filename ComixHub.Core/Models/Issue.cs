﻿using MongoDB.Bson.Serialization.Attributes;

namespace ComixHub.Core.Models
{
    [BsonIgnoreExtraElements]
    public class Issue : BaseEntity
    {
        [BsonElement("title")]
        public string Title { get; set; }

        // TODO: Rename
        [BsonElement("comic_description")]
        public string Description { get; set; }

        // TODO: Rename
        [BsonElement("imageUrl")]
        public string ImageUrl { get; set; }

        [BsonElement("publish_date")]
        public string PublishDate { get; set; }

        [BsonElement("issue_number")]
        public int IssueNumber { get; set; }

        [BsonElement("imprint")]
        public string Imprint { get; set; }

        // TODO: Remove semicolons
        [BsonElement("rating:")]
        public string Rating { get; set; }

        [BsonElement("price:")]
        public string Price { get; set; }

        [BsonElement("writer:")]
        public string Writer { get; set; }

        [BsonElement("inker:")]
        public string Inker { get; set; }

        [BsonElement("colorist:")]
        public string Colorist { get; set; }

        [BsonElement("letterer:")]
        public string Letterer { get; set; }

        [BsonElement("penciler:")]
        public string Penciler { get; set; }

        [BsonElement("editor:")]
        public string Editor { get; set; }
    }
}

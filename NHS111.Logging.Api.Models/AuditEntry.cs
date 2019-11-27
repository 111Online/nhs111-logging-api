using System;
using Newtonsoft.Json;

namespace NHS111.Logging.Api.Models
{
    public class AuditEntry : LogEntry
    {
        [JsonProperty(PropertyName = "TIMESTAMP")]
        public DateTime TIMESTAMP { get; set; }

        [JsonProperty(PropertyName = "sessionId")]
        public Guid SessionId { get; set; }

        [JsonProperty(PropertyName = "journeyId")]
        public string JourneyId { get; set; }

        [JsonProperty(PropertyName = "campaign")]
        public string Campaign { get; set; }

        [JsonProperty(PropertyName = "campaignSource")]
        public string CampaignSource { get; set; }

        [JsonProperty(PropertyName = "pathwayId")]
        public string PathwayId { get; set; }

        [JsonProperty(PropertyName = "pathwayTitle")]
        public string PathwayTitle { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "journey")]
        public string Journey { get; set; }

        [JsonProperty(PropertyName = "answerTitle")]
        public string AnswerTitle { get; set; }

        [JsonProperty(PropertyName = "answerOrder")]
        public string AnswerOrder { get; set; }

        [JsonProperty(PropertyName = "questionTitle")]
        public string QuestionTitle { get; set; }

        [JsonProperty(PropertyName = "questionNo")]
        public string QuestionNo { get; set; }

        [JsonProperty(PropertyName = "questionId")]
        public string QuestionId { get; set; }

        [JsonProperty(PropertyName = "dxCode")]
        public string DxCode { get; set; }

        [JsonProperty(PropertyName = "eventData")]
        public string EventData { get; set; }

        [JsonProperty(PropertyName = "eventKey")]
        public string EventKey { get; set; }

        [JsonProperty(PropertyName = "eventValue")]
        public string EventValue { get; set; }

        [JsonProperty(PropertyName = "page")]
        public string Page { get; set; }

        [JsonProperty(PropertyName = "age")]
        public int? Age { get; set; }

        [JsonProperty(PropertyName = "gender")]
        public string Gender { get; set; }

        [JsonProperty(PropertyName = "search")]
        public string Search { get; set; }

        [JsonProperty(PropertyName = "dosRequest")]
        public string DosRequest { get; set; }

        [JsonProperty(PropertyName = "dosResponse")]
        public string DosResponse { get; set; }

        [JsonProperty(PropertyName = "itkRequest")]
        public string ItkRequest { get; set; }

        [JsonProperty(PropertyName = "itkResponse")]
        public string ItkResponse { get; set; }
    }
}

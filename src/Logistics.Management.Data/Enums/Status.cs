using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Logistics.Management.Data.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Status
    {
        [Description("Requested")]
        REQUESTED = 1,

        [Description("Collection")]
        COLLECTION = 2,

        [Description("Sent")]
        SENT = 3,

        [Description("Received")]
        RECEIVED = 4,
    }
}
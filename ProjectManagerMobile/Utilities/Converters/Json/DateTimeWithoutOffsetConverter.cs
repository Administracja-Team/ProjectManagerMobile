using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectManagerMobile.Utilities.Converters.Json
{
    public class DateTimeWithoutOffsetConverter : JsonConverter<DateTime>
    {
        private const string Format = "yyyy-MM-ddTHH:mm:ss.fffffff";

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var str = reader.GetString();
            return DateTime.Parse(str ?? "", null, System.Globalization.DateTimeStyles.RoundtripKind);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            var dateWithoutOffset = DateTime.SpecifyKind(value, DateTimeKind.Unspecified);
            var dateString = dateWithoutOffset.ToString(Format);
            writer.WriteStringValue(dateString);
        }
    }

}

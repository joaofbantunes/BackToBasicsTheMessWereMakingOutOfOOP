using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Domain;
using TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Shared;

namespace TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.ModelBinding
{
    public class StronglyTypedIdConverter : JsonConverter<StronglyTypedId>
    {
        public override bool CanConvert(Type typeToConvert)
            => typeof(StronglyTypedId).IsAssignableFrom(typeToConvert);

        
        public override void Write(Utf8JsonWriter writer, StronglyTypedId value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Value);
        }
        
        // don't need read for now, model binding handles input, Write handles output 
        public override StronglyTypedId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => throw new NotImplementedException();
    }
}
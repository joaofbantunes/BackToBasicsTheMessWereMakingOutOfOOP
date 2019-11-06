using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Domain;
using TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Shared;

namespace TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.ModelBinding
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
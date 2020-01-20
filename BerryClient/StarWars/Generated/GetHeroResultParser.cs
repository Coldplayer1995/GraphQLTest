using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using StrawberryShake;
using StrawberryShake.Http;
using StrawberryShake.Http.Subscriptions;
using StrawberryShake.Transport;

namespace BerryClient
{
    public class GetHeroResultParser
        : JsonResultParserBase<IGetHero>
    {
        private readonly IValueSerializer _stringSerializer;

        public GetHeroResultParser(IValueSerializerResolver serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _stringSerializer = serializerResolver.GetValueSerializer("String");
        }

        protected override IGetHero ParserData(JsonElement data)
        {
            return new GetHero
            (
                ParseGetHeroHero(data, "hero")
            );

        }

        private ICharacter ParseGetHeroHero(
            JsonElement parent,
            string field)
        {
            if (!parent.TryGetProperty(field, out JsonElement obj))
            {
                return null;
            }

            if (obj.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            string type = obj.GetProperty(TypeName).GetString();

            switch(type)
            {
                case "Human":
                    return new SomeHuman
                    (
                        DeserializeNullableString(obj, "homePlanet"),
                        DeserializeNullableString(obj, "name")
                    );

                case "Droid":
                    return new SomeDroid
                    (
                        DeserializeNullableString(obj, "primaryFunction"),
                        DeserializeNullableString(obj, "name")
                    );

                default:
                    throw new UnknownSchemaTypeException(type);
            }
        }

        private string DeserializeNullableString(JsonElement obj, string fieldName)
        {
            if (!obj.TryGetProperty(fieldName, out JsonElement value))
            {
                return null;
            }

            if (value.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            return (string)_stringSerializer.Deserialize(value.GetString());
        }
    }
}

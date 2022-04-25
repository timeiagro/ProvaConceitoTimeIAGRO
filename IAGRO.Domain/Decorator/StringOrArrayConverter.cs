﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace IAGRO.Domain.Decorator
{
    /// <summary>
    /// Reference: https://docs.microsoft.com/pt-br/dotnet/standard/serialization/system-text-json-converters-how-to?pivots=dotnet-core-3-1
    /// </summary>
    public class StringOrArrayConverter<TCollection, TItem> : JsonConverter<TCollection> where TCollection : class, ICollection<TItem>, new()
    {
        public StringOrArrayConverter() : this(true) { }
        public StringOrArrayConverter(bool canWrite) => CanWrite = canWrite;
        public bool CanWrite { get; }

        public override TCollection Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.Null:
                    return null;
                case JsonTokenType.StartArray:
                    var list = new TCollection();
                    while (reader.Read())
                    {
                        if (reader.TokenType == JsonTokenType.EndArray)
                        {
                            break;
                        }

                        list.Add(JsonSerializer.Deserialize<TItem>(ref reader, options));
                    }
                    return list;
                default:
                    return new TCollection { JsonSerializer.Deserialize<TItem>(ref reader, options) };
            }
        }

        public override void Write(Utf8JsonWriter writer, TCollection value, JsonSerializerOptions options)
        {
            if (CanWrite && value.Count == 1)
            {
                JsonSerializer.Serialize(writer, value.First(), options);
            }
            else
            {
                writer.WriteStartArray();

                foreach (var item in value)
                {
                    JsonSerializer.Serialize(writer, item, options);
                }

                writer.WriteEndArray();
            }
        }
    }
}

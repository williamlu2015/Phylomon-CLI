﻿using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using PhylomonCLI.model.cards;
namespace PhylomonCLI

{
    public class HashSetEnumConverter<T> : JsonConverter<HashSet<T>>
    {
        public override HashSet<T> ReadJson(JsonReader reader, Type objectType, HashSet<T> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string stringSet = (string)reader.Value;
            string[] tokens = stringSet.Split(',');
            HashSet<T> items = new HashSet<T>();
            foreach (string token in tokens)
            {
                items.Add((T)Enum.Parse(typeof(T), token, true));
            }
            return items;
        }

        public override void WriteJson(JsonWriter writer, HashSet<T> value, JsonSerializer serializer)
        {
            StringBuilder sb = new StringBuilder();
            foreach (T property in value)
            {
                sb.Append(property);
                sb.Append(",");
            }
            writer.WriteValue(sb.Remove(sb.Length - 1, sb.Length).ToString());
        }

        public override bool CanRead
        {
            get
            {
                return typeof(T) == typeof(Terrain)
                    || typeof(T) == typeof(Climate);
            }
        }

        public override bool CanWrite
        {
            get
            {
                return typeof(T) == typeof(Terrain)
                    || typeof(T) == typeof(Climate);
            }
        }
    }
}

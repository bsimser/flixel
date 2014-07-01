using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace org.flixel
{
    public class FlxSaveData
    {
        public FlxSaveData()
        {
            _data = new Dictionary<string, string>();
        }

        public string this[string key]
        {
            get
            {
                if (_data.ContainsKey(key))
                    return _data[key];
                return null;
            }
            set
            {
                if (_data.ContainsKey(key))
                {
                    _data[key] = value;
                }
                else
                {
                    _data.Add(key, value);
                }
            }
        }
        private Dictionary<string, string> _data;

        public void serialize(Stream writer)
        {
            List<FlxSaveDataEntry> entries = new List<FlxSaveDataEntry>(_data.Count);
            foreach (string key in _data.Keys)
            {
                entries.Add(new FlxSaveDataEntry(key, _data[key]));
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<FlxSaveDataEntry>));
            serializer.Serialize(writer, entries);
        }

        public void deserialize(Stream reader)
        {
            _data.Clear();
            XmlSerializer serializer = new XmlSerializer(typeof(List<FlxSaveDataEntry>));
            List<FlxSaveDataEntry> list = (List<FlxSaveDataEntry>)serializer.Deserialize(reader);

            foreach (FlxSaveDataEntry entry in list)
            {
                _data[entry.Key] = entry.Value;
            }
        }
    }
}
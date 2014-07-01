namespace org.flixel
{
    public class FlxSaveDataEntry
    {
        public string Key;
        public string Value;

        public FlxSaveDataEntry()
        {
        }

        public FlxSaveDataEntry(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
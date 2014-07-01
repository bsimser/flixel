namespace org.flixel
{
    public class FlxRect
    {
        public float x;
        public float y;

        public FlxRect(float X, float Y, float Width, float Height)
        {
            x = X;
            y = Y;
            width = Width;
            height = Height;
        }

        public float width { get; set; }

        public float height { get; set; }

        public static FlxRect Empty
        {
            get { return new FlxRect(0, 0, 0, 0); }
        }
    }
}
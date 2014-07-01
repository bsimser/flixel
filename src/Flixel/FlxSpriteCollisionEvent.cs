using System;

namespace org.flixel
{
    public class FlxSpriteCollisionEvent : EventArgs
    {
        private FlxObject _s1;
        private FlxObject _s2;

        public FlxSpriteCollisionEvent(FlxObject Attacker, FlxObject Target)
        {
            _s1 = Attacker;
            _s2 = Target;
        }

        public FlxObject Object1
        {
            get { return _s1; }
        }
        public FlxObject Object2
        {
            get { return _s2; }
        }
    }
}
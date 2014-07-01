using System;

namespace org.flixel
{
    public class FlxEffectCompletedEvent : EventArgs
    {
        private EffectType _effectType;

        public FlxEffectCompletedEvent(EffectType Effect)
        {
            this._effectType = Effect;
        }

        public EffectType effect
        {
            get { return _effectType; }
        }
    }
}
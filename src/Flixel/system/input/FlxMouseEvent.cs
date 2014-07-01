using System;

namespace org.flixel.system.input
{
    public class FlxMouseEvent : EventArgs
    {
        private MouseEventType _mouseType;

        public FlxMouseEvent(MouseEventType MouseEvent)
        {
            this._mouseType = MouseEvent;
        }

        public MouseEventType eventType
        {
            get { return _mouseType; }
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gwen
{
    [Flags]
    public enum Pos
    {
        None = 0,
        Left = 1 << 1,
        Right = 1 << 2,
        Top = 1 << 3,
        Bottom = 1 << 4,
        CenterV = 1 << 5,
        CenterH = 1 << 6,
        Fill = 1 << 7,
        Center = CenterV | CenterH,
    }
}

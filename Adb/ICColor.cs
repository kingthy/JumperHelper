using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JumperHelper.Adb
{
    /// <summary>
    /// 图像颜色
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct ICColor
    {
        [FieldOffset(0)]
        public byte B;
        [FieldOffset(1)]
        public byte G;
        [FieldOffset(2)]
        public byte R;


    }
}

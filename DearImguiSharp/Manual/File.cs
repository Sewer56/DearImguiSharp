using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DearImguiSharp.Manual
{
    public unsafe struct File
    {
        public void* Placeholder;

        public File(void* placeholder)
        {
            Placeholder = placeholder;
        }
    }
}

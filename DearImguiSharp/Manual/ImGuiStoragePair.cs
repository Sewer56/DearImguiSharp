using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace DearImguiSharp.Manual
{
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct ImGuiStoragePair
    {
        [FieldOffset(0)]
        uint key;
        
        [FieldOffset(4)]
        int val_i;

        [FieldOffset(4)]
        float val_f;

        [FieldOffset(4)]
        void* val_p;

        public ImGuiStoragePair(uint key, int valI) : this()
        {
            this.key = key;
            val_i = valI;
        }

        public ImGuiStoragePair(uint key, float valF) : this()
        {
            this.key = key;
            val_f = valF;
        }

        public ImGuiStoragePair(uint key, void* valP) : this()
        {
            this.key = key;
            val_p = valP;
        }
    }
}

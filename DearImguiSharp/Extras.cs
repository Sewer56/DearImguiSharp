using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace DearImguiSharp
{
    // TODO: Autogenerate this code!
    public partial class IDirect3DDevice9
    {
        public unsafe IDirect3DDevice9(void* native) : this(native, false) { }
        public static unsafe implicit operator IDirect3DDevice9(void* b) => new IDirect3DDevice9(b);
    }

    public partial class ID3D11Device
    {
        public unsafe ID3D11Device(void* native) : this(native, false) { }
        public static unsafe implicit operator ID3D11Device(void* b) => new ID3D11Device(b);
    }

    public partial class ID3D11DeviceContext
    {
        public unsafe ID3D11DeviceContext(void* native) : this(native, false) { }
        public static unsafe implicit operator ID3D11DeviceContext(void* b) => new ID3D11DeviceContext(b);
    }

    public unsafe partial class ImVectorImTextureID : IDisposable
    {
        public void** Data
        {
            get
            {
                return (void**) ((global::DearImguiSharp.ImVectorImTextureID.__Internal*)__Instance)->Data;
            }
            set
            {
                ((global::DearImguiSharp.ImVectorImTextureID.__Internal*)__Instance)->Data = (IntPtr) value;
            }
        }
    }

    public unsafe partial class ImVector_const_charPtr
    {
        public sbyte** Data
        {
            get
            {
                return (sbyte**)((__Internal*)__Instance)->Data;
            }
        }
    }
}

using System;
using System.Runtime.InteropServices;

namespace DearImguiSharp
{
    public partial class ImGui
    {
        [DllImport("cimgui.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImGui_ImplWin32_WndProcHandler")] 
        public static extern unsafe IntPtr ImplWin32_WndProcHandler(void* hwnd, uint msg, IntPtr wParam, IntPtr lParam);
    }
}

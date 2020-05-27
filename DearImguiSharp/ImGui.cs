using System;
using System.Runtime.InteropServices;

namespace ImGui
{
    public class ImGui : cimgui
    {
        [DllImport("cimgui.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImGui_ImplWin32_WndProcHandler")] 
        private static extern unsafe IntPtr ImplWin32_WndProcHandler(void* hwnd, uint msg, IntPtr wParam, IntPtr lParam);
    }
}

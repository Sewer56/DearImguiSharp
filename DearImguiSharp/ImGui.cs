using System;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security;

namespace DearImguiSharp
{
    public partial class ImGui
    {
        [DllImport("cimgui.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImGui_ImplWin32_WndProcHandler")] 
        public static extern unsafe IntPtr ImplWin32_WndProcHandler(void* hwnd, uint msg, IntPtr wParam, IntPtr lParam);

        public unsafe class Custom
        {
            #region Integer Widgets w/ Raw Pointers

            [SuppressUnmanagedCodeSecurity]
            [DllImport("cimgui.dll", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl, EntryPoint = "igSliderInt2")]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern bool SliderInt2([MarshalAs(UnmanagedType.LPUTF8Str)] string label, int* v, int v_min, int v_max, [MarshalAs(UnmanagedType.LPUTF8Str)] string format = "%d");

            [SuppressUnmanagedCodeSecurity]
            [DllImport("cimgui.dll", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl, EntryPoint = "igSliderInt3")]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern bool SliderInt3([MarshalAs(UnmanagedType.LPUTF8Str)] string label, int* v, int v_min, int v_max, [MarshalAs(UnmanagedType.LPUTF8Str)] string format = "%d");

            [SuppressUnmanagedCodeSecurity]
            [DllImport("cimgui.dll", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl, EntryPoint = "igSliderInt4")]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern bool SliderInt4([MarshalAs(UnmanagedType.LPUTF8Str)] string label, int* v, int v_min, int v_max, [MarshalAs(UnmanagedType.LPUTF8Str)] string format = "%d");

            [SuppressUnmanagedCodeSecurity]
            [DllImport("cimgui.dll", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl, EntryPoint = "igDragInt2")]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern unsafe bool DragInt2([MarshalAs(UnmanagedType.LPUTF8Str)] string label, int* v, float v_speed, int v_min = 0, int v_max = 0, [MarshalAs(UnmanagedType.LPUTF8Str)] string format = "%d");

            [SuppressUnmanagedCodeSecurity]
            [DllImport("cimgui.dll", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl, EntryPoint = "igDragInt3")]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern unsafe bool DragInt3([MarshalAs(UnmanagedType.LPUTF8Str)] string label, int* v, float v_speed, int v_min = 0, int v_max = 0, [MarshalAs(UnmanagedType.LPUTF8Str)] string format = "%d");

            [SuppressUnmanagedCodeSecurity]
            [DllImport("cimgui.dll", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl, EntryPoint = "igDragInt4")]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern unsafe bool DragInt4([MarshalAs(UnmanagedType.LPUTF8Str)] string label, int* v, float v_speed, int v_min = 0, int v_max = 0, [MarshalAs(UnmanagedType.LPUTF8Str)] string format = "%d");

            [SuppressUnmanagedCodeSecurity]
            [DllImport("cimgui.dll", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl, EntryPoint = "igInputInt2")]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern bool InputInt2([MarshalAs(UnmanagedType.LPUTF8Str)] string label, int* v, int flags);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("cimgui.dll", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl, EntryPoint = "igInputInt3")]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern bool InputInt3([MarshalAs(UnmanagedType.LPUTF8Str)] string label, int* v, int flags);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("cimgui.dll", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl, EntryPoint = "igInputInt4")]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern bool InputInt4([MarshalAs(UnmanagedType.LPUTF8Str)] string label, int* v, int flags);
            
            
            #endregion


            #region Float Widgets w/ Raw Pointers
            [SuppressUnmanagedCodeSecurity]
            [DllImport("cimgui.dll", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl, EntryPoint = "igDragFloat2")]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern unsafe bool DragFloat2([MarshalAs(UnmanagedType.LPUTF8Str)] string label, float* v, float v_speed, float v_min = float.MinValue, float v_max = float.MaxValue, [MarshalAs(UnmanagedType.LPUTF8Str)] string format = "%.3f", float power = 1);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("cimgui.dll", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl, EntryPoint = "igDragFloat3")]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern unsafe bool DragFloat3([MarshalAs(UnmanagedType.LPUTF8Str)] string label, float* v, float v_speed, float v_min = float.MinValue, float v_max = float.MaxValue, [MarshalAs(UnmanagedType.LPUTF8Str)] string format = "%.3f", float power = 1);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("cimgui.dll", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl, EntryPoint = "igDragFloat4")]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern unsafe bool DragFloat4([MarshalAs(UnmanagedType.LPUTF8Str)] string label, float* v, float v_speed, float v_min = float.MinValue, float v_max = float.MaxValue, [MarshalAs(UnmanagedType.LPUTF8Str)] string format = "%.3f", float power = 1);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("cimgui.dll", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl, EntryPoint = "igDragFloat2")]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern unsafe bool DragFloat2([MarshalAs(UnmanagedType.LPUTF8Str)] string label, Vector2* v, float v_speed, float v_min = float.MinValue, float v_max = float.MaxValue, [MarshalAs(UnmanagedType.LPUTF8Str)] string format = "%.3f", float power = 1);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("cimgui.dll", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl, EntryPoint = "igDragFloat3")]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern unsafe bool DragFloat3([MarshalAs(UnmanagedType.LPUTF8Str)] string label, Vector3* v, float v_speed, float v_min = float.MinValue, float v_max = float.MaxValue, [MarshalAs(UnmanagedType.LPUTF8Str)] string format = "%.3f", float power = 1);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("cimgui.dll", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl, EntryPoint = "igDragFloat4")]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern unsafe bool DragFloat4([MarshalAs(UnmanagedType.LPUTF8Str)] string label, Vector4* v, float v_speed, float v_min = float.MinValue, float v_max = float.MaxValue, [MarshalAs(UnmanagedType.LPUTF8Str)] string format = "%.3f", float power = 1);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("cimgui.dll", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl, EntryPoint = "igSliderFloat2")]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern bool SliderFloat2([MarshalAs(UnmanagedType.LPUTF8Str)] string label, float* v, float v_min = float.MinValue, float v_max = float.MaxValue, [MarshalAs(UnmanagedType.LPUTF8Str)] string format = "%.3f", float power = 1);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("cimgui.dll", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl, EntryPoint = "igSliderFloat3")]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern bool SliderFloat3([MarshalAs(UnmanagedType.LPUTF8Str)] string label, float* v, float v_min = float.MinValue, float v_max = float.MaxValue, [MarshalAs(UnmanagedType.LPUTF8Str)] string format = "%.3f", float power = 1);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("cimgui.dll", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl, EntryPoint = "igSliderFloat4")]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern bool SliderFloat4([MarshalAs(UnmanagedType.LPUTF8Str)] string label, float* v, float v_min = float.MinValue, float v_max = float.MaxValue, [MarshalAs(UnmanagedType.LPUTF8Str)] string format = "%.3f", float power = 1);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("cimgui.dll", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl, EntryPoint = "igSliderFloat2")]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern bool SliderFloat2([MarshalAs(UnmanagedType.LPUTF8Str)] string label, Vector2* v, float v_min = float.MinValue, float v_max = float.MaxValue, [MarshalAs(UnmanagedType.LPUTF8Str)] string format = "%.3f", float power = 1);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("cimgui.dll", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl, EntryPoint = "igSliderFloat3")]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern bool SliderFloat3([MarshalAs(UnmanagedType.LPUTF8Str)] string label, Vector3* v, float v_min = float.MinValue, float v_max = float.MaxValue, [MarshalAs(UnmanagedType.LPUTF8Str)] string format = "%.3f", float power = 1);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("cimgui.dll", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl, EntryPoint = "igSliderFloat4")]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern bool SliderFloat4([MarshalAs(UnmanagedType.LPUTF8Str)] string label, Vector4* v, float v_min = float.MinValue, float v_max = float.MaxValue, [MarshalAs(UnmanagedType.LPUTF8Str)] string format = "%.3f", float power = 1);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("cimgui.dll", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl, EntryPoint = "igInputFloat2")]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern bool InputFloat2([MarshalAs(UnmanagedType.LPUTF8Str)] string label, float* v, [MarshalAs(UnmanagedType.LPUTF8Str)] string format, int flags);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("cimgui.dll", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl, EntryPoint = "igInputFloat3")]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern bool InputFloat3([MarshalAs(UnmanagedType.LPUTF8Str)] string label, float* v, [MarshalAs(UnmanagedType.LPUTF8Str)] string format, int flags);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("cimgui.dll", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl, EntryPoint = "igInputFloat4")]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern bool InputFloat4([MarshalAs(UnmanagedType.LPUTF8Str)] string label, float* v, [MarshalAs(UnmanagedType.LPUTF8Str)] string format, int flags);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("cimgui.dll", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl, EntryPoint = "igInputFloat2")]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern bool InputFloat2([MarshalAs(UnmanagedType.LPUTF8Str)] string label, Vector2* v, [MarshalAs(UnmanagedType.LPUTF8Str)] string format, int flags);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("cimgui.dll", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl, EntryPoint = "igInputFloat3")]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern bool InputFloat3([MarshalAs(UnmanagedType.LPUTF8Str)] string label, Vector3* v, [MarshalAs(UnmanagedType.LPUTF8Str)] string format, int flags);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("cimgui.dll", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl, EntryPoint = "igInputFloat4")]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern bool InputFloat4([MarshalAs(UnmanagedType.LPUTF8Str)] string label, Vector4* v, [MarshalAs(UnmanagedType.LPUTF8Str)] string format, int flags);


            [SuppressUnmanagedCodeSecurity]
            [DllImport("cimgui.dll", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl, EntryPoint = "igColorEdit3")]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern bool ColorEdit3([MarshalAs(UnmanagedType.LPUTF8Str)] string label, float* col, int flags);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("cimgui.dll", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl, EntryPoint = "igColorEdit4")]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern bool ColorEdit4([MarshalAs(UnmanagedType.LPUTF8Str)] string label, float* col, int flags);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("cimgui.dll", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl, EntryPoint = "igColorPicker3")]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern bool ColorPicker3([MarshalAs(UnmanagedType.LPUTF8Str)] string label, float* col, int flags);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("cimgui.dll", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl, EntryPoint = "igColorPicker4")]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern bool ColorPicker4([MarshalAs(UnmanagedType.LPUTF8Str)] string label, float* col, int flags, float* ref_col);


            [SuppressUnmanagedCodeSecurity]
            [DllImport("cimgui.dll", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl, EntryPoint = "igColorEdit3")]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern bool ColorEdit3([MarshalAs(UnmanagedType.LPUTF8Str)] string label, Vector3* col, int flags);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("cimgui.dll", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl, EntryPoint = "igColorEdit4")]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern bool ColorEdit4([MarshalAs(UnmanagedType.LPUTF8Str)] string label, Vector4* col, int flags);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("cimgui.dll", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl, EntryPoint = "igColorPicker3")]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern bool ColorPicker3([MarshalAs(UnmanagedType.LPUTF8Str)] string label, Vector3* col, int flags);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("cimgui.dll", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl, EntryPoint = "igColorPicker4")]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern bool ColorPicker4([MarshalAs(UnmanagedType.LPUTF8Str)] string label, Vector4* col, int flags, float* ref_col);
            #endregion

        }
    }
}

#include "cimgui.h"
typedef struct ID3D11DeviceContext ID3D11DeviceContext;
typedef struct ID3D11Device ID3D11Device;
typedef struct IDirect3DDevice9 IDirect3DDevice9;


struct IDirect3DDevice9;

struct ID3D11Device;
struct ID3D11DeviceContext;
CIMGUI_API bool ImGui_ImplWin32_Init(void* hwnd);
CIMGUI_API void ImGui_ImplWin32_Shutdown();
CIMGUI_API void ImGui_ImplWin32_NewFrame();
CIMGUI_API bool ImGui_ImplDX9_Init(IDirect3DDevice9* device);
CIMGUI_API void ImGui_ImplDX9_Shutdown();
CIMGUI_API void ImGui_ImplDX9_NewFrame();
CIMGUI_API void ImGui_ImplDX9_RenderDrawData(ImDrawData* draw_data);
CIMGUI_API bool ImGui_ImplDX9_CreateDeviceObjects();
CIMGUI_API void ImGui_ImplDX9_InvalidateDeviceObjects();
CIMGUI_API bool ImGui_ImplDX11_Init(ID3D11Device* device,ID3D11DeviceContext* device_context);
CIMGUI_API void ImGui_ImplDX11_Shutdown();
CIMGUI_API void ImGui_ImplDX11_NewFrame();
CIMGUI_API void ImGui_ImplDX11_RenderDrawData(ImDrawData* draw_data);
CIMGUI_API void ImGui_ImplDX11_InvalidateDeviceObjects();
CIMGUI_API bool ImGui_ImplDX11_CreateDeviceObjects();

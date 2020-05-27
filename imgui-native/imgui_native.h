#pragma once
#define IMGUI_USER_CONFIG "../imuserconfig.h"
#include "imgui/imgui.h"
#include "windows.h"

IMGUI_IMPL_API LRESULT ImGui_ImplWin32_WndProcHandler(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam);
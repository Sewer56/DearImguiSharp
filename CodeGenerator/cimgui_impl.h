#include "extra.h"

#ifdef CIMGUI_USE_WIN32
CIMGUI_API bool ImGui_ImplWin32_Init(void* hwnd);
CIMGUI_API void ImGui_ImplWin32_Shutdown(void);
CIMGUI_API void ImGui_ImplWin32_NewFrame(void);
CIMGUI_API void ImGui_ImplWin32_EnableDpiAwareness(void);
CIMGUI_API float ImGui_ImplWin32_GetDpiScaleForHwnd(void* hwnd);
CIMGUI_API float ImGui_ImplWin32_GetDpiScaleForMonitor(void* monitor);
CIMGUI_API void ImGui_ImplWin32_EnableAlphaCompositing(void* hwnd);

#endif
#ifdef CIMGUI_USE_DX9

typedef struct IDirect3DDevice9 IDirect3DDevice9;
struct IDirect3DDevice9;CIMGUI_API bool ImGui_ImplDX9_Init(IDirect3DDevice9* device);
CIMGUI_API void ImGui_ImplDX9_Shutdown(void);
CIMGUI_API void ImGui_ImplDX9_NewFrame(void);
CIMGUI_API void ImGui_ImplDX9_RenderDrawData(ImDrawData* draw_data);
CIMGUI_API bool ImGui_ImplDX9_CreateDeviceObjects(void);
CIMGUI_API void ImGui_ImplDX9_InvalidateDeviceObjects(void);

#endif
#ifdef CIMGUI_USE_DX11

typedef struct ID3D11Device ID3D11Device;
typedef struct ID3D11DeviceContext ID3D11DeviceContext;
struct ID3D11Device;
struct ID3D11DeviceContext;CIMGUI_API bool ImGui_ImplDX11_Init(ID3D11Device* device,ID3D11DeviceContext* device_context);
CIMGUI_API void ImGui_ImplDX11_Shutdown(void);
CIMGUI_API void ImGui_ImplDX11_NewFrame(void);
CIMGUI_API void ImGui_ImplDX11_RenderDrawData(ImDrawData* draw_data);
CIMGUI_API void ImGui_ImplDX11_InvalidateDeviceObjects(void);
CIMGUI_API bool ImGui_ImplDX11_CreateDeviceObjects(void);

#endif
#ifdef CIMGUI_USE_DX12

typedef struct ID3D12Device ID3D12Device;
typedef struct ID3D12DescriptorHeap ID3D12DescriptorHeap;
typedef struct ID3D12GraphicsCommandList ID3D12GraphicsCommandList;
typedef struct D3D12_CPU_DESCRIPTOR_HANDLE D3D12_CPU_DESCRIPTOR_HANDLE;
typedef struct D3D12_GPU_DESCRIPTOR_HANDLE D3D12_GPU_DESCRIPTOR_HANDLE;
struct ID3D12Device;
struct ID3D12DescriptorHeap;
struct ID3D12GraphicsCommandList;
struct D3D12_CPU_DESCRIPTOR_HANDLE;
struct D3D12_GPU_DESCRIPTOR_HANDLE;CIMGUI_API bool ImGui_ImplDX12_Init(ID3D12Device* device,int num_frames_in_flight,DXGI_FORMAT rtv_format,ID3D12DescriptorHeap* cbv_srv_heap,D3D12_CPU_DESCRIPTOR_HANDLE font_srv_cpu_desc_handle,D3D12_GPU_DESCRIPTOR_HANDLE font_srv_gpu_desc_handle);
CIMGUI_API void ImGui_ImplDX12_Shutdown(void);
CIMGUI_API void ImGui_ImplDX12_NewFrame(void);
CIMGUI_API void ImGui_ImplDX12_RenderDrawData(ImDrawData* draw_data,ID3D12GraphicsCommandList* graphics_command_list);
CIMGUI_API void ImGui_ImplDX12_InvalidateDeviceObjects(void);
CIMGUI_API bool ImGui_ImplDX12_CreateDeviceObjects(void);

#endif
#ifdef CIMGUI_USE_VULKAN

typedef struct ImGui_ImplVulkanH_Frame ImGui_ImplVulkanH_Frame;
typedef struct ImGui_ImplVulkanH_Window ImGui_ImplVulkanH_Window;
typedef struct ImGui_ImplVulkan_InitInfo ImGui_ImplVulkan_InitInfo;
struct ImGui_ImplVulkan_InitInfo
{
    VkInstance Instance;
    VkPhysicalDevice PhysicalDevice;
    VkDevice Device;
    uint32_t QueueFamily;
    VkQueue Queue;
    VkPipelineCache PipelineCache;
    VkDescriptorPool DescriptorPool;
    uint32_t Subpass;
    uint32_t MinImageCount;
    uint32_t ImageCount;
    VkSampleCountFlagBits MSAASamples;
    const VkAllocationCallbacks* Allocator;
    void (*CheckVkResultFn)(VkResult err);
};
struct ImGui_ImplVulkanH_Frame;
struct ImGui_ImplVulkanH_Window;
struct ImGui_ImplVulkanH_Frame
{
    VkCommandPool CommandPool;
    VkCommandBuffer CommandBuffer;
    VkFence Fence;
    VkImage Backbuffer;
    VkImageView BackbufferView;
    VkFramebuffer Framebuffer;
};
typedef struct ImGui_ImplVulkanH_FrameSemaphores ImGui_ImplVulkanH_FrameSemaphores;
struct ImGui_ImplVulkanH_FrameSemaphores
{
    VkSemaphore ImageAcquiredSemaphore;
    VkSemaphore RenderCompleteSemaphore;
};
struct ImGui_ImplVulkanH_Window
{
    int Width;
    int Height;
    VkSwapchainKHR Swapchain;
    VkSurfaceKHR Surface;
    VkSurfaceFormatKHR SurfaceFormat;
    VkPresentModeKHR PresentMode;
    VkRenderPass RenderPass;
    VkPipeline Pipeline;
    bool ClearEnable;
    VkClearValue ClearValue;
    uint32_t FrameIndex;
    uint32_t ImageCount;
    uint32_t SemaphoreIndex;
    ImGui_ImplVulkanH_Frame* Frames;
    ImGui_ImplVulkanH_FrameSemaphores* FrameSemaphores;
};CIMGUI_API bool ImGui_ImplVulkan_Init(ImGui_ImplVulkan_InitInfo* info,VkRenderPass render_pass);
CIMGUI_API void ImGui_ImplVulkan_Shutdown(void);
CIMGUI_API void ImGui_ImplVulkan_NewFrame(void);
CIMGUI_API void ImGui_ImplVulkan_RenderDrawData(ImDrawData* draw_data,VkCommandBuffer command_buffer,VkPipeline pipeline);
CIMGUI_API bool ImGui_ImplVulkan_CreateFontsTexture(VkCommandBuffer command_buffer);
CIMGUI_API void ImGui_ImplVulkan_DestroyFontUploadObjects(void);
CIMGUI_API void ImGui_ImplVulkan_SetMinImageCount(uint32_t min_image_count);
CIMGUI_API VkDescriptorSet ImGui_ImplVulkan_AddTexture(VkSampler sampler,VkImageView image_view,VkImageLayout image_layout);
CIMGUI_API void ImGui_ImplVulkan_RemoveTexture(VkDescriptorSet descriptor_set);
CIMGUI_API bool ImGui_ImplVulkan_LoadFunctions(PFN_vkVoidFunction(*loader_func)(const char* function_name,void* user_data),void* user_data);
CIMGUI_API void ImGui_ImplVulkanH_CreateOrResizeWindow(VkInstance instance,VkPhysicalDevice physical_device,VkDevice device,ImGui_ImplVulkanH_Window* wnd,uint32_t queue_family,const VkAllocationCallbacks* allocator,int w,int h,uint32_t min_image_count);
CIMGUI_API void ImGui_ImplVulkanH_DestroyWindow(VkInstance instance,VkDevice device,ImGui_ImplVulkanH_Window* wnd,const VkAllocationCallbacks* allocator);
CIMGUI_API VkSurfaceFormatKHR ImGui_ImplVulkanH_SelectSurfaceFormat(VkPhysicalDevice physical_device,VkSurfaceKHR surface,const VkFormat* request_formats,int request_formats_count,VkColorSpaceKHR request_color_space);
CIMGUI_API VkPresentModeKHR ImGui_ImplVulkanH_SelectPresentMode(VkPhysicalDevice physical_device,VkSurfaceKHR surface,const VkPresentModeKHR* request_modes,int request_modes_count);
CIMGUI_API int ImGui_ImplVulkanH_GetMinImageCountFromPresentMode(VkPresentModeKHR present_mode);

#endif
#ifdef CIMGUI_USE_GLFW

typedef struct GLFWwindow GLFWwindow;
typedef struct GLFWmonitor GLFWmonitor;
struct GLFWwindow;
struct GLFWmonitor;CIMGUI_API bool ImGui_ImplGlfw_InitForOpenGL(GLFWwindow* window,bool install_callbacks);
CIMGUI_API bool ImGui_ImplGlfw_InitForVulkan(GLFWwindow* window,bool install_callbacks);
CIMGUI_API bool ImGui_ImplGlfw_InitForOther(GLFWwindow* window,bool install_callbacks);
CIMGUI_API void ImGui_ImplGlfw_Shutdown(void);
CIMGUI_API void ImGui_ImplGlfw_NewFrame(void);
CIMGUI_API void ImGui_ImplGlfw_InstallCallbacks(GLFWwindow* window);
CIMGUI_API void ImGui_ImplGlfw_RestoreCallbacks(GLFWwindow* window);
CIMGUI_API void ImGui_ImplGlfw_SetCallbacksChainForAllWindows(bool chain_for_all_windows);
CIMGUI_API void ImGui_ImplGlfw_WindowFocusCallback(GLFWwindow* window,int focused);
CIMGUI_API void ImGui_ImplGlfw_CursorEnterCallback(GLFWwindow* window,int entered);
CIMGUI_API void ImGui_ImplGlfw_CursorPosCallback(GLFWwindow* window,double x,double y);
CIMGUI_API void ImGui_ImplGlfw_MouseButtonCallback(GLFWwindow* window,int button,int action,int mods);
CIMGUI_API void ImGui_ImplGlfw_ScrollCallback(GLFWwindow* window,double xoffset,double yoffset);
CIMGUI_API void ImGui_ImplGlfw_KeyCallback(GLFWwindow* window,int key,int scancode,int action,int mods);
CIMGUI_API void ImGui_ImplGlfw_CharCallback(GLFWwindow* window,unsigned int c);
CIMGUI_API void ImGui_ImplGlfw_MonitorCallback(GLFWmonitor* monitor,int event);

#endif
#ifdef CIMGUI_USE_OPENGL3
CIMGUI_API bool ImGui_ImplOpenGL3_Init(const char* glsl_version);
CIMGUI_API void ImGui_ImplOpenGL3_Shutdown(void);
CIMGUI_API void ImGui_ImplOpenGL3_NewFrame(void);
CIMGUI_API void ImGui_ImplOpenGL3_RenderDrawData(ImDrawData* draw_data);
CIMGUI_API bool ImGui_ImplOpenGL3_CreateFontsTexture(void);
CIMGUI_API void ImGui_ImplOpenGL3_DestroyFontsTexture(void);
CIMGUI_API bool ImGui_ImplOpenGL3_CreateDeviceObjects(void);
CIMGUI_API void ImGui_ImplOpenGL3_DestroyDeviceObjects(void);

#endif
#ifdef CIMGUI_USE_OPENGL2
CIMGUI_API bool ImGui_ImplOpenGL2_Init(void);
CIMGUI_API void ImGui_ImplOpenGL2_Shutdown(void);
CIMGUI_API void ImGui_ImplOpenGL2_NewFrame(void);
CIMGUI_API void ImGui_ImplOpenGL2_RenderDrawData(ImDrawData* draw_data);
CIMGUI_API bool ImGui_ImplOpenGL2_CreateFontsTexture(void);
CIMGUI_API void ImGui_ImplOpenGL2_DestroyFontsTexture(void);
CIMGUI_API bool ImGui_ImplOpenGL2_CreateDeviceObjects(void);
CIMGUI_API void ImGui_ImplOpenGL2_DestroyDeviceObjects(void);

#endif
#ifdef CIMGUI_USE_SDL2

typedef struct SDL_Window SDL_Window;
typedef struct SDL_Renderer SDL_Renderer;
struct SDL_Window;
struct SDL_Renderer;
typedef union SDL_Event SDL_Event;CIMGUI_API bool ImGui_ImplSDL2_InitForOpenGL(SDL_Window* window,void* sdl_gl_context);
CIMGUI_API bool ImGui_ImplSDL2_InitForVulkan(SDL_Window* window);
CIMGUI_API bool ImGui_ImplSDL2_InitForD3D(SDL_Window* window);
CIMGUI_API bool ImGui_ImplSDL2_InitForMetal(SDL_Window* window);
CIMGUI_API bool ImGui_ImplSDL2_InitForSDLRenderer(SDL_Window* window,SDL_Renderer* renderer);
CIMGUI_API void ImGui_ImplSDL2_Shutdown(void);
CIMGUI_API void ImGui_ImplSDL2_NewFrame(void);
CIMGUI_API bool ImGui_ImplSDL2_ProcessEvent(const SDL_Event* event);

#endif

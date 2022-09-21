using CppSharp.AST;
using CppSharp.Generators;
using CppSharp.Types;

namespace CodeGenerator.TypeMaps
{
    [TypeMap("D3D12_CPU_DESCRIPTOR_HANDLE", GeneratorKind = GeneratorKind.CSharp)]
    public class CpuDescriptorHandleTypeMap : TypeMap
    {
        public override CppSharp.AST.Type CSharpSignatureType(TypePrinterContext ctx)
        {
            return new CustomType("IntPtr");
        }
    }
    
    [TypeMap("D3D12_GPU_DESCRIPTOR_HANDLE", GeneratorKind = GeneratorKind.CSharp)]
    public class GpuDescriptorHandleTypeMap : TypeMap
    {
        public override CppSharp.AST.Type CSharpSignatureType(TypePrinterContext ctx)
        {
            return new CustomType("long");
        }
    }
}
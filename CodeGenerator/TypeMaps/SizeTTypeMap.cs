using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CppSharp.AST;
using CppSharp.Generators;
using CppSharp.Types;
using Type = System.Type;

namespace CodeGenerator.TypeMaps
{
    [TypeMap("size_t", GeneratorKind = GeneratorKind.CSharp)]
    public class SizeTTypeMap : TypeMap
    {
        public override CppSharp.AST.Type CSharpSignatureType(TypePrinterContext ctx)
        {
            return new CustomType("IntPtr");
        }
    }
}

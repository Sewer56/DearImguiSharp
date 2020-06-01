using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CppSharp;
using CppSharp.Generators;
using CppSharp.Passes;

namespace CodeGenerator.Passes
{
    public class SetComponentsPublicPass : GeneratorOutputPass
    {
        public override void VisitGeneratorOutput(GeneratorOutput output)
        {
            var blocks = output.Outputs.SelectMany(i => i.FindBlocks(BlockKind.Unknown));
            foreach (var namespaceBlock in blocks)
            {
                if (namespaceBlock.Parent.Kind == BlockKind.Class)
                {
                    foreach (var classBlock in namespaceBlock.Parent.Blocks)
                    {
                        ProcessClassBlock(classBlock);
                    }
                }
                else if (namespaceBlock.Parent.Kind == BlockKind.InternalsClass)
                {
                    foreach (var classBlock in namespaceBlock.Parent.Blocks)
                    {
                        ProcessClassBlock(classBlock.Parent);
                    }
                }
            }
        }

        private static void ProcessClassBlock(Block block)
        {
            switch (block.Kind)
            {
                case BlockKind.Method:
                    ProcessClassMethodBlock(block);
                    break;
                case BlockKind.InternalsClass:
                    ProcessInternalsClassBlock(block);
                    break;
            }
        }

        private static void ProcessClassMethodBlock(Block block)
        {
            var text = block.Text.StringBuilder.ToString();
            if (text.Contains("bool skipVTables"))
            {
                block.Text.StringBuilder.Replace("protected", "public");
            }
        }

        private static void ProcessInternalsClassBlock(Block block)
        {
            foreach (var field in block.Blocks)
            {
                if (field.Kind != BlockKind.Field && field.Kind != BlockKind.InternalsClassMethod) 
                    continue;

                field.Text.StringBuilder.Replace("internal", "public");
            }
        }
    }
}

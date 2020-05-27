using System;
using CppSharp;
using CppSharp.AST;
using System.Collections.Generic;
using System.Linq;
using CppSharp.Generators;
using CppSharp.Passes;

namespace CodeGenerator
{
    public class CodeGen : ILibrary
    {
        public void Setup(Driver driver)
        {
            const string libraryName = "cimgui.dll";
            string[] imguiDirectories = new[]
            {
                "./",
            };

            var options = driver.Options;
            options.GeneratorKind = GeneratorKind.CSharp;

            var module = options.AddModule(libraryName);
            module.OutputNamespace = "ImGui";
            module.Defines.Add("CIMGUI_DEFINE_ENUMS_AND_STRUCTS");
            foreach (var directory in imguiDirectories)
                module.IncludeDirs.Add(directory);

            module.Headers.Add("cimgui.h");
            module.Headers.Add("cimgui_impl.h");
        }

        public void SetupPasses(Driver driver)
        {
            driver.Context.TranslationUnitPasses.RenameDeclsUpperCase(RenameTargets.Any);
            driver.Context.TranslationUnitPasses.AddPass(new FunctionToInstanceMethodPass());
            driver.Context.TranslationUnitPasses.AddPass(new CheckDuplicatedNamesPass());
        }

        public void Postprocess(Driver driver, ASTContext ctx)
        {

        }

        public void Preprocess(Driver driver, ASTContext ctx)
        {
            foreach (var decl in ctx.FindDecl<Declaration>("GImGui"))
                decl.Ignore = true;
            
            RemovePrefix(ctx);
        }

        private void RemovePrefix(ASTContext ctx)
        {
            foreach (var unit in ctx.TranslationUnits)
            {
                foreach (Declaration decl in unit.Declarations)
                {
                    if (decl.GetType().Name == "Function")
                    {
                        decl.Name = GetNameWithoutPrefix(decl.Name);
                    }
                }

                RecursiveRemovePrefix(unit.Namespaces, ctx);
            }
        }

        private void RecursiveRemovePrefix(IEnumerable<Namespace> namespaces, ASTContext ctx)
        {
            foreach (var ns in namespaces)
            {
                RecursiveRemovePrefix(ns.Namespaces, ctx);
                foreach (var cls in ns.Classes)
                {
                    cls.Name = GetNameWithoutPrefix(cls.Name);
                }
            }
        }

        private string GetNameWithoutPrefix(string name) => name.TrimStart("ig".ToCharArray());
    }
}

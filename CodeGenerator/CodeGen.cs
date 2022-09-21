﻿using System;
using CppSharp;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CodeGenerator.Passes;
using CppSharp.AST;
using CppSharp.Generators;
using CppSharp.Parser;
using CppSharp.Passes;
using ASTContext = CppSharp.AST.ASTContext;
using Declaration = CppSharp.AST.Declaration;
using Namespace = CppSharp.AST.Namespace;

namespace CodeGenerator
{
    public class CodeGen : ILibrary
    {
        public void Setup(Driver driver)
        {
            const string libraryName = "cimgui";
            string[] imguiDirectories = new[]
            {
                Path.GetFullPath("."),
                Path.GetFullPath("include/vulkan"),
            };

            var options = driver.Options;
            options.GeneratorKind = GeneratorKind.CSharp;
            options.GenerateFinalizers = true;
            options.GenerateDefaultValuesForArguments = true;
            options.GenerateSequentialLayout = true;
            options.Verbose = true;

            var module = options.AddModule(libraryName);
            module.OutputNamespace = "DearImguiSharp";
            module.Defines.Add("CIMGUI_DEFINE_ENUMS_AND_STRUCTS");
            module.Defines.Add("CIMGUI_USE_WIN32");
            module.Defines.Add("CIMGUI_USE_DX9");
            module.Defines.Add("CIMGUI_USE_DX11");
            module.Defines.Add("CIMGUI_USE_DX12");
            module.Defines.Add("CIMGUI_USE_VULKAN");
            module.Defines.Add("CIMGUI_USE_GLFW");
            module.Defines.Add("CIMGUI_USE_OPENGL3");
            module.Defines.Add("CIMGUI_USE_OPENGL2");
            module.Defines.Add("CIMGUI_USE_SDL");
            module.Defines.Add("VK_USE_PLATFORM_WIN32_KHR");
            foreach (var directory in imguiDirectories)
                module.IncludeDirs.Add(directory);

            foreach (var vkHeader in Directory.GetFiles(Path.GetFullPath("include/vulkan"), "*.h"))
                module.Headers.Add(vkHeader);
            
            foreach (var vkHeader in Directory.GetFiles(Path.GetFullPath("include/vulkan"), "*.hpp"))
                module.Headers.Add(vkHeader);

            module.Headers.Add("cimgui.h");
            module.Headers.Add("cimgui_impl.h");
        }

        public void SetupPasses(Driver driver)
        {
            driver.Context.TranslationUnitPasses.RenameDeclsUpperCase(RenameTargets.Property);
            driver.Context.TranslationUnitPasses.RenameDeclsUpperCase(RenameTargets.Class);
            driver.Context.TranslationUnitPasses.AddPass(new FunctionToInstanceMethodPass());
            driver.Context.TranslationUnitPasses.AddPass(new CheckDuplicatedNamesPass());
            driver.Context.TranslationUnitPasses.AddPass(new CheckFlagEnumsPass());
            driver.Context.TranslationUnitPasses.AddPass(new FixDefaultParamValuesOfOverridesPass());
            driver.Context.TranslationUnitPasses.AddPass(new HandleDefaultParamValuesPass());
            driver.Context.TranslationUnitPasses.AddPass(new MakeProtectedNestedTypesPublicPass());
            driver.Context.TranslationUnitPasses.AddPass(new SpecializationMethodsWithDependentPointersPass());
            driver.Context.TranslationUnitPasses.AddPass(new ConstructorToConversionOperatorPass());
            driver.Context.GeneratorOutputPasses.AddPass(new RenameOutputPass());
            driver.Context.GeneratorOutputPasses.AddPass(new SetComponentsPublicPass());
            driver.Context.GeneratorOutputPasses.AddPass(new RemoveEnumValuesPrefixPass());
        }

        public void Preprocess(Driver driver, ASTContext ctx)
        {
            foreach (var decl in ctx.FindDecl<Declaration>("GImGui"))
                decl.Ignore = true;

            // Fix incorrect indirect value passes.
            foreach (var parameter in from translationUnit in ctx.TranslationUnits 
                                      from function in translationUnit.Functions 
                                      from parameter in function.Parameters 
                                      where parameter.DebugText.Contains("const ImVec4") 
                                      select parameter)
            {
                parameter.IsIndirect = false;
            }

            // Remove Prefixes
            RemovePrefix(ctx);
        }

        public void Postprocess(Driver driver, ASTContext ctx)
        {
            // ImVectorImTextureID has a pointer type typedef'd to void*
            // This causes the type to expand to void**, but C# sets the field as IntPtr.
            // C# has no implicit cast for this.
            // We implement this property ourselves in the other project :3
            
            IgnoreProperty("ImVectorImTextureID", "Data", ctx);
            IgnoreProperty("ImVector_const_charPtr", "Data", ctx);
        }

        private void RemovePrefix(ASTContext ctx)
        {
            foreach (var unit in ctx.TranslationUnits)
            {
                foreach (var func in unit.Functions)
                {
                    func.Name = GetNameWithoutPrefix(func.Name);
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
        private void IgnoreProperty(string className, string propertyName, ASTContext ctx)
        {
            var cls = ctx.FindCompleteClass(className);

            var dataProperty = cls?.Properties.FirstOrDefault(x => x.OriginalName != null && x.OriginalName == propertyName);
            if (dataProperty != null)
                dataProperty.Ignore = true;
        }

        public void GenerateCode(Driver driver, List<GeneratorOutput> outputs)
        {
            
        }
    }
}

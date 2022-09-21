using System.Linq;
using System.Text.RegularExpressions;
using CppSharp;
using CppSharp.Generators;
using CppSharp.Passes;
using Humanizer;

// Forked from: https://github.com/MarioGK/ImGuiSharp
namespace CodeGenerator.Passes
{
    public class RemoveEnumValuesPrefixPass : GeneratorOutputPass
    {
        public static readonly Regex Tokenize = new(@"\w+");
        
        public override void VisitGeneratorOutput(GeneratorOutput output)
        {
            var enums = output.Outputs.SelectMany(i => i.FindBlocks(BlockKind.Enum));
            foreach (var enumeration in enums)
            {
                var tokens   = Tokenize.Matches(enumeration.Text.ToString()).Select(x => x.Value);
                var enumName = "";

                foreach (var token in tokens)
                {
                    // Find the Enum's name
                    if (string.IsNullOrEmpty(enumName) && token.StartsWith("ImGui"))
                    {
                        enumName = token;
                        continue;
                    }

                    // Remove the Enum's name from the value prefix
                    if (string.IsNullOrEmpty(enumName) || !token.StartsWith(enumName)) 
                        continue;
                    
                    var newValue = token.Replace(enumName, "");
                    if (int.TryParse(newValue, out var number))
                        newValue = number.ToWords().Humanize(LetterCasing.Title);

                    enumeration.Text.StringBuilder.Replace(token, newValue);
                }
            }
        }
    }
}
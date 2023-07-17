using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using StyleCop.Analyzers;
using StyleCop.Analyzers.RuleHelpers;

namespace CustomRules
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class Rules
    {
        // Custom rule 1
        private const string CustomRule1Id = "CustomRule001";
        private const string CustomRule1Title = "Use explicit type instead of 'var'";
        private const string CustomRule1MessageFormat = "Use explicit type instead of 'var' for variable '{0}'";
        private const string CustomRule1Category = "Style";

        public static readonly DiagnosticDescriptor CustomRule1 = new DiagnosticDescriptor(
            CustomRule1Id,
            CustomRule1Title,
            CustomRule1MessageFormat,
            CustomRule1Category,
            DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: "Use explicit type instead of 'var'");

        // Custom rule 2
        private const string CustomRule2Id = "CustomRule002";
        private const string CustomRule2Title = "Method name should start with uppercase";
        private const string CustomRule2MessageFormat = "Method name '{0}' should start with uppercase";
        private const string CustomRule2Category = "Style";

        public static readonly DiagnosticDescriptor CustomRule2 = new DiagnosticDescriptor(
            CustomRule2Id,
            CustomRule2Title,
            CustomRule2MessageFormat,
            CustomRule2Category,
            DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: "Method name should start with uppercase");

        // Custom rule 1 analyzer
        public static void AnalyzeVariableDeclaration(SyntaxNodeAnalysisContext context)
        {
            var variableDeclaration = (VariableDeclarationSyntax)context.Node;
            var type = variableDeclaration.Type;

            if (type.IsVar)
            {
                context.ReportDiagnostic(Diagnostic.Create(CustomRule1, type.GetLocation(), variableDeclaration.Variables.First().Identifier.Text));
            }
        }

        // Custom rule 2 analyzer
        public static void AnalyzeMethodDeclaration(SyntaxNodeAnalysisContext context)
        {
            var methodDeclaration = (MethodDeclarationSyntax)context.Node;
            var methodName = methodDeclaration.Identifier.Text;

            if (char.IsLower(methodName[0]))
            {
                context.ReportDiagnostic(Diagnostic.Create(CustomRule2, methodDeclaration.Identifier.GetLocation(), methodName));
            }
        }
    }
}

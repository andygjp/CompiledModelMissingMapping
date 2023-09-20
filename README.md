# README

Update all packages and tooling to RC1:

```shell
dotnet add package --prerelease Microsoft.EntityFrameworkCore.Sqlite
dotnet add package --prerelease Microsoft.EntityFrameworkCore.Design
dotnet tool update --prerelease dotnet-ef
```

> 💡 I've already done it for you.

And then generate the compiled model: `dotnet ef dbcontext optimize`

And you will get the following error:

```text
Build started...
Build succeeded.
System.InvalidOperationException: The type mapping used is incompatible with a compiled model. The mapping type must have a 'public static readonly SqliteStringTypeMapping SqliteStringTypeMapping.Default' property.
   at Microsoft.EntityFrameworkCore.Design.Internal.CSharpRuntimeAnnotationCodeGenerator.CreateDefaultTypeMapping(CoreTypeMapping typeMapping, CSharpRuntimeAnnotationCodeGeneratorParameters parameters)
   at Microsoft.EntityFrameworkCore.Design.Internal.RelationalCSharpRuntimeAnnotationCodeGenerator.Create(CoreTypeMapping typeMapping, CSharpRuntimeAnnotationCodeGeneratorParameters parameters, ValueComparer valueComparer, ValueComparer keyValueComparer, ValueComparer providerValueComparer)
   at Microsoft.EntityFrameworkCore.Design.Internal.ICSharpRuntimeAnnotationCodeGenerator.Create(CoreTypeMapping typeMapping, IProperty property, CSharpRuntimeAnnotationCodeGeneratorParameters parameters)
   at Microsoft.EntityFrameworkCore.Scaffolding.Internal.CSharpRuntimeModelCodeGenerator.Create(IProperty property, String variableName, Dictionary`2 propertyVariables, CSharpRuntimeAnnotationCodeGeneratorParameters parameters)
   at Microsoft.EntityFrameworkCore.Scaffolding.Internal.CSharpRuntimeModelCodeGenerator.Create(IProperty property, Dictionary`2 propertyVariables, CSharpRuntimeAnnotationCodeGeneratorParameters parameters)
   at Microsoft.EntityFrameworkCore.Scaffolding.Internal.CSharpRuntimeModelCodeGenerator.CreateEntityType(IEntityType entityType, IndentedStringBuilder mainBuilder, IndentedStringBuilder methodBuilder, SortedSet`1 namespaces, String className, Boolean nullable)
   at Microsoft.EntityFrameworkCore.Scaffolding.Internal.CSharpRuntimeModelCodeGenerator.GenerateEntityType(IEntityType entityType, String namespace, String className, Boolean nullable)
   at Microsoft.EntityFrameworkCore.Scaffolding.Internal.CSharpRuntimeModelCodeGenerator.GenerateModel(IModel model, CompiledModelCodeGenerationOptions options)
   at Microsoft.EntityFrameworkCore.Scaffolding.Internal.CompiledModelScaffolder.ScaffoldModel(IModel model, String outputDir, CompiledModelCodeGenerationOptions options)
   at Microsoft.EntityFrameworkCore.Design.Internal.DbContextOperations.Optimize(String outputDir, String modelNamespace, String contextTypeName)
   at Microsoft.EntityFrameworkCore.Design.OperationExecutor.OptimizeContextImpl(String outputDir, String modelNamespace, String contextType)
   at Microsoft.EntityFrameworkCore.Design.OperationExecutor.OptimizeContext.<>c__DisplayClass0_0.<.ctor>b__0()
   at Microsoft.EntityFrameworkCore.Design.OperationExecutor.OperationBase.Execute(Action action)
The type mapping used is incompatible with a compiled model. The mapping type must have a 'public static readonly SqliteStringTypeMapping SqliteStringTypeMapping.Default' property.
```

I get the same error even if I use the v7.0.11 of the ef tooling.
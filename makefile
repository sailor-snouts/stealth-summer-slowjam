lint: lint-runtime lint-editor lint-runtime-test lint-editor-test

lint-runtime:
	dotnet format '.\Scripts.Runtime.csproj' --no-restore
    
lint-editor:
	dotnet format '.\Scripts.Editor.csproj' --no-restore

lint-runtime-test:
	dotnet format '.\Tests.Runtime.csproj' --no-restore
    
lint-editor-test:
	dotnet format '.\Tests.Editor.csproj' --no-restore
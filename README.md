# Cake.Tools.ReadyAPI.TestEngine

A Cake AddIn that extends Cake with the [SmartBear ReadyAPI TestEngine](https://support.smartbear.com/readyapi/docs/testengine/admin/cli.html) command line tool.

![Build](https://github.com/waxtell/Cake.Tools.ReadyAPI.TestEngine/workflows/Build/badge.svg)

## Including addin
First, add the extension in the usual way:
```c#
#addin "Cake.Tools.ReadyAPI.TestEngine"
```
## Usage

```csharp
#addin "Cake.Tools.ReadyAPI.TestEngine"

...

Task("FunctionalTest")
    .Does
    (
        () =>
        {
            var result = RunProject
            (
                "demo-readyapi-project.xml",
                new TestEngineSettings()
                {
                    TimeoutSeconds = 120,
                    ...
                    Environment = "dev"
                }
            );

            if(result != 0)
            {
                throw new Exception("One or more tests failed!");
            }
        }
    );
```
The extension expects TestEngine.cmd to be available in the system path, but you may explicitly set the tool location as such

```csharp
Setup(context => {
    context.Tools.RegisterFile("C:/Users/yourusername/AppData/Roaming/npm/testengine.cmd");
});
```

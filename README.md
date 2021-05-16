# PathArgumentDemo

Reproducer for weird path behaviour when using completion on Windows. Essentially when PowerShell tab completes a path with spaces in it, the resulting string escapes its own path separator, breaking Spectre's argument parsing.

To see it in action, `cd` to the `src/PathArgumentDemo` directory and run the following:

```powershell
dotnet run -- .\bin\ sample
# you should see the correct behaviour
dotnet run -- "./path with spaces" sample
# again, correct behaviour
```

However, if you use tab completion:

```powershell
# use <TAB> to complete the "path with spaces" directory and you'll get an input that looks like this:
dotnet run -- '.\path with spaces\' sample
# that will break the parsing and result in the whole command being passed as the first argument with an (escaped) '"' character
```
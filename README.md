# Narwhal

## Project Structure

This repo contains two projects:

* `Narwhal`, which contains the classes that do the heavy lifting, and compiles to a console app that we can use to implement them
* `Narwhal.Test`, a unit testing project that tests the library code from the console app

## Setup

First step is to [download .NET 7](https://dotnet.microsoft.com/en-us/download).  From there, the [C# extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) for VSCode is highly recommended.

## Building and Running

To run the acutal console app defined in `Program.cs`, cd to the Narwhal project directory and:

```
dotnet run
```

You may need to run `dotnet build` first if your latest changes aren't being reflected

## Unit Testing

To run the test suite, cd into the `Narwhal.Test` project directory and run:

```
dotnet test
```

Again, if latest changes aren't being reflected, first `dotnet build` the Narwhal project, then `dotnet test` the test project.
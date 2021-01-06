﻿using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace FileCurator.Tests.BaseClasses
{
    [Collection("DirectoryCollection")]
    public class TestingDirectoryFixture : IDisposable
    {
        public TestingDirectoryFixture()
        {
            if (Canister.Builder.Bootstrapper == null)
            {
                new ServiceCollection().AddCanisterModules(configure => configure.RegisterFileCurator()
                .AddAssembly(typeof(TestingDirectoryFixture).Assembly));
            }

            new DirectoryInfo(@".\Testing").Create();
            new DirectoryInfo(@".\App_Data").Create();
            new DirectoryInfo(@".\Logs").Create();
            new DirectoryInfo("./Results").Create();
        }

        public void Dispose()
        {
            new DirectoryInfo(@".\Testing").Delete();
            new DirectoryInfo(@".\App_Data").Delete();
            new DirectoryInfo(@".\Logs").Delete();
            new DirectoryInfo("./Results").Delete();
        }
    }
}
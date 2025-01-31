﻿// Copyright (c) 2017-2018, 2020-2021 Ubisoft Entertainment
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
using System.Collections.Generic;

namespace Sharpmake
{
    public enum CompilerFamily
    {
        Auto, // Auto detect compiler based on executable path
        MSVC, // Microsoft and compatible compilers
        Clang, // Clang and compatible compilers
        GCC, // GCC and compatible compilers
        SNC, // SNC and compatible compilers
        CodeWarriorWii, // CodeWarrior compiler for the Wii
        GreenHillsWiiU, // GreenHills compiler for the Wii U
        CudaNVCC, // NVIDIA's CUDA compiler
        QtRCC, // Qt's resource compiler
        VBCC, // vbcc compiler
        OrbisWavePsslc, // orbis wave psslc shader compiler
        ClangCl, // Clang in MSVC cl-compatible mode
        CSharp, // C# compiler
        Custom, // Any custom compiler
    }

    public interface IFastBuildCompilerKey
    {
        DevEnv DevelopmentEnvironment { get; set; }
    }

    public class FastBuildCompilerKey : IFastBuildCompilerKey
    {
        public DevEnv DevelopmentEnvironment { get; set; }

        public FastBuildCompilerKey(DevEnv devEnv)
        {
            DevelopmentEnvironment = devEnv;
        }

        public override int GetHashCode()
        {
            return DevelopmentEnvironment.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return false;
            if (obj.GetType() != GetType())
                return false;

            return Equals((FastBuildCompilerKey)obj);
        }

        public bool Equals(FastBuildCompilerKey compilerFamilyKey)
        {
            return DevelopmentEnvironment.Equals(compilerFamilyKey.DevelopmentEnvironment);
        }
    }

    public interface IFastBuildCompilerSettings
    {
        IDictionary<DevEnv, string> BinPath { get; set; }
        IDictionary<IFastBuildCompilerKey, CompilerFamily> CompilerFamily { get; set; }
        IDictionary<DevEnv, string> LinkerPath { get; set; }
        IDictionary<DevEnv, string> LinkerExe { get; set; }
        IDictionary<DevEnv, string> LibrarianExe { get; set; }
        IDictionary<DevEnv, Strings> ExtraFiles { get; set; }
    }
}

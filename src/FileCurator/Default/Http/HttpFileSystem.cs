﻿/*
Copyright 2016 James Craig

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using FileCurator.BaseClasses;
using FileCurator.Interfaces;

namespace FileCurator.Default
{
    /// <summary>
    /// HTTP file system
    /// </summary>
    public class HttpFileSystem : FileSystemBase
    {
        /// <summary>
        /// Name of the file system
        /// </summary>
        public override string Name { get; } = "HTTP";

        /// <summary>
        /// Gets the order (lower numbers occur first).
        /// </summary>
        /// <value>The order.</value>
        public override int Order { get; } = int.MaxValue;

        /// <summary>
        /// Relative starter
        /// </summary>
        protected override string HandleRegexString { get; } = @"^https?://|^www\.";

        /// <summary>
        /// Gets the directory representation for the directory
        /// </summary>
        /// <param name="path">Path to the directory</param>
        /// <param name="credentials">The credentials.</param>
        /// <returns>The directory object</returns>
        public override IDirectory Directory(string path, Credentials credentials = null)
        {
            path = AbsolutePath(path);
            return new WebDirectory(path, credentials);
        }

        /// <summary>
        /// Used to dispose of any resources
        /// </summary>
        public override void Dispose()
        {
        }

        /// <summary>
        /// Gets the class representation for the file
        /// </summary>
        /// <param name="path">Path to the file</param>
        /// <param name="credentials">The credentials.</param>
        /// <returns>The file object</returns>
        public override IFile File(string path, Credentials credentials = null)
        {
            path = AbsolutePath(path);
            return new WebFile(path, credentials);
        }

        /// <summary>
        /// Gets the absolute path of the variable passed in
        /// </summary>
        /// <param name="path">Path to convert to absolute</param>
        /// <returns>The absolute path of the path passed in</returns>
        protected override string AbsolutePath(string path)
        {
            return path;
        }
    }
}
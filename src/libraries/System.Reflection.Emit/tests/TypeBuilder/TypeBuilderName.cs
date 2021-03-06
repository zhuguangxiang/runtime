// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Xunit;

namespace System.Reflection.Emit.Tests
{
    public class TypeBuilderName
    {
        [Theory]
        [InlineData("TestType", "TestType")]
        [InlineData("Namespace.TestType", "TestType")]
        [InlineData("Namespace1.Namespace2.TestType", "TestType")]
        public void Name(string typeName, string expectedName)
        {
            TypeBuilder nonGenericType = Helpers.DynamicType(TypeAttributes.Class | TypeAttributes.Public, typeName: typeName);
            Assert.Equal(expectedName, nonGenericType.Name);

            nonGenericType.DefineGenericParameters("T", "U");
            Assert.Equal(expectedName, nonGenericType.Name);
        }
    }
}

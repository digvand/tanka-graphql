﻿
using Tanka.GraphQL.Language.Nodes;
using Tanka.GraphQL.TypeSystem;
using Tanka.GraphQL.TypeSystem.ValueSerialization;
using Xunit;

namespace Tanka.GraphQL.Tests.TypeSystem
{
    public class StringTypeFacts
    {
        private readonly IValueConverter _sut;

        public StringTypeFacts()
        {
            _sut = new StringConverter();
        }

        [Theory]
        [InlineData("string", "string")]
        [InlineData(true, "True")]
        [InlineData(123, "123")]
        [InlineData(123.123, "123.123")]
        public void ParseValue(object input, string expected)
        {
            /* Given */
            /* When */
            var actual = _sut.ParseValue(input);

            /* Then */
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("string", "string")]
        [InlineData("true", "true")]
        [InlineData("123", "123")]
        [InlineData("123.123", "123.123")]
        public void ParseLiteral(string input, string expected)
        {
            /* Given */
            StringValue astValue = input;

            /* When */
            var actual = _sut.ParseLiteral(astValue);

            /* Then */
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("string", "string")]
        [InlineData(true, "True")]
        [InlineData(123, "123")]
        [InlineData(123.123, "123.123")]
        public void Serialize(object input, string expected)
        {
            /* Given */
            /* When */
            var actual = _sut.Serialize(input);

            /* Then */
            Assert.Equal(expected, actual);
        }
    }
}
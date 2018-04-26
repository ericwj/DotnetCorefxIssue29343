using System;
using System.Globalization;
using Xunit;

namespace Int32TryParse.Tests
{
    public class TestSpan
    {
        [Fact]
        public void Int32TryParse()
        {
            var hex = NumberStyles.AllowHexSpecifier;
            var iv = CultureInfo.InvariantCulture;
            var strdoc = "0000abcd";
            var strint = strdoc.Substring(0, 4);
            var spandoc = strdoc.AsSpan();
            var spanint = spandoc.Slice(0, 4);

            Assert.Equal(strint, spanint.ToString());

            Assert.True(int.TryParse(strint, hex, iv, out var actual));
            Assert.Equal(0, actual);

            Assert.True(int.TryParse(strint.AsSpan(), hex, iv, out actual));
            Assert.Equal(0, actual);

            Assert.True(int.TryParse(spanint, hex, iv, out actual));
            Assert.Equal(0, actual);
        }
    }
}

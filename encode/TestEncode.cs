using System;
using Xunit;

namespace encode
{
    public class TestEncode
    {
        private readonly Program _sut;

        public TestEncode()
        {
            _sut = new Program();
        }

        [Fact]
        public void testEncode()
        {
            var input = new byte[] { 0x6A, 0x77, 0xC4};

            string toTest = _sut.Encode(input);
            Assert.Equal("anfE",toTest);

        }
    }
}

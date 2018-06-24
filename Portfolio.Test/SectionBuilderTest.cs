using System;
using Xunit;
using Portfolio.Areas.Articles.Data;
using Newtonsoft.Json;
using Xunit.Abstractions;

namespace Portfolio.Test
{
    public class SectionBuilderTest
    {
        private readonly ITestOutputHelper output;

        public SectionBuilderTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void TestCreate()
        {


            SectionBuilder builder = new SectionBuilder
            {
                Index = 0,
                Title = "test"
            };
            builder.Serialize();
        }
    }
}

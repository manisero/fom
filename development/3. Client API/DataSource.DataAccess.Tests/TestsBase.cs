using AutoMoq;

namespace DataSource.DataAccess.Tests
{
    public class TestsBase
    {
        protected AutoMoqer AutoMoqer { get; private set; }

        public TestsBase()
        {
            AutoMoqer = new AutoMoqer();
        }
    }
}

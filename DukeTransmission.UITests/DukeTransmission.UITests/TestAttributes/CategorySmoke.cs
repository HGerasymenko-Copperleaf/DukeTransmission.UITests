using NUnit.Framework;

namespace DukeTransmission.UITests.TestAttributes
{
    public class CategorySmoke : CategoryAttribute
    {
        public CategorySmoke() : base("Smoke") { }
    }
}

using FluentAssertions;
using PrincessChoice.Generator;

namespace PrincessChoiceTest;

public class GeneratorTest
{
    [Test]
    public void Generate_UniqueNames()
    {
        IEnumerable<string> contenders = ContenderNameGenerator.GenerateNames();
        contenders.Should().OnlyHaveUniqueItems();
    }
}
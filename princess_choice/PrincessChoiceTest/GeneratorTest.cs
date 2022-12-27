using FluentAssertions;
using PrincessChoice.Generator;

namespace PrincessChoiceTest;

public class GeneratorTest
{
    [Test]
    public void Generate_UniqueNames()
    {
        var contenders = ContenderGenerator.GenerateContenders();
        var nameList = contenders.ConvertAll(c => c.Name);
        nameList.Should().OnlyHaveUniqueItems();
    }
}
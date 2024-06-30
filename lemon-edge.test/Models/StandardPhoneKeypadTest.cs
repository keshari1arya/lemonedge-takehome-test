using lemon_edge.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lemonedge_test.Models;

[TestClass]
public class StandardPhoneKeypadTest
{
    [TestMethod]
    public void Should_Validate_Row_Count()
    {
        // Arrange
        IKeypad keypad = new StandardPhoneKeypad();

        // Act
        int count = keypad.RowCount;

        // Assert
        Assert.AreEqual(4, count);
    }

    [TestMethod]
    public void Should_Validate_Column_Count()
    {
        // Arrange
        IKeypad keypad = new StandardPhoneKeypad();

        // Act
        int count = keypad.ColumnCount;

        // Assert
        Assert.AreEqual(3, count);
    }
}

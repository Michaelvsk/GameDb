using Michaelvsk.GameDb.Core.Errors;

namespace Michaelvsk.GameDb.Test.Core.Errors;
public class NotFoundTests
{
    [Fact]
    public void Set_Null_Message_ThrowsArgumentNullException()
    {
        string? message = null;
        IError error;

        #pragma warning disable CS8604 // Possible null reference argument.
        Action actual = () => error = new NotFound(message);
        #pragma warning restore CS8604 // Possible null reference argument.

        Assert.Throws<ArgumentNullException>(actual);
    }

    [Fact]
    public void Set_Empty_Message_ThrowsArgumentException()
    {
        string message = string.Empty;
        IError error;
        
        Action actual = () => error = new NotFound(message);

        Assert.Throws<ArgumentException>(actual);
    }

    [Fact]
    public void Set_Inner_Error_And_Read()
    {
        string message = "Outer Error";
        IError exprectedInner = new NotFound("Inner error");
        IError error = new NotFound(message, exprectedInner);

        var actual = error.Inner;

        Assert.Equal(exprectedInner, actual);
    }
}

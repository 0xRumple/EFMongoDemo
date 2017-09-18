using MongoDB.Bson;

namespace EFMongoDemo.Data.Extensions
{
    public static class IdExtensions
    {
	    public static string Create(this string leftOperand, ObjectId rightOperand)
        {
	        return rightOperand.ToString();
        }

	    public static ObjectId Create(this ObjectId leftOperand, string rightOperand)
	    {
		    return new ObjectId(rightOperand);
	    }

	    public static string Create(this string leftOperand, string rightOperand)
	    {
		    return rightOperand;
	    }

	    public static ObjectId Create(this ObjectId leftOperand, ObjectId rightOperand)
	    {
		    return new ObjectId(rightOperand.ToString());
	    }
    }
}

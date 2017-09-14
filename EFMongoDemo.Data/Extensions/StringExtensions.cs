using MongoDB.Bson;

namespace EFMongoDemo.Data.Extensions
{
    public static class StringExtensions
    {
        public static string Create(this string leftOperand, ObjectId rightOperand)
        {
	        return rightOperand.ToString();
        }
    }
}

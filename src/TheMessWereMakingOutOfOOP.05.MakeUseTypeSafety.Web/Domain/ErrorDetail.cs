namespace TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Domain
{
    public abstract class ErrorDetail
    {
        private ErrorDetail()
        {
        }
        
        public abstract TVisitResult Accept<TVisitResult>(IResultVisitor<TVisitResult> visitor);
        
        
        public interface IResultVisitor<TVisitResult>
        {
            TVisitResult Visit(NotFound result);
            TVisitResult Visit(Invalid result);
            
            //TVisitResult Visit(Unexpected result);
        }

        
        public sealed class NotFound : ErrorDetail
        {
            private NotFound(string message)
            {
                Message = message;
            }

            public string Message { get; }

            public static NotFound New(string message) => new NotFound(message);

            public override TVisitResult Accept<TVisitResult>(IResultVisitor<TVisitResult> visitor)
                => visitor.Visit(this);
        }

        public sealed class Invalid : ErrorDetail
        {
            private Invalid(string message)
            {
                Message = message;
            }

            public string Message { get; }

            public static Invalid New(string message) => new Invalid(message);

            public override TVisitResult Accept<TVisitResult>(IResultVisitor<TVisitResult> visitor)
                => visitor.Visit(this);
        }

//        public sealed class Unexpected : ErrorDetail
//        {
//            private Unexpected(string message)
//            {
//                Message = message;
//            }
//
//            public string Message { get; }
//
//            public static Unexpected New(string message) => new Unexpected(message);
//
//            public override TVisitResult Accept<TVisitResult>(IResultVisitor<TVisitResult> visitor)
//                => visitor.Visit(this);
//        }
    }
}
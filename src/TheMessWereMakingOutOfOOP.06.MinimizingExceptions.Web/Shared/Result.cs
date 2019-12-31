using TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Domain;

namespace TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Shared
{
    public abstract class Result<TValue>
    {
        public abstract bool IsSuccess { get; }

        public abstract TResult Accept<TVisitor, TResult>(TVisitor visitor)
            where TVisitor : IResultVisitor<TResult>;

        public interface IResultVisitor<TVisitResult>
        {
            TVisitResult Visit(Success result);

            TVisitResult Visit(Error.NotFound result);

            TVisitResult Visit(Error.Invalid result);

            //TVisitResult Visit(Error.Unexpected result);
        }

        public sealed class Success : Result<TValue>
        {
            private Success(TValue value)
            {
                Value = value;
            }

            public TValue Value { get; }

            public override bool IsSuccess => true;

            public override TVisitResult Accept<TResultVisitor, TVisitResult>(TResultVisitor visitor)
                => visitor.Visit(this);

            public static Success New(TValue value) => new Success(value);
        }

        public abstract class Error : Result<TValue>
        {
            private Error(string message)
            {
                Message = message;
            }

            public string Message { get; }
            
            public override bool IsSuccess => false;

            public abstract Result<TOtherValue>.Error AsErrorOf<TOtherValue>();

            public sealed class NotFound : Error
            {
                private NotFound(string message) : base(message)
                {
                }

                public static NotFound New(string message) => new NotFound(message);

                public override TVisitResult Accept<TResultVisitor, TVisitResult>(TResultVisitor visitor)
                    => visitor.Visit(this);

                public override Result<TOtherValue>.Error AsErrorOf<TOtherValue>()
                    => Result<TOtherValue>.Error.NotFound.New(Message);
            }

            public sealed class Invalid : Error
            {
                private Invalid(string message) : base(message)
                {
                }
                
                public static Invalid New(string message) => new Invalid(message);

                public override TVisitResult Accept<TResultVisitor, TVisitResult>(TResultVisitor visitor)
                    => visitor.Visit(this);

                public override Result<TOtherValue>.Error AsErrorOf<TOtherValue>()
                    => Result<TOtherValue>.Error.Invalid.New(Message);
            }

//            public sealed class Unexpected : Error
//            {
//                private Unexpected(string message) : base(message)
//                {
//                }
//
//                public string Message { get; }
//
//                public static Unexpected New(string message) => new Unexpected(message);
//
//                public override TVisitResult Accept<TResultVisitor, TVisitResult>(TResultVisitor visitor)
//                    => visitor.Visit(this);
//
//                public override Result<TOtherValue>.Error AsErrorOf<TOtherValue>()
//                    => Result<TOtherValue>.Error.Unexpected.New(Message);
//            }
        }
    }
}
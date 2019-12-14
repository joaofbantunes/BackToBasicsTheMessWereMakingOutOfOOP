using System;

namespace TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Shared
{
    /*
     * Instead of extensions, could make these part of the Result class, to be overriden by the various result types
     * but this way, things are a bit more decoupled, so if we want to add more operators, we can add them without
     * always changing the base classes.
     */
    public static class ResultExtensions
    {
        public static Result<TOutput> FlatMap<TInput, TOutput>(
            this Result<TInput> input,
            Func<TInput, Result<TOutput>> mapper)
            => input.Accept<FlatMapVisitor<TInput, TOutput>, Result<TOutput>>(
                new FlatMapVisitor<TInput, TOutput>(mapper));


        public static Result<TOutput> Map<TInput, TOutput>(
            this Result<TInput> input,
            Func<TInput, TOutput> mapper)
            => input.Accept<MapVisitor<TInput, TOutput>, Result<TOutput>>(
                new MapVisitor<TInput, TOutput>(mapper));

        public static Result<T> Do<T>(
            this Result<T> input,
            Action<T> doer)
            => input.Accept<DoVisitor<T>, Result<T>>(new DoVisitor<T>(doer));

        /*
         * For this scenario, maybe just pattern matching on the Success and Error results would be enough
         * but making use of the visitor enforces types in case of more significant changes to the Result.
         */
        
        private struct FlatMapVisitor<TInput, TOutput> : Result<TInput>.IResultVisitor<Result<TOutput>>
        {
            private readonly Func<TInput, Result<TOutput>> _mapper;

            public FlatMapVisitor(Func<TInput, Result<TOutput>> mapper)
            {
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public Result<TOutput> Visit(Result<TInput>.Success result) => _mapper(result.Value);
            public Result<TOutput> Visit(Result<TInput>.Error.NotFound result) => VisitError(result);
            public Result<TOutput> Visit(Result<TInput>.Error.Invalid result) => VisitError(result);
            private Result<TOutput> VisitError(Result<TInput>.Error result) => result.AsErrorOf<TOutput>();
        }

        private struct MapVisitor<TInput, TOutput> : Result<TInput>.IResultVisitor<Result<TOutput>>
        {
            private readonly Func<TInput, TOutput> _mapper;

            public MapVisitor(Func<TInput, TOutput> mapper)
            {
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public Result<TOutput> Visit(Result<TInput>.Success result)
                => Result<TOutput>.Success.New(_mapper(result.Value));

            public Result<TOutput> Visit(Result<TInput>.Error.NotFound result) => VisitError(result);
            public Result<TOutput> Visit(Result<TInput>.Error.Invalid result) => VisitError(result);
            private Result<TOutput> VisitError(Result<TInput>.Error result) => result.AsErrorOf<TOutput>();
        }

        private struct DoVisitor<T> : Result<T>.IResultVisitor<Result<T>>
        {
            private readonly Action<T> _doer;

            public DoVisitor(Action<T> doer)
            {
                _doer = doer ?? throw new ArgumentNullException(nameof(doer));
            }

            public Result<T> Visit(Result<T>.Success result)
            {
                _doer(result.Value);
                return result;
            }

            public Result<T> Visit(Result<T>.Error.NotFound result) => VisitError(result);
            public Result<T> Visit(Result<T>.Error.Invalid result) => VisitError(result);
            private Result<T> VisitError(Result<T>.Error result) => result.AsErrorOf<T>();
        }
    }
}
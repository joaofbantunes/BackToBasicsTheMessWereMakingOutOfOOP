using System;

namespace TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Shared
{
    // Simple implementation for demo
    // For a fully featured implementation,
    // checkout https://github.com/nlkl/Optional or https://github.com/zoran-horvat/option/ 
    
    public static class Optional
    {
        public static Optional<T> Some<T>(T value) => new Optional<T>(value, true);

        public static Optional<T> None<T>() => new Optional<T>(default(T), false);
    }

    public struct Optional<T>
    {
        private readonly bool _hasValue;
        private readonly T _value;

        public bool HasValue => _hasValue;

        internal Optional(T value, bool hasValue)
        {
            _value = value;
            _hasValue = hasValue;
        }

       public T ValueOr(Func<T> alternativeFactory) => _hasValue ? _value : alternativeFactory();

       public bool TryGetValue(out T value)
       {
           value = _hasValue ? _value : default;
           return _hasValue;
       }
    }
}
using System;
using System.Collections.Generic;
using TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Shared;

namespace TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Domain.ItemSaleRule
{
    public class CompositeItemSaleRule : IItemSaleRule
    {
        private readonly IEnumerable<IItemSaleRule> _rules;

        public CompositeItemSaleRule(IEnumerable<IItemSaleRule> rules)
        {
            _rules = rules ?? throw new ArgumentNullException(nameof(rules));
        }
        
        public Result<Unit> Validate(Cart cart, Item item, int quantity)
        {
            foreach (var rule in _rules)
            {
                var result = rule.Validate(cart, item, quantity);
                if (!result.IsSuccess)
                {
                    return result;
                }
            }

            return Result<Unit>.Success.New(Unit.Instance);
        }
    }
}
﻿using System.Collections.Generic;
using System.Linq;
using HappyTravel.CurrencyConverter.Infrastructure;

namespace HappyTravel.CurrencyConverter
{
    public static class ConversionBufferOptionsFactory
    {
        public static ConversionBufferOptions Create(IEnumerable<BufferPair> pairs)
        {
            var exceptionalPairs = pairs
                .ToDictionary(p => (p.SourceCurrency, p.TargetCurrency), p => p.BufferValue);

            return new ConversionBufferOptions(exceptionalPairs);
        }


        public static ConversionBufferOptions WithDefaultBuffer(this ConversionBufferOptions target, in decimal defaultBufferValue)
            => new ConversionBufferOptions(target.ExceptionalPairs, defaultBufferValue);
    }
}

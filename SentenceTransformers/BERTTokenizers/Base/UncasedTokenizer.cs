﻿using BERTTokenizers.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BERTTokenizers.Base
{
    public abstract class UncasedTokenizer : TokenizerBase
    {
        protected UncasedTokenizer(Stream vocabularyFile) : base(vocabularyFile)
        {
        }

        protected override IEnumerable<string> TokenizeSentence(string text)
        {
            return text.Split(new string[] { " ", "   ", "\r\n" }, StringSplitOptions.None)
               .SelectMany(o => o.SplitAndKeep(".,;:\\/?!#$%()=+-*\"'–_`<>&^@{}[]|~'".ToArray()))
               .Select(o => o.ToLower());
        }
    }
}
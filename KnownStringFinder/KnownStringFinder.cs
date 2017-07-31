using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder
{
    public class KnownStringFinder
    {
        private CharNode root;

        public KnownStringFinder(IEnumerable<string> texts)
        {
            if (texts == null) throw new ArgumentNullException("texts");

            root = new CharNode(' ');
            foreach (var text in texts)
            {
                var current = root;
                for (int i=0; i<text.Length; i++)
                {
                    CharNode child;
                    if (!current.Children.TryGetValue(text[i], out child))
                    {
                        child = new CharNode(text[i]);
                        current.Children.Add(text[i], child);
                    }

                    current = child;
                }

                if (current != root)
                {
                    current.EndsWord = text;
                }
            }
        }

        public HashSet<string> Find(string text)
        {
            if (string.IsNullOrEmpty(text)) return new HashSet<string>();

            var set = new HashSet<string>();
            var current = root;
            for (int i = 0; i < text.Length; i++)
            {
                CharNode child;
                if (current.Children.TryGetValue(text[i], out child))
                {
                    current = child;
                }
                else
                {
                    if (current.IsEndingWord)
                    {
                        set.Add(current.EndsWord);
                    }
                    current = root;
                }
            }

            return set;
        }
    }
}

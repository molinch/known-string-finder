using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder
{
    public class CharNode
    {
        public CharNode(char character)
        {
            Character = character;
            Children = new Dictionary<char,CharNode>();
        }

        public char Character { get; private set; }

        public string EndsWord { get; set; }

        public bool IsEndingWord
        {
            get
            {
                return !string.IsNullOrEmpty(EndsWord);
            }
        }

        public Dictionary<char, CharNode> Children { get; private set; }
    }
}

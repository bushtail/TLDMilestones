using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestones
{
    /**
     * If you're reading this, you're in the source code. You're in the mainframe, bro!
     * A stones file is, surprise surprise, just a renamed JSON file. This is the structure of an individual stone.
     */
    public class Stone
    {
        public string ID { get; }
        public string Title { get; }
        public string Description { get; }
        public bool IsHidden { get; set; }
        public int MaxProgress { get; set; }
        public bool Unlocked { get; private set; }

        public Stone(string id, string title, string description, bool isHidden, int maxProgress, bool unlocked)
        {
            ID = id;
            Title = title;
            Description = description;
            IsHidden = isHidden;
            MaxProgress = maxProgress;
            Unlocked = unlocked;
        }
    }

    public class StoneData
    {
        public string ModID { get; set; }
        public List<Stone> Stones { get; set; }

        public StoneData(string modID, List<Stone> stones)
        {
            ModID = modID;
            Stones = stones;
        }
    }
}

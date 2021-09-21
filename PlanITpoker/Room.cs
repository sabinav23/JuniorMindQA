using System;
using System.Collections.Generic;
using System.Text;

namespace PlanITpoker
{
    public class Room
    {
        public string name { get; set; }

        public int cardSetType { get; set; }

        public bool haveStories { get; set; }

        public bool confirmSkip { get; set; }

        public bool showVotingToObservers { get; set; }

        public bool autoReveal { get; set; }

        public bool changeVote { get; set; }

        public bool countdownTimer { get; set; }

        public int countdownTimerValue { get; set; }

        public int[] cards { set; get; }

    }
}

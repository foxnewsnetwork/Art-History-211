using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;

namespace IndigioDesktopApp.Views
{
    class ChallengesView
    {
        /*****************************************************
         * Usage notes: To the designer                      *
         * ***************************************************
         * If you're the designer and you're working on the view
         * for the challenges page, everything you'll need is in
         * the Accessibles region declare just below. As the
         * designer, it will be your job to properly display 
         * everything that is in the below variables
         * IMPORTANT: DO NOT INSTANTIATE THIS CLASS YOURSELF
         * FOR THE LOVE OF GOD, DO NOT DO IT; INSTEAD USE THE
         * ONE THAT EXISTS ALREADY.
         * 
         * Think about it, if you instantiate this class yourself
         * how the fuck am I suppose to know about it? How is the
         * rest of the framework suppose to make updates to it?
         * Fucking dumbass designer.
         * */
        #region Accessibles
        public List<String> Bounty { get; set; }
        public List<String> ChallengeSummary { get; set; }
        public List<String> Attempts { get; set; }
        public List<String> Winners { get; set; }
        public List<String> ChallengeStatus { get; set; }
        public List<BitmapData> ChallengePicture { get; set; }
        public List<String> ChallengeName { get; set; }
        #endregion

        #region Accessible Functions
        public void AcceptNewChallenge(int challengeId)
        {
            if (this.NewChallengeAccepted != null)
                NewChallengeAccepted(this, new NewChallengeAcceptedEventArgs(challengeId));
        }
        #endregion

        // Yes, how this is all going to work is things will call events
        // and the rest of the architecture handles these events. 
        // In other words, traditional windows programming
        #region Public Events
        public event EventHandler NewChallengeAccepted;
        #endregion
    }

    public class NewChallengeAcceptedEventArgs : EventArgs
    {
        public int ChallengeId { get; set; }
        public NewChallengeAcceptedEventArgs(int cid)
        {
            ChallengeId = cid;
        }
    }
}

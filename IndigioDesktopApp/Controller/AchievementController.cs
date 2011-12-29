using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndigioDesktopApp.Engine;

namespace IndigioDesktopApp.Controller
{
    public enum SupportedGames
    {
        Starcraft2
    }

    public class ChallengePack
    {
        public SupportedGames Game { get; private set; }
        public GameState beginState;
        public GameState successState;
        public GameState failState;

        public int Attempts { get; private set; }
        public int Successes { get; private set; }
        public int Failures { get; private set; }

        public void InitializeStats(int attempts, int successes, int failures)
        {
            this.Attempts = attempts;
            this.Successes = successes;
            this.Failures = failures;
        }
    }

    public class PlayerPack
    {
        public int Id { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public int AcceptedChallenges { get; set; }
        public int AccomplishedChallenges { get; set; }
        public int FailedChallenges { get; set; }
    }

    class AchievementController
    {
        #region Members
        protected PlayerPack player;
        protected List<ChallengePack> challenges;
        protected GameState gameState;
        #endregion

        #region Events
        public event EventHandler AchievementUnlocked;
        #endregion

        #region Public Interface
        public void Run()
        {
            // TODO: Implement Me!
        }
        #endregion

        #region Protected Internals

        #endregion
    }
}

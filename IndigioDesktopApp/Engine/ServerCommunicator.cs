using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndigioDesktopApp.Controller;

namespace IndigioDesktopApp.Engine
{
    public enum ServerResponse
    {
        Failure,
        Success,
        NoConnection,
        ServerBusy,
        RequestTimedOut,
        IncorrectAuthentication
    }

    public enum AdActionCode
    {
        ChallengeAccepted,
        ChallengeCompleted,
        ChallengeFailed,
        AdViewed,
        AdClicked,
        AdClosed,
    }

    class ServerCommunicator
    {
        #region Internals and PInvokes
        // TODO: Implement me!
        #endregion

        #region Members
        // TODO: Implement me!
        #endregion

        #region Public Wrappers
        public ServerResponse GetChallenges(out List<ChallengePack> challenges)
        {
            challenges = new List<ChallengePack>();
            return ServerResponse.Failure;
        }
        public ServerResponse GetPlayer(out PlayerPack player)
        {
            player = new PlayerPack();
            return ServerResponse.Failure;
        }
        public ServerResponse UpdateChallengeInfo(int challengeid, AdActionCode challengecode)
        {
            // TODO: Implement me!
            return ServerResponse.Failure;
        }
        public ServerResponse UpdatePlayerInfo(Dictionary<String, String> playerupdates)
        {
            // TODO: Implement me!
            return ServerResponse.Failure;
        }
        public ServerResponse InitializeConnection(String username, String password)
        {
            return ServerResponse.IncorrectAuthentication;
        }

        #endregion
    }
}

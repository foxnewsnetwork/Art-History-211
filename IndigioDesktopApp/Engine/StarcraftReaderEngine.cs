using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;


namespace IndigioDesktopApp.Engine
{
    public struct StarcraftGameState
    {
        public bool GameStart;
        public int GameTimer;
    }

    public struct StarcraftUnitState
    {
        public short times_used; //0x0000  
        public short id; //0x0002  
        public short previous_id; //0x0004  
        public short next_id; //0x0006  
        public int model; //0x0008  


        public sbyte playerOwner; //0x0027  

        public sbyte isAlive; //0x0029  

        public sbyte isPaused; //0x002E  

        public short kills; //0x0032  
        public sbyte playerOwner2; //0x0034  
        public sbyte playerOwner3; //0x0035  

        public int positionX; //0x0040  
        public int positionY; //0x0044  
        public int positionZ; //0x0048  

        public int rotationX; //0x0054  
        public int rotationY; //0x0058  
        public int rotation; //0x005C  

        public int destinationX; //0x0074  
        public int destinationY; //0x0078  
        public int destinationZ; //0x007C  

        public int lastOrder; //0x0084  
        public int destinationX2; //0x0088  
        public int destinationY2; //0x008C  
        public int startPositionX; //0x0090  
        public int startPositionY; //0x0094  
        public int destinationX3; //0x0098  
        public int destinationY3; //0x009C  
        public int startPosition2X; //0x00A0  
        public int startPosition2Y; //0x00A4  

        public int moveSpeed; //0x00B8  

        public int commandQueue; //0x00C4  



        public int healthDamage; //0x0104  
        public int shieldDamage; //0x0108  
        public int energyDamage; //0x010C  
        public int healthMax; //0x0110  
        public int shieldMax; //0x0114  
        public int energyMax; //0x0118  
        public int healthMultiplier; //0x011C  
        public int shieldMultiplier; //0x0120  
        public int energyMultiplier; //0x0124  

        public int lifespan; //0x0151  
        public int lastAttacked; //0x0155  

        public int bountyMinerals; //0x0168  
        public int bountyVespene; //0x016C  
        public int bountyTerrazine; //0x0170  
        public int bountyCustom; //0x0174  
        public int bountyXP; //0x0178  
        public sbyte cellX_Approx; //0x017C  
        public sbyte cellY_Approx; //0x017D  
    }

    public struct StarcraftPlayerState
    {
        public sbyte status; //0x0000
        public int cameraX; //0x0008  
        public int cameraY; //0x000C  
        public int cameraDistance; //0x0010  
        public int cameraAngleOfAttack; //0x0014  
        public int cameraRotation; //0x0018  
        public sbyte team; //0x001C  
        public sbyte playerType; //0x001D  
        public sbyte playingStatus; //0x001E
        public sbyte difficulty; //0x0027
        public int attackMultiplier; //0x00F8  
        public int damageMultiplier; //0x00FC
        public int apmCurrent; //0x0270
        public int unitsKilled; //0x02A0  
        public int unitsLost; //0x02A8  
        public int unitsBetrayed; //0x02B0
        public int harvesters_current; //0x03B8
        public int harvesters_built; //0x03C8
        public int building_queue_length; //0x03E8  
        public int buildings_constructing; //0x03F0  
        public int buildings_current; //0x03F8  
        public int total_constructing_queue_length; //0x0400  
        public int total_constructing; //0x0408  
        public int army_size; //0x0410  

        public int supplyCap; //0x0468  

        public int supplyCurrent; //0x0470  

        public int mineralsCurrent; //0x0498  

        public int vespeneCurrent; //0x04A0  

        public int terrazineCurrent; //0x04A8  

        public int customCurrent; //0x04B0  

        public int mineralsTotal; //0x04B8  

        public int vespeneTotal; //0x04C0  

        public int terrazineTotal; //0x04C8  

        public int customTotal; //0x04D0  

        public int mineralsRate; //0x0518  

        public int vespeneRate; //0x0520  

        public int terrazineRate; //0x0528  

        public int customRate; //0x0530  

        public int slowMineralsCurrent; //0x0538  

        public int slowVespeneCurrent; //0x0540  

        public int slowTerrazineCurrent; //0x0548  

        public int slowCustomCurrent; //0x0550  

        public int units_lost_minerals_worth; //0x0580  

        public int buildings_lost_minerals_worth; //0x0588  

        public int buildings_lost_vespene_worth; //0x0590  

        public int units_lost_vespene_worth; //0x05A0  
    }

    public class StarcraftReaderEngine : IDisposable
    {
        #region PInvokes
        // TODO: Make the PInvokes actually work!
        [DllImport("GameStateReader.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr OpenGameStream();

        [DllImport("GameStateReader.dll", CharSet = CharSet.Auto, SetLastError = true)]
        unsafe private static extern IntPtr ReadGameState(void* pGameStateReader);

        [DllImport("GameStateReader.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int ReadPlayerState(IntPtr pGameStateReader, out void* pStarcraftPlayerState, out int* pUnitCount);

        [DllImport("GameStateReader.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int ReadUnitState(IntPtr pGameStateReader, out void** ppStarcraftUnitState, out int* pUnitCount);

        [DllImport("GameStateReader.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int CloseGameStream(IntPtr pGameStateReader);
        #endregion PInvokes

        #region Members
        private IntPtr m_pGameStateReader;
        private IntPtr m_pStarcraftGameState;
        private IntPtr m_pStarcraftPlayerState;
        private IntPtr m_ppStarcraftUnitState;
        private IntPtr m_pUnitCount;
        #endregion Members

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool bDisposing)
        {
            if (this.m_pGameStateReader != IntPtr.Zero)
            {
                CloseGameStream(this.m_pGameStateReader);
                this.m_pGameStateReader = IntPtr.Zero;
            }
            if (bDisposing)
                GC.SuppressFinalize(this);
        }
        #endregion

        ~StarcraftReaderEngine()
        {
            Dispose(false);
        }

        #region WrapperMethods
        public StarcraftGameState GetGameState()
        {
            // TODO: Implement me!!
            StarcraftGameState mygame = new StarcraftGameState();
            return mygame;
        }

        public StarcraftPlayerState GetPlayerState()
        {
            // TODO: Implement me!
            StarcraftPlayerState myplayer = new StarcraftPlayerState();
            return myplayer;
        }

        public List<StarcraftUnitState> GetUnitState()
        {
            // TODO: Implement me!
            List<StarcraftUnitState> myunits = new List<StarcraftUnitState>();
            myunits.Add(new StarcraftUnitState());
            return myunits;
        }
        #endregion
    }
}

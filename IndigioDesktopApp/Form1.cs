using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
// testing purposes
using IndigioDesktopApp.Engine;
using IndigioDesktopApp.Controller;
using IndigioDesktopApp.Views;

namespace IndigioDesktopApp
{
    public partial class Form1 : Form
    {
        /**************************************************
         * Notes to the designer                          *
         * ************************************************
         * Use these tools to put cool things in the view
         * you stupid faggot.                           
         * */
        #region Tools For The Designer
        public ChallengesView vChallengesView;
        public FriendsView vFriendsView;
        public GamesView vGamesView;
        public HomeView vHomeView;
        public RewardsView vRewardsView;
        public StoreView vStoreView;
        #endregion

        /*************************************
         * Notes to the designer             *
         * ***********************************
         * If I catch you rifling through controller
         * and touching her in appropriate places,
         * I'm going to hunt you down and skin you
         * alive, boy!
         * */
        #region Not For The Designer
        public 
        #endregion

        public Form1()
        {
            InitializeComponent();

            /*********************************
             * Custom Initialization Section *
             * ******************************/
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}

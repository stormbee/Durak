﻿using System.Linq;

namespace Durak
{
    internal class DealCards : DeckOfCards
    {
        private Card[] playerHand;
        private Card[] computerHand;
        private Card[] sortedPlayerHand;
        private Card[] sortedComputerHand;

        public DealCards()
        {
            playerHand = new Card[6];
            sortedPlayerHand = new Card[6];
            computerHand = new Card[6];
            sortedComputerHand = new Card[6];
        }

        public void Deal()
        {
            setUpDeck();  //create the deck of cards and shuffle them
            getHand();  // deal hands to player and comuter
            sortHand(); // sort hands by value
            //displayCards();
        }

        public void getHand()
        {
            //6 cards for player
            for(int i = 0; i < 6; i++)
                playerHand[i] = GetDeck[i];

            //6 cards for computer
            for(int i = 6; i < 12; i++)
                computerHand[i - 6] = GetDeck[i];     //  index of computer hand start from 0
        }

        public void sortHand()
        {
            var queryPlayer = from hand in playerHand
                              orderby hand.Cvalue
                              select hand;

            var queryComputer = from hand in computerHand
                                orderby hand.Cvalue
                                select hand;
            var index = 0;
            foreach(var e in queryPlayer.ToList())
            {
                sortedPlayerHand[index] = e;
                index++;
            }

            index = 0;
            foreach(var e in queryComputer.ToList())
            {
                sortedComputerHand[index] = e;
                index++;
            }
        }

        // public void displayCards() {
    }
}
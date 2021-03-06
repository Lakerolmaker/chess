﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chess
{
    class Globalvar
    {

        public static int playerID = 1;

        public static List<piece> pieces = new List<piece>();

        public static List<highlightedTile> highlightedTiles = new List<highlightedTile>();
        public static List<castlingMove> castlingMoveTiles = new List<castlingMove>();

        public static Label[,] Tiles = new Label[8, 8];

        public static int whiteKillCount = 0;
        public static int blackKillcount = 0;

        public static List<PictureBox> whiteKillBoard = new List<PictureBox>();
        public static List<PictureBox> blackKillBoard = new List<PictureBox>();

        private static Random rand = new Random();


        public static piece getPiece(String pieceName)
        {
            piece returned = null;

            //: hittar rätt piece
            foreach (piece item in Globalvar.pieces)
            {
                if (item.ThePiece.Name == pieceName)
                {
                    returned = item;
                }
            }

            return returned;
        }

        public static piece getPieceAt(int x , int y)
        {

            return getPiece(Tiles[x, y].Controls[0].Name);

        }

        public static int getIndex(String pieceName)
        {
            //: hittar rätt piece
            for(int  i = 0; i < pieces.Count; i++)
            {
                if (pieces[i].ThePiece.Name == pieceName)
                {
                    return i;
                }
            }

            return -1;
        }

        public static void removePiece(String pieceName)
        {
            for (int i = 0; i < pieces.Count; i++)
            {
                if (pieces[i].ThePiece.Name == pieceName)
                {
                    pieces.RemoveAt(i);
                }
            }
        }

        public static void changeTurn()
        {
            if(playerID == 1)
            {
                playerID = 2;
            }else
            {
                playerID = 1;
            }
        }

        public static void removeKillOrder()
        {
            foreach (piece item in Globalvar.pieces)
            {
                item.killOrder = false;
            }
        }

        public static void removeHighlight()
        {
            foreach (highlightedTile item in Globalvar.highlightedTiles)
            {
                item.changeback();
                item.location.Click -= item.Location_Click;
            }

            foreach (castlingMove item in Globalvar.castlingMoveTiles)
            {
                item.changeback();
                item.location.Click -= item.Location_Click;
            }

            highlightedTiles.Clear();
            castlingMoveTiles.Clear();

        }

        public static void endGame(String loserColor)
        {
            String winnercolor = FirstCharToUpper(oppositeColor(loserColor));

            String title = winnercolor + " Wins";

            int id = getOpositePlayerID();

            String message = "Player " + id + " is the winner";

            MessageBox.Show(message , title);

            playerID = 0;
        }

        public static void lockControls()
        {
            playerID = 0;
        }


        public static int getOpositePlayerID()
        {
            if (playerID == 1)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }

        public static string oppositeColor(String Color)
        {
            if(Color == "white")
            {
                return "black";
            }
            else
            {
                return "white";
            }
        }

        public static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            return input.First().ToString().ToUpper() + input.Substring(1);
        }

        public static string getRandomPiece()
        {
            int randomNum = rand.Next(0, 6);
            
            if(randomNum == 0)
            {
                return "pawn";
            }
            else if (randomNum == 1)
            {
                return "tower";
            }
            else if (randomNum == 2)
            {
                return "horse";
            }
            else if (randomNum == 3)
            {
                return "sprinter";
            }
            else if (randomNum == 4)
            {
                return "queen";
            }
            else if (randomNum == 5)
            {
                return "king";
            }
            else
            {
                return null;
            }

        }

    }

}
